using System.ComponentModel.DataAnnotations.Schema;

namespace HWHCore.Models
{
    public class GasReciept : HWHBase
    {
       
        public int EmployeeId { get; set; }
        
        public int TruckId { get; set; }
        [ForeignKey(nameof(TruckId))]
        public virtual WaterTruck WaterTruck { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public virtual Employee DriverEmployee { get; set; }

        public decimal RecieptTotal { get; set; }
        public string Notes { get; set; }

    }
}
