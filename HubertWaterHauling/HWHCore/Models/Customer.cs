using System.Collections.Generic;
using System.ComponentModel;


namespace HWHCore.Models
{
    public class Customer : HWHBase, ISearchable, INotifyPropertyChanged
    {
        private string _description;
        private string _firstName;
        private string _lastName;
        private string _middleInitial;
        private bool _isActive;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public virtual List<Payment> Payments { get; set; }
        public virtual List<Sale> Sales { get; set; }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Description"));
            }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("FirstName"));
                PropertyChanged(this, new PropertyChangedEventArgs("SearchString"));
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("LastName"));
                PropertyChanged(this, new PropertyChangedEventArgs("SearchString"));
            }
        }

        public string MiddleInitial
        {
            get { return _middleInitial; }
            set
            {
                _middleInitial = value;
                PropertyChanged(this, new PropertyChangedEventArgs("MiddleInitial"));
            }
        }

        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                _isActive = value;
                PropertyChanged(this, new PropertyChangedEventArgs("IsActive"));
            }
        }

        public virtual List<ContactInfo> ContactInfos { get; set; }
        public virtual List<Address> Addresses { get; set; }
        public string SearchString => $"{FirstName} {LastName} {Addresses[0].AddressStreet1} {Addresses[0].City} {Addresses[0].State}";

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}