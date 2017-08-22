using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task01.Controllers
{
    public class HomeController : Controller
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        private static DbProviderFactory factory = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["Default"].ProviderName);
        private static DAL.NorthwndDAL Dal = new DAL.NorthwndDAL(factory, connectionString);

        public ActionResult Index()
        {
            List<DAL.Order> dalOrders = Dal.TopOrders(0);
            Models.OrderModel[] orders = new Models.OrderModel[dalOrders.Count];
            int i = 0;
            dalOrders.ForEach(delegate (DAL.Order dalOrder)
            {
                orders[i] = new Models.OrderModel();
                orders[i].OrderID =dalOrder.OrderID;

                orders[i].CustomerName = Dal.CustomerName(dalOrder.CustomerID);
                orders[i].OrderDate = dalOrder.OrderDate;
                orders[i].RequiredDate = dalOrder.RequiredDate;
                orders[i].ShippedDate = dalOrder.ShippedDate;
                orders[i].status = dalOrder.status;
                orders[i].Freight = dalOrder.Freight;
                i++;
            });

            return View(orders);
        }

        public ActionResult Open(int id)
        {
            var dalOrder = Dal.Select(id);
            var order = new Models.FullOrderModel();

            order.OrderID = dalOrder.OrderID;            
            order.EmployeeID = dalOrder.EmployeeID;

            order.CustomerID = dalOrder.CustomerID;
            order.CustomerName = Dal.CustomerName(dalOrder.CustomerID);

            order.OrderDate = dalOrder.OrderDate;
            order.RequiredDate = dalOrder.RequiredDate;
            order.ShippedDate = dalOrder.ShippedDate;

            order.status = dalOrder.status;

            order.ShipVia = dalOrder.ShipVia;
            order.ShipName = dalOrder.ShipName;
            order.ShipAddress = dalOrder.ShipAddress;
            order.ShipCity = dalOrder.ShipCity;
            order.ShipRegion = dalOrder.ShipRegion;
            order.ShipPostalCode = dalOrder.ShipPostalCode;
            order.ShipCountry = dalOrder.ShipCountry;
            order.Freight = dalOrder.Freight;

            //order.ProductID;
            //order.ProductName;
            //order.UnitPrice;
            //order.Quantity;
            //order.Discount;

            return View(order);
        }

        public ActionResult About()
        {
            ViewBag.Message = "TASK 13";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Контакты:";

            return View();
        }

        public ActionResult Create()
        {
            return View("About");
        }

        public ActionResult Creating()
        {
            return PartialView("Partial/Create");
        }

        //тестовое представление
        public ActionResult TestView()
        {

            return View();
        }
    }
}