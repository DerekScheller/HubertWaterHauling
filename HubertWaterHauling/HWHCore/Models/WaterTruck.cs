using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HWHCore.Models.Bills.Payable;

namespace HWHCore.Models
{
    public class WaterTruck : HWHBase
    {
        public string Name { get; set; }
        public DateTime ManufactureYear { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string Model { get; set; }
        public List<GasReciept> GasReciepts { get; set; }
    }
}
