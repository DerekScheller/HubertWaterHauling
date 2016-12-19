using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWHCore.Models.Bills.Payable
{
    public class GasReciept : BillBase
    {
        public int DriverId { get; set; }
        public int TruckId { get; set; }
        public WaterTruck WaterTruck { get; set; }
        public Employee DriverEmployee { get; set; }

    }
}
