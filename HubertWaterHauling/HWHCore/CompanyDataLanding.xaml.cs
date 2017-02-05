using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HWHCore.Models;

namespace HWHCore
{
    /// <summary>
    /// Interaction logic for CompanyDataLanding.xaml
    /// </summary>
    public partial class CompanyDataLanding : Window
    {
        public CompanyDataLanding()
        {
            InitializeComponent();
            using (var context = new HWHContext())
            {
                Drivers = new ObservableCollection<Employee>(context.Employees);
                
            }
            SelectedDriver = Drivers[0];
        }


        public ObservableCollection<Employee> Drivers
        {
            get { return (ObservableCollection<Employee>)GetValue(DriversProperty); }
            set { SetValue(DriversProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Drivers.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DriversProperty =
            DependencyProperty.Register("Drivers", typeof(ObservableCollection<Employee>), typeof(CompanyDataLanding), new PropertyMetadata(null));

        public Employee SelectedDriver{
            get { return (Employee)GetValue(SelectedDriverProperty); }
            set { SetValue(SelectedDriverProperty, value); }
        }

        public Address SelectedAddress
        {
            get { return (Address) GetValue(SelectedAddressProperty); }
            set { SetValue(SelectedAddressProperty, value); }
        }

        public ContactInfo SelectedContactInfo
        {
            get { return (ContactInfo) GetValue(SelectedContactInfoProperty); }
            set { SetValue(SelectedContactInfoProperty, value); }
        }

        public ObservableCollection<WaterTruck> Trucks
        {
            get { return (ObservableCollection<WaterTruck>) GetValue(TrucksProperty); }
            set { SetValue(TrucksProperty, value); }
        }

        public WaterTruck SelectedTruck
        {
            get { return (WaterTruck) GetValue(SelectedTruckProperty); }
            set { SetValue(SelectedTruckProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedDriver.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedDriverProperty =
            DependencyProperty.Register("SelectedDriver", typeof(Employee), typeof(CompanyDataLanding), new PropertyMetadata(null));

        public static readonly DependencyProperty SelectedAddressProperty = DependencyProperty.Register("SelectedAddress", typeof(Address), typeof(CompanyDataLanding), new PropertyMetadata(default(Address)));
        public static readonly DependencyProperty SelectedContactInfoProperty = DependencyProperty.Register("SelectedContactInfo", typeof(ContactInfo), typeof(CompanyDataLanding), new PropertyMetadata(default(ContactInfo)));
        public static readonly DependencyProperty TrucksProperty = DependencyProperty.Register("Trucks", typeof(ObservableCollection<WaterTruck>), typeof(CompanyDataLanding), new PropertyMetadata(null));
        public static readonly DependencyProperty SelectedTruckProperty = DependencyProperty.Register("SelectedTruck", typeof(WaterTruck), typeof(CompanyDataLanding), new PropertyMetadata(default(WaterTruck)));

        private void CurrentDrivers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
