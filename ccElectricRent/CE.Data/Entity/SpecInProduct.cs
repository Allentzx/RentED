using System;
using System.Collections.Generic;
using System.Text;

namespace CE.Data.Entity
{
    public class SpecInProduct
    {
        public int ProductId { get; set; }
        public int SpecId { get; set; }
        public Product Product { get; set; }
        public Specific Specific { get; set; }

    }
}
