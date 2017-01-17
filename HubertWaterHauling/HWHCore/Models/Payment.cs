using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HWHCore.Models
{
    public class Payment : HWHBase, ISearchable
    {
        public PaymentType PaymentType { get; set; }     
        public int? CheckNumber { get; set; }
        public decimal PaymentAmount { get; set; }
        public DateTime PaymentRecievedDate { get; set; }


        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }

        [ForeignKey(nameof(SaleId))]
        public virtual Sale Sale { get; set; }      
        public int SaleId { get; set; }

        public override string ToString()
        {
            return $"{PaymentType} {Customer.LastName} {PaymentRecievedDate}";
        }

        public string SearchString()
        {
            return $"{PaymentType} {CheckNumber} {Customer.FirstName} {Customer.LastName} {PaymentRecievedDate}";
        }
    }

    public enum PaymentType
    {
        Cash,
        DesignatedCheck,
        RegularCheck
    }
}
