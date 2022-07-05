using System;
using System.Collections.Generic;

namespace AAL.Models
{
    public partial class Warehouse
    {
        public Warehouse()
        {
            Items = new HashSet<Item>();
        }

        public int WarehouseId { get; set; }
        public string? WarehouseName { get; set; }
        public string? WarehouseAddress { get; set; }
        public string? WarehouseContact { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
