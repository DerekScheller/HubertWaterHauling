using System;
using System.Collections.Generic;

namespace HWHCore.Models
{
    public class Employee : HumanBase
    {
        public DateTime HireDate { get; set; }
        public DateTime? DateTerminated { get; set; }
        public string Notes { get; set; }
        public string Title { get; set; }
        public virtual List<GasReciept> GasReciepts { get; set; }
        public virtual List<Sale> Sales { get; set; }
    }
}
