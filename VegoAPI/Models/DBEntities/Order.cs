﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace VegoAPI.VegoAPI.Models.DBEntities
{
    public partial class Order
    {
        public Order()
        {
            ProductsToOrders = new HashSet<ProductsToOrder>();
        }

        public int Id { get; set; }
        public string PromoCodeId { get; set; }
        public int DeliveryTypeId { get; set; }
        public string ClientName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Comments { get; set; }

        public virtual DeliveryType DeliveryType { get; set; }
        public virtual PromoCode PromoCode { get; set; }
        public virtual ICollection<ProductsToOrder> ProductsToOrders { get; set; }
    }
}