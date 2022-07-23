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
        [Required]
        [StringLength(30,MinimumLength =3)]
        public string? ItemName { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string? Brand { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string? Model { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string? Desc { get; set; }
        public string? Img { get; set; }
        [Required]
        [Range(1,double.MaxValue)]
        public decimal? Price { get; set; }
        [Required]
        [Range(1,int.MaxValue)]
        public int? Stock { get; set; }
        public int? CatId { get; set; }
        public int? WarehouseId { get; set; }

        public virtual Category? Cat { get; set; }
        public virtual Warehouse? Warehouse { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
