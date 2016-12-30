using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWHCore.Models
{
    public class LoadOfWater : HWHBase
    {
        public int LoadVolume { get; set; }
        [ForeignKey(nameof(Bill))]
        public int BillId { get; set; }
        [ForeignKey(nameof(WaterTruck))]
        public int TruckId { get; set; }
        public virtual Bill Bill { get; set; }
        public virtual WaterTruck WaterTruck { get; set; }
    }
}
