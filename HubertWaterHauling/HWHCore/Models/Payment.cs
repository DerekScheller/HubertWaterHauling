using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWHCore.Models
{
    public class Payment : HWHBase
    {
        public PaymentType PaymentType { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int CheckNumber { get; set; }
        public float PaymentAmount { get; set; }
    }

    public enum PaymentType
    {
        Cash,
        DesignatedCheck,
        RegularCheck
    }
}
