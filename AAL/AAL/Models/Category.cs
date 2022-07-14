using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AAL.Models
{
    public partial class Category
    {
        public Category()
        {
            InverseCatParent = new HashSet<Category>();
            Items = new HashSet<Item>();
        }
        public int CatId { get; set; }
        [Required]
        [StringLength(30,MinimumLength =3)]
        public string? CatName { get; set; }
        public int? CatParentId { get; set; }

        public virtual Category? CatParent { get; set; }
        public virtual ICollection<Category> InverseCatParent { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
