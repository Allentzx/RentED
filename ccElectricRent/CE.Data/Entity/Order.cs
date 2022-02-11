﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CE.Data.Entity
{
   public class Order
    {
        public int OrderId { set; get; }
        public decimal TotalPrice { get; set; }
        public DateTime CreateDate { set; get; }
        public Guid UserId { set; get; }
        public int VoucherId { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }



    }
}
