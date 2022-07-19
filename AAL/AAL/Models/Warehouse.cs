using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AAL.Models
{
    public partial class Warehouse
    {
        public Warehouse()
        {
            Items = new HashSet<Item>();
        }

        public int WarehouseId { get; set; }
        [Required]
        [StringLength(30,MinimumLength =3)]
        public string? WarehouseName { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string? WarehouseAddress { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string? WarehouseContact { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
