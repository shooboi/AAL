using System;
using System.Collections.Generic;

namespace AAL.Models
{
    public partial class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int? OrderId { get; set; }
        public decimal? TotalPrice { get; set; }
        public int? Quantity { get; set; }
        public int? ItemId { get; set; }

        public virtual Item? Item { get; set; }
        public virtual Order? Order { get; set; }
    }
}
