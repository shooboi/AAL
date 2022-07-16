using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AAL.Models
{
    public partial class Invoice
    {
        public int InvoiceId { get; set; }
        [Range(0, int.MaxValue)]
        public int? UserId { get; set; }
        [Range(0, int.MaxValue)]
        public int? OrderId { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; }

        public virtual Order? Order { get; set; }
    }
}
