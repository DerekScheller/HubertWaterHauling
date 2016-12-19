using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWHCore.Models
{
    public class Customer : HWHBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleInitial { get; set; }
        public List<ContactInfo> ContactInfos { get; set; }
        public List<Address> Addresses { get; set; }
        public string Notes { get; set; }
    }
}
