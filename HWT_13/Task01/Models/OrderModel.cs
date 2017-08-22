using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task01.Models
{
    public class OrderModel
    {
        public int? OrderID { get; set; }

        [Display(Name = "Заказчик")]
        public string CustomerName { get; set; }
        [Display(Name = "Дата заказа")]
        public DateTime? OrderDate { get; set; }
        [Display(Name = "Ожидаемая дата")]
        public DateTime? RequiredDate { get; set; }
        [Display(Name = "Дата доставки")]
        public DateTime? ShippedDate { get; set; }
        [Display(Name = "Статус")]
        public Status status { get; set; }
        [Display(Name = "Стоимость доставки")]
        public decimal? Freight { get; set; }
    }
}