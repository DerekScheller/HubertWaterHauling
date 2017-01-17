using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HWHCore.Models
{
    public class GasReciept : HWHBase, ISearchable
    {
        public decimal RecieptTotal { get; set; }
        public string Notes { get; set; }
        public DateTime DateOnReciept { get; set; }
        

        public int TruckId { get; set; }
        [ForeignKey(nameof(TruckId))]
        public virtual WaterTruck WaterTruck { get; set; }

        public int EmployeeId { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public virtual Employee DriverEmployee { get; set; }

        public override string ToString()
        {
            return $"{DriverEmployee.FirstName} {WaterTruck.Name} {DateOnReciept}";
        }

        public string SearchString()
        {
            return
                $"{DriverEmployee.FirstName} {DriverEmployee.LastName} {WaterTruck.Name} {WaterTruck.ManufactureYear} {DateOnReciept} {Notes}";
        }
    }
}
