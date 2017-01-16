using System.ComponentModel.DataAnnotations.Schema;

namespace HWHCore.Models
{
    public class Payment : HWHBase
    {
        public PaymentType PaymentType { get; set; }     
        public int? CheckNumber { get; set; }
        public decimal PaymentAmount { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }

        [ForeignKey(nameof(BillId))]
        public virtual Bill Bill { get; set; }      
        public int BillId { get; set; }
    }

    public enum PaymentType
    {
        Cash,
        DesignatedCheck,
        RegularCheck
    }
}
