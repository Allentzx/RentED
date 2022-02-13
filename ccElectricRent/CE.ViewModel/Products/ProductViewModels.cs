using System;
using System.Collections.Generic;
using System.Text;

namespace CE.ViewModel.Products
{
    public class ProductViewModels
    {
        public int productId { set; get; }
        public int CatagoryId { set; get; }
        public string ProductName { set; get; }
        public int Quantity { set; get; }
        public string Description { set; get; }
        public decimal Price { set; get; }
        public string Thumbnail { get; set; }

        //public List<string> Categories { get; set; } = new List<string>();
    }
}
