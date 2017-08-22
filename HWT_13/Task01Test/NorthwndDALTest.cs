namespace Task01Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.Common;

    using DAL;

    [TestClass]
    public class NorthwndDALTest
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private static DbProviderFactory factory = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["DefaultConnection"].ProviderName);
        private NorthwndDAL DAL = new NorthwndDAL(factory, connectionString);

        [TestMethod]
        public void Test_Connection()
        {
            var expected = true;
            var actual = DAL.CheckConnection();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_TopOrders()
        {
            var expected = "51100";
            var buf = DAL.TopOrders(100);
            var actual = buf[0].ShipPostalCode;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Select()
        {
            var expected = Status.Done;
            Order buf = DAL.Select(10248);
            var actual = buf.status;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Inserting1()
        {
            var expected = 99999;
            Order ord = new Order(99999, "VINET", 1, 10000);
            var actual = DAL.Insert(ord);
            DAL.Delete(actual);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Inserting2()
        {
            var expected = "VINET";
            Order ord = new Order(null, "VINET", 1, 10000);
            int newid = DAL.Insert(ord);
            var actual = DAL.Select(newid).CustomerID;
            DAL.Delete(newid);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_OrderToProgress()
        {
            var expected = Status.InProgress;
            Order ord = new Order(99998, "VINET", 1, 10000);
            int newid = DAL.Insert(ord);
            DAL.StartProgress(newid, new DateTime(2000, 5, 5));
            ord = DAL.Select(newid);
            var actual = ord.status;
            DAL.Delete(newid);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_CustOrderHist()
        {
            var expected = new Tuple<string, int>("Filo Mix", 18);
            List<Tuple<string, int>> buf = DAL.CustOrderHist("VINET");
            var actual = buf[0];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_CustOrderDetail()
        {
            var expected = new Tuple<string, decimal, Int16, int, decimal>("Queso Cabrales",
                14, 12, 0, 168);
            List<Tuple<string, decimal, Int16, int, decimal>> buf = DAL.CustOrderDetail(10248);
            var actual = buf[0];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_ProductName()
        {
            var expected = "Scottish Longbreads";
            var actual = DAL.ProductName(68);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_CustomerName()
        {
            var expected = "Antonio Moreno Taquería";
            var actual = DAL.CustomerName("ANTON");
            Assert.AreEqual(expected, actual);
        }
    }
}
