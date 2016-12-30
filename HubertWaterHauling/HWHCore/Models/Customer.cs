using System.Collections.Generic;


namespace HWHCore.Models
{
    public class Customer : HumanBase
    {
        public virtual List<Payment> Payments { get; set; }
        public string Description { get; set; }
    }
}