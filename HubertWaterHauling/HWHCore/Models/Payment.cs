using System.ComponentModel.DataAnnotations.Schema;

namespace HWHCore.Models
{
    public class Payment : HWHBase
    {
        public PaymentType PaymentType { get; set; }
        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Sale Sale { get; set; }
        [ForeignKey(nameof(Sale))]
        public int SaleId { get; set; }
        public int? CheckNumber { get; set; }
        public decimal PaymentAmount { get; set; }
    }

    public enum PaymentType
    {
        Cash,
        DesignatedCheck,
        RegularCheck
    }
}
