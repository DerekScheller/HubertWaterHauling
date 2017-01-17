using System.Collections.Generic;

namespace HWHCore.Models
{
    public abstract class HumanBase : HWHBase, ISearchable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleInitial { get; set; }
        public bool IsActive { get; set; }
        public virtual List<ContactInfo> ContactInfos { get; set; }
        public virtual List<Address> Addresses { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

        public string SearchString()
        {
            return $"{FirstName} {LastName} {Addresses[0].AddressStreet1} {Addresses[0].City} {Addresses[0].State}";
        }
    }
}
