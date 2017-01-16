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
        public int BillId { get; set; }       
        public int CustomerId { get; set; }       
        public int EmployeeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public virtual Employee Employee { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }
        [ForeignKey(nameof(BillId))]
        public virtual Bill Bill { get; set; }   
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
