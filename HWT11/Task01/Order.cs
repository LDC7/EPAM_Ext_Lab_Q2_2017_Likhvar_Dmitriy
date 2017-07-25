namespace Task01
{
    using System;

    class Order
    {
        public int? OrderID;
        public int? CustomerID;
        public int? EmployeeID;
        public DateTime OrderDate;
        public DateTime RequiredDate;
        public DateTime ShippedDate;
        public int? ShipVia;
        public decimal? Freight;
        public string ShipName;
        public string ShipAddress;
        public string ShipCity;
        public string ShipRegion;
        public string ShipPostalCode;
        public string ShipCountry;
    }
}
