using System;
using System.Collections.Generic;
using System.Text;

namespace CE.ViewModel.Cart
{
   public class CartDetailViewModels
    {
        public int CartDetailsId { get; set; }
        public int? CartId { get; set; }
        public int? ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
