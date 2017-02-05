using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HWHCore.Models
{
    public class Employee : HWHBase, ISearchable, INotifyPropertyChanged
    {
        private DateTime _hireDate;
        private DateTime? _dateTerminated;
        private string _notes;
        private string _title;
        private string _firstName;
        private string _lastName;
        private string _middleInitial;
        private bool _isActive;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public DateTime HireDate
        {
            get { return _hireDate; }
            set
            {
                _hireDate = value;
                PropertyChanged(this, new PropertyChangedEventArgs("HireDate"));
            }
        }

        public DateTime? DateTerminated
        {
            get { return _dateTerminated; }
            set
            {
                _dateTerminated = value;
                PropertyChanged(this, new PropertyChangedEventArgs("DateTerminated"));
            }
        }

        public string Notes
        {
            get { return _notes; }
            set
            {
                _notes = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Notes"));
            }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Title"));
            }
        }

        public virtual List<GasReciept> GasReciepts { get; set; }
        public virtual List<Sale> Sales { get; set; }

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
