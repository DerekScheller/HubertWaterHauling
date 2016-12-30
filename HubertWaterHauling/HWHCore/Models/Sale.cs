using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HWHCore.Models
{
    public class Sale : HWHBase
    {
        public SaleType SaleType { get; set; }
        public DateTime DateOfSale { get; set; }
        public DateTime? PaymentDueDate { get; set; }
        public bool FullPaymentRecieved { get; set; }
        public decimal DriverRetainagePercent { get; set; } = .3m;
        [ForeignKey(nameof(Bill))]
        public int BillId { get; set; }
        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        [ForeignKey(nameof(Employee))]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Bill Bill { get; set; }   
        public virtual List<Payment> Payments { get; set; }
    }

    public enum SaleType
    {
        Well,
        Pool,
        HotTub,
        Tank,
        Spray,
        Cistern,
        Aerate,
        Other
    }
}
