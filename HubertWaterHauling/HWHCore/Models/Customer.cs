using System.Collections.Generic;


namespace HWHCore.Models
{
    public class Customer : HumanBase, ISearchable
    {
        public virtual List<Payment> Payments { get; set; }
        public virtual List<Sale> Sales { get; set; }
        public string Description { get; set; }
    }
}