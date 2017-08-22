namespace DAL
{
    using System.Data.Common;
    using System.Data;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    public class NorthwndDAL
    {
        private string connectionString;
        private DbProviderFactory factory;

        public NorthwndDAL(DbProviderFactory fac, string connectStr)
        {
            connectionString = connectStr;
            factory = fac;
        }

        public bool CheckConnection()
        {
            bool flag;
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                flag = true;
                connection.Close();
            }
            return flag;
        }

        //добавить новый заказ в базу
        public int Insert(Order order)
        {
            decimal newid;
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
                    ",[ShipAddress],[ShipCity],[ShipRegion],[ShipPostalCode],[ShipCountry]) " +
                    "VALUES (@customerId,@employeeId,@orderDate,@requiredDate,@shippedDate,@shipVia" +
                    ",@Freight,@shipName,@shipAddress,@shipCity,@shipRegion,@shipPostalCode,@shipCountry) " +
                    "SELECT @@IDENTITY"
                    );
                }
                else
                {
                    com.CommandText = string.Format("SET IDENTITY_INSERT [dbo].[Orders] ON; " +
                    "INSERT INTO [dbo].[Orders] ([OrderID],[CustomerID],[EmployeeID]" +
                    ",[OrderDate],[RequiredDate],[ShippedDate],[ShipVia],[Freight],[ShipName]" +
                    ",[ShipAddress],[ShipCity],[ShipRegion],[ShipPostalCode],[ShipCountry]) " +
                    "VALUES (@orderId,@customerId,@employeeId,@orderDate,@requiredDate,@shippedDate,@shipVia" +
                    ",@Freight,@shipName,@shipAddress,@shipCity,@shipRegion,@shipPostalCode,@shipCountry) " +
                    "SELECT @@IDENTITY " +
                    "SET IDENTITY_INSERT [dbo].[Orders] OFF;"
                    );

                    com.Parameters.Add(DBParam("@orderId", order.OrderID));
                }

                
                com.Parameters.Add(DBParam("@customerId", order.CustomerID));
                com.Parameters.Add(DBParam("@employeeId", order.EmployeeID));
                com.Parameters.Add(DBParam("@orderDate", order.OrderDate));
                com.Parameters.Add(DBParam("@requiredDate", order.RequiredDate));
                com.Parameters.Add(DBParam("@shippedDate", order.ShippedDate));
                com.Parameters.Add(DBParam("@shipVia", order.ShipVia));
                com.Parameters.Add(DBParam("@Freight", order.Freight));
                com.Parameters.Add(DBParam("@shipName", order.ShipName));
                com.Parameters.Add(DBParam("@shipAddress", order.ShipAddress));
                com.Parameters.Add(DBParam("@shipCity", order.ShipCity));
                com.Parameters.Add(DBParam("@shipRegion", order.ShipRegion));
                com.Parameters.Add(DBParam("@shipPostalCode", order.ShipPostalCode));
                com.Parameters.Add(DBParam("@shipCountry", order.ShipCountry));

                //com.ExecuteNonQuery();
                newid = (decimal)com.ExecuteScalar();
                connection.Close();
            }
            return (int)newid;
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
                    com.CommandText = string.Format("UPDATE [dbo].[Orders] " +
                    "SET [CustomerID] = @customerId,[EmployeeID] = @employeeId" +
                    ",[OrderDate] = @orderDate,[RequiredDate] = @requiredDate,[ShippedDate] = @shippedDate" +
                    ",[ShipVia] = @shipVia,[Freight] = @Freight,[ShipName] = @shipName,[ShipAddress] = @shipAddress" +
                    ",[ShipCity] = @shipCity,[ShipRegion] = @shipRegion,[ShipPostalCode] = @shipPostalCode" +
                    ",[ShipCountry] = @shipCountry WHERE [OrderID] = @orderId",
                    order.CustomerID, order.EmployeeID,
                    order.OrderDate, order.RequiredDate, order.ShippedDate, order.ShipVia, order.Freight,
                    order.ShipName, order.ShipAddress, order.ShipCity, order.ShipRegion,
                    order.ShipPostalCode, order.ShipCountry, order.OrderID
                    );

                    com.Parameters.Add(DBParam("@customerId", order.CustomerID));
                    com.Parameters.Add(DBParam("@employeeId", order.EmployeeID));
                    com.Parameters.Add(DBParam("@orderDate", order.OrderDate));
                    com.Parameters.Add(DBParam("@requiredDate", order.RequiredDate));
                    com.Parameters.Add(DBParam("@shippedDate", order.ShippedDate));
                    com.Parameters.Add(DBParam("@shipVia", order.ShipVia));
                    com.Parameters.Add(DBParam("@Freight", order.Freight));
                    com.Parameters.Add(DBParam("@shipName", order.ShipName));
                    com.Parameters.Add(DBParam("@shipAddress", order.ShipAddress));
                    com.Parameters.Add(DBParam("@shipCity", order.ShipCity));
                    com.Parameters.Add(DBParam("@shipRegion", order.ShipRegion));
                    com.Parameters.Add(DBParam("@shipPostalCode", order.ShipPostalCode));
                    com.Parameters.Add(DBParam("@shipCountry", order.ShipCountry));
                    com.Parameters.Add(DBParam("@orderId", order.OrderID));

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

                com.CommandText = string.Format("DELETE FROM [dbo].[Orders] " +
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

                com.CommandText = string.Format("Select * FROM [dbo].[Orders] " +
                "WHERE [OrderID] = {0}", id
                );
                
                using (IDataReader reader = com.ExecuteReader())
                {
                    reader.Read();
                    buf = new Order(checkOnDBNull<int>(reader["OrderID"]), checkOnDBNull<string>(reader["CustomerID"]),
                        checkOnDBNull<int>(reader["EmployeeID"]), checkOnDBNull<decimal>(reader["Freight"]),
                        checkOnDBNull<DateTime?>(reader["OrderDate"]), checkOnDBNull<DateTime?>(reader["ShippedDate"]),
                        checkOnDBNull<DateTime?>(reader["RequiredDate"]), checkOnDBNull<int>(reader["ShipVia"]),
                        checkOnDBNull<string>(reader["ShipName"]), checkOnDBNull<string>(reader["ShipAddress"]),
                        checkOnDBNull<string>(reader["ShipCity"]), checkOnDBNull<string>(reader["ShipRegion"]),
                        checkOnDBNull<string>(reader["ShipPostalCode"]), checkOnDBNull<string>(reader["ShipCountry"]));
                }

                com.ExecuteNonQuery();
                connection.Close();
            }

            return buf;
        }

        //получить n верхних записей (0 - все записи)
        public List<Order> TopOrders(int n)
        {
            List<Order> buf = new List<Order>();

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
                    while(reader.Read())
                    {
                        buf.Add(new Order(checkOnDBNull<int>(reader["OrderID"]), checkOnDBNull<string>(reader["CustomerID"]),
                            checkOnDBNull<int>(reader["EmployeeID"]), checkOnDBNull<decimal>(reader["Freight"]),
                            checkOnDBNull<DateTime?>(reader["OrderDate"]), checkOnDBNull<DateTime?>(reader["ShippedDate"]),
                            checkOnDBNull<DateTime?>(reader["RequiredDate"]), checkOnDBNull<int>(reader["ShipVia"]),
                            checkOnDBNull<string>(reader["ShipName"]), checkOnDBNull<string>(reader["ShipAddress"]),
                            checkOnDBNull<string>(reader["ShipCity"]), checkOnDBNull<string>(reader["ShipRegion"]),
                            checkOnDBNull<string>(reader["ShipPostalCode"]), checkOnDBNull<string>(reader["ShipCountry"])));
                    }
                }

                com.ExecuteNonQuery();
                connection.Close();
            }

            return buf;
        }

        //кол-во заказаных продуктов для покупателя
        public List<Tuple<string, int>> CustOrderHist(string customerId)
        {
            var list = new List<Tuple<string, int>>();  //да. требует тайных знаний, но плодить классы не хочется

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                var com = connection.CreateCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "CustOrderHist";
                //com.CommandType = CommandType.Text;
                //com.CommandText = string.Format("EXEC [dbo].[CustOrderHist] {0}", customerId);
                com.Parameters.Add(DBParam("CustomerID", customerId));

                using (IDataReader reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Tuple<string, int>(checkOnDBNull<string>(reader["ProductName"]), checkOnDBNull<int>(reader["Total"])));
                    }
                }
            }

            return list;
        }

        //Подробная информация о цене заказа
        public List<Tuple<string, decimal, Int16, int, decimal>> CustOrderDetail(int orderId)
        {
            var list = new List<Tuple<string, decimal, Int16, int, decimal>>();

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                var com = connection.CreateCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "CustOrdersDetail";
                com.Parameters.Add(DBParam("OrderID", orderId));

                using (IDataReader reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Tuple<string, decimal, Int16, int, decimal>(checkOnDBNull<string>(reader["ProductName"]),
                            checkOnDBNull<decimal>(reader["UnitPrice"]), checkOnDBNull<Int16>(reader["Quantity"]),
                            checkOnDBNull<int>(reader["Discount"]), checkOnDBNull<decimal>(reader["ExtendedPrice"])));
                    }
                }
            }

            return list;
        }

        //полная информация(возвращает суперобъект)
        public Tuple<Order, List<Tuple<string, decimal, Int16, int, decimal>>> FullInfo(int orderId)
        {
            return new Tuple<Order, List<Tuple<string, decimal, Int16, int, decimal>>>(Select(orderId), CustOrderDetail(orderId));
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

                com.CommandText = string.Format("UPDATE [dbo].[Orders] SET [OrderDate] = @orderDate WHERE [OrderID] = @orderId");

                com.Parameters.Add(DBParam("@orderDate", date));
                com.Parameters.Add(DBParam("@orderId", orderId));

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

                com.CommandText = string.Format("UPDATE [dbo].[Orders] SET [ShippedDate] = @shippedDate WHERE [OrderID] = @orderId");

                com.Parameters.Add(DBParam("@shippedDate", date));
                com.Parameters.Add(DBParam("@orderId", orderId));

                com.ExecuteNonQuery();
                
                connection.Close();
            }
        }

        //название продукта
        public string ProductName(int productId)
        {
            string name;
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                var com = connection.CreateCommand();
                com.CommandType = CommandType.Text;
                com.CommandText = string.Format("Select ProductName FROM [dbo].[Products] " +
                "WHERE [ProductID] = {0}", productId
                );
                name = (string)com.ExecuteScalar();

                connection.Close();
            }

            return name;
        }

        //имя заказчика
        public string CustomerName(string customerId)
        {
            string name;
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                var com = connection.CreateCommand();
                com.CommandType = CommandType.Text;
                com.CommandText = string.Format("Select CompanyName FROM [dbo].[Customers] " +
                "WHERE [CustomerID] = '{0}'", customerId
                );
                name = (string)com.ExecuteScalar();

                connection.Close();
            }

            return name;
        }

        private T checkOnDBNull<T>(object obj)
        {
            if (obj == DBNull.Value)
            {
                return default(T);
            }
            else
            {
                return (T)obj;
            }
        }

        private IDbDataParameter DBParam(string str, object obj)
        {
            if (obj == null) obj = DBNull.Value;
            IDbDataParameter dbparam = new SqlParameter(str, obj);
            return dbparam;
        }
    }
}
