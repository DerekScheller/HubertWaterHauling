using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace HWHCore.Models
{
    public class Payment : HWHBase, ISearchable, INotifyPropertyChanged
    {
        private PaymentType _paymentType;
        private int? _checkNumber;
        private decimal _paymentAmount;
        private DateTime _paymentRecievedDate;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public PaymentType PaymentType
        {
            get { return _paymentType; }
            set
            {
                _paymentType = value;
                PropertyChanged(this, new PropertyChangedEventArgs("PaymentType"));
                PropertyChanged(this, new PropertyChangedEventArgs("SearchString"));
            }
        }

        public int? CheckNumber
        {
            get { return _checkNumber; }
            set
            {
                _checkNumber = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CheckNumber"));
                PropertyChanged(this, new PropertyChangedEventArgs("SearchString"));
            }
        }

        public decimal PaymentAmount
        {
            get { return _paymentAmount; }
            set
            {
                _paymentAmount = value;
                PropertyChanged(this, new PropertyChangedEventArgs("PaymentAmount"));
            }
        }

        public DateTime PaymentRecievedDate
        {
            get { return _paymentRecievedDate; }
            set
            {
                _paymentRecievedDate = value;
                PropertyChanged(this, new PropertyChangedEventArgs("PaymentRecievedDate"));
                PropertyChanged(this, new PropertyChangedEventArgs("SearchString"));
            }
        }

        public string SearchString => $"{PaymentType} {CheckNumber} {Customer.FirstName} {Customer.LastName} {PaymentRecievedDate}";

        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }

        [ForeignKey(nameof(SaleId))]
        public virtual Sale Sale { get; set; }      
        public int SaleId { get; set; }

        public override string ToString()
        {
            return $"{PaymentType} {Customer.LastName} {PaymentRecievedDate}";
        }
    }

    public enum PaymentType
    {
        Cash,
        DesignatedCheck,
        RegularCheck
    }
}
