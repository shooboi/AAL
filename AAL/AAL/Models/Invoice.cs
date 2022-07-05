using System;
using System.Collections.Generic;

namespace AAL.Models
{
    public partial class Invoice
    {
        public int InvoiceId { get; set; }
        public int? UserId { get; set; }
        public int? OrderId { get; set; }
        public DateTime? DueDate { get; set; }

        public virtual Order? Order { get; set; }
    }
}
