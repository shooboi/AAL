using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AAL.Models
{
    public partial class Order
    {
        public Order()
        {
            Invoices = new HashSet<Invoice>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        [DataType(DataType.Date)]
        public DateTime? OrderDate { get; set; }
        public string? Status { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
