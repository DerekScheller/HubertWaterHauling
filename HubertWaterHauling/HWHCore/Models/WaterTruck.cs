using System;
using System.Collections.Generic;

namespace HWHCore.Models
{
    public class WaterTruck : HWHBase, ISearchable
    {
        public string Name { get; set; }
        public DateTime ManufactureYear { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public int LoadVolume { get; set; }
        public virtual List<GasReciept> GasReciepts { get; set; }
        public virtual List<Sale> Sales { get; set; }

        public override string ToString()
        {
            return $"{Name} {Model} {Make}";
        }

        public string SearchString()
        {
            return $"{Name} {Model} {Make} {ManufactureYear}";
        }
    }
}