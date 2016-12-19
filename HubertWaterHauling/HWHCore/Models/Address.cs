namespace HWHCore.Models
{
    public class Address : HWHBase
    {
        public string AddressStreet1 { get; set; }
        public string AddressStreet2 { get; set; }
        public string AddressStreet3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public AddressType AddressType { get; set; }
    }

    public enum AddressType
    {
        Shipping,
        Billing,
        Mailing,
        Home,
        Work,
        SecondProperty,
        Other
    }
}