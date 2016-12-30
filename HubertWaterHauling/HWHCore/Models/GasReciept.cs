using System.ComponentModel.DataAnnotations.Schema;

namespace HWHCore.Models
{
    public class GasReciept : HWHBase
    {
        [ForeignKey(nameof(DriverEmployee))]
        public int EmployeeId { get; set; }
        [ForeignKey(nameof(WaterTruck))]
        public int TruckId { get; set; }
        public virtual WaterTruck WaterTruck { get; set; }
        public virtual Employee DriverEmployee { get; set; }
        public decimal RecieptTotal { get; set; }
    }
}
