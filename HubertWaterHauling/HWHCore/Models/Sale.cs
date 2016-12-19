using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWHCore.Models
{
    public class Sale : HWHBase
    {
        public SaleType SaleType { get; set; }
        public float AmountGross { get; set; }
        public DateTime DateOfSale { get; set; }
        public DateTime DateOfPayment { get; set; }
        public float PriceOfWater { get; set; }

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
