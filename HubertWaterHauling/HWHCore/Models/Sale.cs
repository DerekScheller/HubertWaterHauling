using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace HWHCore.Models
{
    public class Sale : HWHBase, ISearchable, INotifyPropertyChanged
    {
        private SaleType _saleType;
        private DateTime _dateOfSale;
        private DateTime? _paymentDueDate;
        private bool _fullPaymentRecieved;
        private decimal _driverRetainagePercent = 30.0m;
        private decimal _priceOfWater;
        private int _loadVolume;
        private int _numberOfLoads;
        private decimal? _priceNet;
        private decimal? _grossAmount;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public SaleType SaleType
        {
            get { return _saleType; }
            set
            {
                _saleType = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SaleType"));
                PropertyChanged(this, new PropertyChangedEventArgs("SearchString"));
            }
        }

        public DateTime DateOfSale
        {
            get { return _dateOfSale; }
            set
            {
                _dateOfSale = value;
                PropertyChanged(this, new PropertyChangedEventArgs("DateOfSale"));
                PropertyChanged(this, new PropertyChangedEventArgs("SearchString"));
            }
        }

        public DateTime? PaymentDueDate
        {
            get { return _paymentDueDate; }
            set
            {
                _paymentDueDate = value;
                PropertyChanged(this, new PropertyChangedEventArgs("PaymentDueDate"));
            }
        }

        public bool FullPaymentRecieved
        {
            get { return _fullPaymentRecieved; }
            set
            {
                _fullPaymentRecieved = value;
                PropertyChanged(this, new PropertyChangedEventArgs("FullPaymentRecieved"));
            }
        }

        public decimal DriverRetainagePercent
        {
            get { return _driverRetainagePercent; }
            set
            {
                _driverRetainagePercent = value;
                PropertyChanged(this, new PropertyChangedEventArgs("DriverRetainagePercent"));
            }
        }

        public decimal PriceOfWater
        {
            get { return _priceOfWater; }
            set
            {
                _priceOfWater = value;
                PropertyChanged(this, new PropertyChangedEventArgs("PriceOfWater"));
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

        public int NumberOfLoads
        {
            get { return _numberOfLoads; }
            set
            {
                _numberOfLoads = value;
                PropertyChanged(this, new PropertyChangedEventArgs("NumberOfLoads"));
            }
        }

        public decimal? PriceNet
        {
            get { return _priceNet; }
            set
            {
                _priceNet = value;
                PropertyChanged(this, new PropertyChangedEventArgs("PriceNet"));
            }
        }

        public decimal? GrossAmount
        {
            get { return _grossAmount; }
            set
            {
                _grossAmount = value;
                PropertyChanged(this, new PropertyChangedEventArgs("GrossAmount"));
            }
        }

        public string SearchString => $"{SaleType} {DateOfSale} {Employee.FirstName} {Employee.LastName} {Customer.FirstName} {Customer.LastName} {WaterTruck.Name} {WaterTruck.Make} {WaterTruck.Model}";
        public virtual List<Payment> Payments { get; set; }

        public int EmployeeId { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public virtual Employee Employee { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }

        public int TruckId { get; set; }
        [ForeignKey(nameof(TruckId))]
        public virtual WaterTruck WaterTruck { get; set; }

        public override string ToString()
        {
            return $"{SaleType} {Customer.LastName} {DateOfSale}";
        }

    }

    public enum SaleType
    {
        Well,
        Pool,
        HotTub,
        Tank,
        Spray,
        Cistern,
        Aerate,
        Other
    }
}
