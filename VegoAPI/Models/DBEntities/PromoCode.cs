﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace VegoAPI.VegoAPI.Models.DBEntities
{
    public partial class PromoCode
    {
        public PromoCode()
        {
            PromoCodeToOrders = new HashSet<PromoCodeToOrder>();
        }

        public string Code { get; set; }
        public double Discount { get; set; }
        public bool IsActual { get; set; }

        public virtual ICollection<PromoCodeToOrder> PromoCodeToOrders { get; set; }
    }
}