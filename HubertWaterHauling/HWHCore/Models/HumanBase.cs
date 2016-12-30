using System.Collections.Generic;

namespace HWHCore.Models
{
    public abstract class HumanBase : HWHBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleInitial { get; set; }
        public bool IsActive { get; set; }
        public virtual List<ContactInfo> ContactInfos { get; set; }
        public virtual List<Address> Addresses { get; set; }
    }
}
