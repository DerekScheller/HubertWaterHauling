using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HWHCore.Models
{
    public class Sale : HWHBase, ISearchable
    {
        public SaleType SaleType { get; set; }
        public DateTime DateOfSale { get; set; }
        public DateTime? PaymentDueDate { get; set; }
        public bool FullPaymentRecieved { get; set; }
        public decimal DriverRetainagePercent { get; set; } = 30.0m;
        public decimal PriceOfWater { get; set; }
        public int LoadVolume { get; set; }
        public int NumberOfLoads { get; set; }
        public decimal? PriceNet { get; set; }
        public decimal? GrossAmount { get; set; }

        public virtual List<Payment> Payments { get; set; }

        public int EmployeeId { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public virtual Employee Employee { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }

        public int TruckId { get; set; }
        [ForeignKey(nameof(TruckId))]
        public virtual WaterTruck WaterTruck { get; set; }

        public override string ToString()
        {
            return $"{SaleType} {Customer.LastName} {DateOfSale}";
        }

        public string SearchString()
        {
            return
                $"{SaleType} {DateOfSale} {Employee.FirstName} {Employee.LastName} {Customer.FirstName} {Customer.LastName} {WaterTruck.Name} {WaterTruck.Make} {WaterTruck.Model}";
        }
    }

    public enum SaleType
    {
        Well,
        Pool,
        HotTub,
        Tank,
        Spray,
        Cistern,
        Aerate,
        Other
    }
}
