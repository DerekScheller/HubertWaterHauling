using System.ComponentModel.DataAnnotations.Schema;

namespace HWHCore.Models
{
    public class ContactInfo : HWHBase
    {
        public ContactInfoType ContactInfoType { get; set; }
        public AssociationType AssociationType { get; set; }
        public string Notes { get; set; }
        public string ContactDetail { get; set; }
        public CustEmp CustEmpDistinction { get; set; }
        public int ContactId { get; set; }      
    }

    public enum AssociationType
    {
        Mobile,
        Home,
        Work,
        Other
    }

    public enum ContactInfoType
    {
        Email,
        Phone,
        Other
    }
}