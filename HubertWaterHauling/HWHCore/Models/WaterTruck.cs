using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HWHCore.Models
{
    public class WaterTruck : HWHBase, ISearchable, INotifyPropertyChanged
    {
        private string _name;
        private DateTime _manufactureYear;
        private DateTime? _purchaseDate;
        private string _model;
        private string _make;
        private int _loadVolume;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Name"));
                PropertyChanged(this, new PropertyChangedEventArgs("SearchString"));
            }
        }

        public DateTime ManufactureYear
        {
            get { return _manufactureYear; }
            set
            {
                _manufactureYear = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ManufactureYear"));
                PropertyChanged(this, new PropertyChangedEventArgs("SearchString"));
            }
        }

        public DateTime? PurchaseDate
        {
            get { return _purchaseDate; }
            set
            {
                _purchaseDate = value;
                PropertyChanged(this, new PropertyChangedEventArgs("PurchaseDate"));
            }
        }

        public string Model
        {
            get { return _model; }
            set
            {
                _model = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Model"));
                PropertyChanged(this, new PropertyChangedEventArgs("SearchString"));
            }
        }

        public string Make
        {
            get { return _make; }
            set
            {
                _make = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Make"));
                PropertyChanged(this, new PropertyChangedEventArgs("SearchString"));
            }
        }

        public int LoadVolume
        {
            get { return _loadVolume; }
            set
            {
                _loadVolume = value;
                PropertyChanged(this, new PropertyChangedEventArgs("LoadVolume"));
            }
        }

        public virtual List<GasReciept> GasReciepts { get; set; }
        public virtual List<Sale> Sales { get; set; }
        public string SearchString => $"{Name} {Model} {Make} {ManufactureYear}";
        public override string ToString()
        {
            return $"{Name} {Model} {Make}";
        }
    }
}