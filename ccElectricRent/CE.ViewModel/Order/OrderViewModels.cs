using CE.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace CE.ViewModel.Order
{
    public class OrderViewModels
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public string VoucherId { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreateDate { get; set; }
        public List<OrderDetailViewModels> CartDetails { get; set; }
    }
}
