using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AAL.Models
{
    public partial class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int? OrderId { get; set; }
        [Range(0, double.MaxValue)]
        public decimal? TotalPrice { get; set; }
        [Range(0, int.MaxValue)]
        public int? Quantity { get; set; }
        [Range(0, int.MaxValue)]
        public int? ItemId { get; set; }

        public virtual Item? Item { get; set; }
        public virtual Order? Order { get; set; }
    }
}
