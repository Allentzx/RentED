using CE.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace CE.ViewModel.Order
{
    public class OrderViewModels
    {
        public int OrderId { set; get; }
        public double TotalPrice { get; set; }
        public DateTime CreateDate { set; get; }
        public string UserId { set; get; }
        public int VoucherId { get; set; }
        public OrderStatus Status { get; set; }
    }
}
