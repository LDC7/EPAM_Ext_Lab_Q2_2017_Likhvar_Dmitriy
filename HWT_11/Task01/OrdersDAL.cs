namespace Task01
{
    using System.Data.Common;
    using System.Data;
    using System;
    using System.Collections.Generic;

    public class OrdersDAL
    {
        private string connectionString;
        private DbProviderFactory factory;

        public OrdersDAL(DbProviderFactory fac, string connectStr)
        {
            connectionString = connectStr;
            factory = fac;
        }

        //добавить новый заказ в базу
        public int Insert(Order order)
        {
            int newid;
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
                    "VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}" +
                    "SELECT @@IDENTITY",
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
                    "VALUES ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}" +
                    "SELECT @@IDENTITY",
                    order.OrderID, order.CustomerID, order.EmployeeID,
                    order.OrderDate, order.RequiredDate, order.ShippedDate, order.ShipVia, order.Freight, order.ShipName,
                    order.ShipAddress, order.ShipCity, order.ShipRegion, order.ShipPostalCode, order.ShipCountry
                    );
                }

                newid = (int)com.ExecuteScalar();
                connection.Close();
            }
            return newid;
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
            Order buf;
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
                    buf = new Order((int)reader["OrderID"], (int)reader["CustomerID"], (int)reader["EmployeeID"], (decimal)reader["Freight"], (DateTime)reader["OrderDate"],
                        (DateTime)reader["ShippedDate"], (DateTime)reader["RequiredDate"], (int)reader["ShipVia"], (string)reader["ShipName"], (string)reader["ShipAddress"],
                        (string)reader["ShipCity"], (string)reader["ShipRegion"], (string)reader["ShipPostalCode"], (string)reader["ShipCountry"]);
                }

                com.ExecuteNonQuery();
                connection.Close();
            }

            return buf;
        }

        //получить n верхних записей (0 - все записи)
        public Order[] TopOrders(int n)
        {
            Order[] buf = new Order[n];

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                var com = connection.CreateCommand();
                com.CommandType = CommandType.Text;

                if (n == 0)
                {
                    com.CommandText = string.Format("Select * FROM [dbo].[Orders]");
                }
                else
                {
                    com.CommandText = string.Format("Select TOP {0} * FROM [dbo].[Orders]", n);
                }

                using (IDataReader reader = com.ExecuteReader())
                {
                    for (int i = 0; i < n; i++)
                    {
                        reader.Read();
                        buf[i] = new Order((int)reader["OrderID"], (int)reader["CustomerID"], (int)reader["EmployeeID"], (decimal)reader["Freight"], (DateTime)reader["OrderDate"],
                        (DateTime)reader["ShippedDate"], (DateTime)reader["RequiredDate"], (int)reader["ShipVia"], (string)reader["ShipName"], (string)reader["ShipAddress"],
                        (string)reader["ShipCity"], (string)reader["ShipRegion"], (string)reader["ShipPostalCode"], (string)reader["ShipCountry"]);
                    }
                }

                com.ExecuteNonQuery();
                connection.Close();
            }

            return buf;
        }

        //кол-во заказаных продуктов для покупателя
        public List<Tuple<string, int>> CustOrderHist(int customerId)
        {
            var list = new List<Tuple<string, int>>();  //да. требует тайных знаний, но плодить классы не хочется

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                var com = connection.CreateCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = string.Format("CustOrderHist {0}", customerId);

                using (IDataReader reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Tuple<string, int>((string)reader["ProductName"], (int)reader["Quantity"]));
                    }
                }
            }

            return list;
        }

        //Подробная информация о цене заказа
        public List<Tuple<string, decimal, int, decimal, decimal>> CustOrderDetail(int orderId)
        {
            var list = new List<Tuple<string, decimal, int, decimal, decimal>>();

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                var com = connection.CreateCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = string.Format("CustOrderDetail {0}", orderId);

                using (IDataReader reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Tuple<string, decimal, int, decimal, decimal>((string)reader["ProductName"], (decimal)reader["UnitPrice"],
                            (int)reader["Quantity"], (decimal)reader["Discount"], (decimal)reader["ExtendedPrice"]));
                    }
                }
            }

            return list;
        }

        //полная информация(возвращает суперобъект)
        public Tuple<Order, List<Tuple<string, decimal, int, decimal, decimal>>> FullInfo(int orderId)
        {
            return new Tuple<Order, List<Tuple<string, decimal, int, decimal, decimal>>>(Select(orderId), CustOrderDetail(orderId));
        }

        //передать в работу
        public void StartProgress(int orderId, DateTime date)
        {
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                var com = connection.CreateCommand();
                com.CommandType = CommandType.Text;

                com.CommandText = string.Format("UPDATE [dbo].[Orders] SET [OrderDate] = {0} WHERE [OrderID] = {1}", date, orderId);

                com.ExecuteNonQuery();

                connection.Close();
            }
        }

        //пометить как выполненный
        public void OrderCompleted(int orderId, DateTime date)
        {
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                var com = connection.CreateCommand();
                com.CommandType = CommandType.Text;

                com.CommandText = string.Format("UPDATE [dbo].[Orders] SET [ShippedDate] = {0} WHERE [OrderID] = {1}", date, orderId);

                com.ExecuteNonQuery();

                connection.Close();
            }
        }
    }
}
