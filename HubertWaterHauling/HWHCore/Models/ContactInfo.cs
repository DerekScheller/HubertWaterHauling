using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace HWHCore.Models
{
    public class ContactInfo : HWHBase, INotifyPropertyChanged
    {
        private ContactInfoType _contactInfoType;
        private AssociationType _associationType;
        private string _notes;
        private string _contactDetail;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public ContactInfoType ContactInfoType
        {
            get { return _contactInfoType; }
            set
            {
                _contactInfoType = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ContactInfoType"));
            }
        }

        public AssociationType AssociationType
        {
            get { return _associationType; }
            set
            {
                _associationType = value;
                PropertyChanged(this, new PropertyChangedEventArgs("AssociationType"));
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

        public string ContactDetail
        {
            get { return _contactDetail; }
            set
            {
                _contactDetail = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ContactDetail"));
            }
        }

        public int? EmployeeId { get; set; }
        public int? CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public virtual Employee Employee { get; set; }
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