using CE.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace CE.ViewModel.Order
{
    public class OrderCreateRequest
    {
        public string UserId { get; set; }
        public string VoucherId { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreateDate { get; set; }
        public List<OrderDetailViewModels> OrderDetails { get; set; }
    }
}
