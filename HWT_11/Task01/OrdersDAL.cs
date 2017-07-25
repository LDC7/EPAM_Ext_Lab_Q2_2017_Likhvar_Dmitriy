namespace Task01
{
    using System;
    using System.Configuration;
    using System.Data.Common;
    using System.Data;

    class OrdersDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private DbProviderFactory factory = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["DefaultConnection"].ProviderName);

        //добавить новый заказ в базу
        public void Insert(Order order)
        {
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                var com = connection.CreateCommand();
                com.CommandType = CommandType.Text;

                if (order.OrderID == null)
                {
                    com.CommandText = string.Format("INSERT INTO [dbo].[Orders] ([CustomerID],[EmployeeID]" +
                    ",[OrderDate],[RequiredDate],[ShippedDate],[ShipVia],[Freight],[ShipName]" +
                    ",[ShipAddress],[ShipCity],[ShipRegion],[ShipPostalCode],[ShipCountry])" +
                    "VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}",
                    order.CustomerID, order.EmployeeID,
                    order.OrderDate, order.RequiredDate, order.ShippedDate, order.ShipVia, order.Freight, order.ShipName,
                    order.ShipAddress, order.ShipCity, order.ShipRegion, order.ShipPostalCode, order.ShipCountry
                    );
                }
                else
                {
                    com.CommandText = string.Format("INSERT INTO [dbo].[Orders] ([OrderID],[CustomerID],[EmployeeID]" +
                    ",[OrderDate],[RequiredDate],[ShippedDate],[ShipVia],[Freight],[ShipName]" +
                    ",[ShipAddress],[ShipCity],[ShipRegion],[ShipPostalCode],[ShipCountry])" +
                    "VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}",
                    order.OrderID, order.CustomerID, order.EmployeeID,
                    order.OrderDate, order.RequiredDate, order.ShippedDate, order.ShipVia, order.Freight, order.ShipName,
                    order.ShipAddress, order.ShipCity, order.ShipRegion, order.ShipPostalCode, order.ShipCountry
                    );
                }

                com.ExecuteNonQuery();
                connection.Close();
            }
        }

        //обновить заказ (пр ID)
        public void Update(Order order)
        {
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                var com = connection.CreateCommand();
                com.CommandType = CommandType.Text;

                if (order.OrderID != null)
                {
                    com.CommandText = string.Format("UPDATE [dbo].[Orders]" +
                    "SET [CustomerID] = {0},[EmployeeID] = {1}" +
                    ",[OrderDate] = {2},[RequiredDate] = {3},[ShippedDate] = {4},[ShipVia] = {5},[Freight] = {6}" +
                    ",[ShipName] = {7},[ShipAddress] = {8},[ShipCity] = {9},[ShipRegion] = {10}" +
                    ",[ShipPostalCode] = {11},[ShipCountry] = {12} WHERE [OrderID] = {13}",
                    order.CustomerID, order.EmployeeID,
                    order.OrderDate, order.RequiredDate, order.ShippedDate, order.ShipVia, order.Freight,
                    order.ShipName, order.ShipAddress, order.ShipCity, order.ShipRegion,
                    order.ShipPostalCode, order.ShipCountry, order.OrderID
                    );

                    com.ExecuteNonQuery();
                }
                
                connection.Close();
            }
        }

        //удалить по ID
        public void Delete(int id)
        {
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                var com = connection.CreateCommand();
                com.CommandType = CommandType.Text;

                com.CommandText = string.Format("DELETE FROM [dbo].[Orders]" +
                "WHERE [OrderID] = {0}", id
                );

                com.ExecuteNonQuery();
                connection.Close();
            }
        }

        //получить заказ по id
        public Order Select(int id)
        {
            Order buf = new Order();

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                var com = connection.CreateCommand();
                com.CommandType = CommandType.Text;

                com.CommandText = string.Format("Select * FROM [dbo].[Orders]" +
                "WHERE [OrderID] = {0}", id
                );

                using (IDataReader reader = com.ExecuteReader())
                {
                    reader.Read();
                    buf.OrderID = (int)reader["OrderID"];
                    //-------------------
                }

                com.ExecuteNonQuery();
                connection.Close();
            }

            return buf;
        }

    }
}
