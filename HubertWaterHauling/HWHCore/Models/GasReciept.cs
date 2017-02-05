using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace HWHCore.Models
{
    public class GasReciept : HWHBase, ISearchable, INotifyPropertyChanged
    {
        private decimal _recieptTotal;
        private string _notes;
        private DateTime _dateOnReciept;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public decimal RecieptTotal
        {
            get { return _recieptTotal; }
            set
            {
                _recieptTotal = value;
                PropertyChanged(this, new PropertyChangedEventArgs("RecieptTotal"));
            }
        }

        public string Notes
        {
            get { return _notes; }
            set
            {
                _notes = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Notes"));
                PropertyChanged(this, new PropertyChangedEventArgs("SearchString"));
            }
        }

        public DateTime DateOnReciept
        {
            get { return _dateOnReciept; }
            set
            {
                _dateOnReciept = value;
                PropertyChanged(this, new PropertyChangedEventArgs("DateOnReciept"));
                PropertyChanged(this, new PropertyChangedEventArgs("SearchString"));
            }
        }

        public string SearchString => $"{DriverEmployee.FirstName} {DriverEmployee.LastName} {WaterTruck.Name} {WaterTruck.ManufactureYear} {DateOnReciept} {Notes}";

        public int TruckId { get; set; }
        [ForeignKey(nameof(TruckId))]
        public virtual WaterTruck WaterTruck { get; set; }

        public int EmployeeId { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public virtual Employee DriverEmployee { get; set; }

        public override string ToString()
        {
            return $"{DriverEmployee.FirstName} {WaterTruck.Name} {DateOnReciept}";
        }
    }
}
