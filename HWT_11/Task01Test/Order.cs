using System;

namespace Task01
{ 
    enum Status {
        NewOrder,
        InProgress,
        Done
    };

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

        public Status status;
        
        public Order(int? orderId, int customerId, int employeeId, decimal freight)
        {
            this.OrderID = orderId;
            this.CustomerID = customerId;
            this.EmployeeID = employeeId;
            this.Freight = freight;

            status = Status.NewOrder;
        }

        public Order(int? orderId, int customerId, int employeeId, decimal freight, DateTime orderDate, DateTime shippedDate)
        {
            this.OrderID = orderId;
            this.CustomerID = customerId;
            this.EmployeeID = employeeId;
            this.OrderDate = orderDate;
            this.ShippedDate = shippedDate;
            this.Freight = freight;

            this.CheckStatus();
        }

        public Order(int? orderId, int customerId, int employeeId, decimal freight, DateTime orderDate, DateTime shippedDate, DateTime requiredDate,
            int? shipVia, string shipName, string shipAddress, string shipCity, string shipRegion, string shipPostalCode, string shipCountry)
        {
            this.OrderID = orderId;
            this.CustomerID = customerId;
            this.EmployeeID = employeeId;
            this.OrderDate = orderDate;
            this.ShippedDate = shippedDate;
            this.RequiredDate = requiredDate;
            this.ShipVia = shipVia;
            this.Freight = freight;
            this.ShipName = shipName;
            this.ShipAddress = shipAddress;
            this.ShipCity = shipCity;
            this.ShipRegion = shipRegion;
            this.ShipPostalCode = shipPostalCode;
            this.ShipCountry = shipCountry;

            this.CheckStatus();
        }

        public void CheckStatus()
        {
            if (this.OrderDate == null)
            {
                this.status = Status.NewOrder;
            }
            else
            {
                if (this.ShippedDate == null)
                {
                    this.status = Status.InProgress;
                }
                else
                {
                    this.status = Status.Done;
                }
            }
        }
    }
}
