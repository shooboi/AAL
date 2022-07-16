using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AAL.Models
{
    public partial class Item
    {
        public Item()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ItemId { get; set; }
        public string? ItemName { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string? Desc { get; set; }
        public string? Img { get; set; }
        [Range(0, double.MaxValue)]
        public decimal? Price { get; set; }
        [Range(0, int.MaxValue)]
        public int? Stock { get; set; }
        [Range(0, int.MaxValue)]
        public int? CatId { get; set; }
        [Range(0, int.MaxValue)]
        public int? WarehouseId { get; set; }

        public virtual Category? Cat { get; set; }
        public virtual Warehouse? Warehouse { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
