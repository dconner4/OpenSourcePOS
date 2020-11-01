using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class ReceiptPayment
    {
        public long Id { get; set; }

        public PaymentType PaymentType { get; set; }

        public double AmountPaid { get; set; }
    }
}
