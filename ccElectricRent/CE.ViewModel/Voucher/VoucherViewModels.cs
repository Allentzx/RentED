using System;
using System.Collections.Generic;
using System.Text;

namespace CE.ViewModel.Voucher
{
   public class VoucherViewModels
    {

        public int? VoucherId { set; get; }
        public string VoucherName { set; get; }
        public float SaleOff { set; get; }
        public DateTime StartDate { set; get; }
        public DateTime FinishDate { set; get; }
    }
}
