using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HWHCore.Models
{
    public class Bill : HWHBase
    {
        public decimal PriceOfWater { get; set; }
        public int LoadVolume { get; set; }
        public int NumberOfLoads { get; set; }
        public decimal? PriceNet { get; set; }
        public decimal? GrossAmount { get; set; }
        public decimal DriverRetainagePercent { get; set; } = 3m;
       
        public int TruckId { get; set; }
        [ForeignKey(nameof(TruckId))]
        public virtual WaterTruck WaterTruck { get; set; }
        public virtual List<Payment> Payments { get; set; }
    }
}