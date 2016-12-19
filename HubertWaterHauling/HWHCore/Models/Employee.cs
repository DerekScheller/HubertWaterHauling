using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HWHCore.Models.Bills.Payable;

namespace HWHCore.Models
{
    public class Employee : HWHBase
    {
        public string DriverFirstName { get; set; }
        public string DriverLastName { get; set; }
        public string MiddleInitial { get; set; }
        public List<ContactInfo> ContactInfos { get; set; }
        public List<Address> Addresses { get; set; }
        public List<GasReciept> GasReciepts { get; set; }
    }
}
