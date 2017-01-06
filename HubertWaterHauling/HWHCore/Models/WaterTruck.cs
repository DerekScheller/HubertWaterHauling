using System;
using System.Collections.Generic;

namespace HWHCore.Models
{
    public class WaterTruck : HWHBase
    {
        public string Name { get; set; }
        public DateTime ManufactureYear { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public int LoadVolume { get; set; }
        public virtual List<GasReciept> GasReciepts { get; set; }

    }
}