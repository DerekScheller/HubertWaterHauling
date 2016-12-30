using System.Collections.Generic;

namespace HWHCore.Models
{
    public class Bill : HWHBase
    {
        public decimal PriceOfWater { get; set; }
        public virtual List<LoadOfWater> Loads { get; set; }
    }
}