using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class ReceiptHeader
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public double SubTotal { get; set; }

        [Required]
        public double TotalTax { get; set; }

        [Required]
        public double Total { get; set; }

        [Required]
        public IEnumerable<SaleItem> ReceiptItems { get; set; }

        [Required]
        public IEnumerable<ReceiptPayment> ReceiptPayments { get; set; }
    }
}
