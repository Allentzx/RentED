using CE.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace CE.ViewModel.Products
{
    public class ProductItemViewModels
    {
        public int PrlItemId { set; get; }
        public int? ProductId { set; get; }
        public string ProductName { set; get; }
        public ProductItemStatus Status { get; set; }
        public List<ImageProductViewModels> ImageProducts { get; set; }
    }
}
