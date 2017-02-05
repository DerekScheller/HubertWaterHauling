using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace HWHCore.Models
{
    public class Address : HWHBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private string _addressStreet1;
        private string _addressStreet2;
        private string _addressStreet3;
        private string _city;
        private string _state;
        private string _zip;
        private string _country;
        private AddressType _addressType;

        public string AddressStreet1
        {
            get { return _addressStreet1; }
            set
            {
                _addressStreet1 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("AddressStreet1"));
            }
        }

        public string AddressStreet2
        {
            get { return _addressStreet2; }
            set
            {
                _addressStreet2 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("AddressStreet2"));
            }
        }

        public string AddressStreet3
        {
            get { return _addressStreet3; }
            set
            {
                _addressStreet3 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("AddressStreet3"));
            }
        }

        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                PropertyChanged(this, new PropertyChangedEventArgs("City"));
            }
        }

        public string State
        {
            get { return _state; }
            set
            {
                _state = value;
                PropertyChanged(this, new PropertyChangedEventArgs("State"));
            }
        }

        public string Zip
        {
            get { return _zip; }
            set
            {
                _zip = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Zip"));
            }
        }

        public string Country
        {
            get { return _country; }
            set
            {
                _country = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Country"));
            }
        }

        public AddressType AddressType
        {
            get { return _addressType; }
            set
            {
                _addressType = value;
                PropertyChanged(this, new PropertyChangedEventArgs("AddressType"));
            }
        }

        public int? CustomerId { get; set; }
        public int? EmployeeId { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public virtual Employee Employee { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }

        public override string ToString()
        {
            return AddressType.ToString();
        }
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