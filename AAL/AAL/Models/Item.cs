using System;
using System.Collections.Generic;

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
        public decimal? Price { get; set; }
        public int? Stock { get; set; }
        public int? CatId { get; set; }
        public int? WarehouseId { get; set; }

        public virtual Category? Cat { get; set; }
        public virtual Warehouse? Warehouse { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
