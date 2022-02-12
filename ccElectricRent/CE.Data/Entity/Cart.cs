using System;
using System.Collections.Generic;
using System.Text;

namespace CE.Data.Entity
{
    public class Cart
    {
        public int CartId { set; get; }
        public Guid UserId { set; get; }
        public List<CartDetail> CartDetails { get; set; }
        public AppUser AppUser { get; set; }
    }
}
