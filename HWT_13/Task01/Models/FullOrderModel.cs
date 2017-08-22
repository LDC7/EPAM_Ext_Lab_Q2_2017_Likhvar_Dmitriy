using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task01.Models
{
    public class FullOrderModel
    {
        public int? OrderID { get; set; }

        public int? EmployeeID { get; set; }
        public string EmployeeName { get; set; }

        public string CustomerID { get; set; }
        public string CustomerName { get; set; }

        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }

        public Status status { get; set; }

        public int? ShipVia { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
        public decimal? Freight { get; set; }

        //public int ProductID { get; set; }
        //public string ProductName { get; set; }
        //public decimal UnitPrice { get; set; }
        //public Int16 Quantity { get; set; }
        //public double Discount { get; set; }
        public Tuple<int, string, decimal, Int16, double>[] Details { get; set; }
        public double Price { get; set; }
    }
}