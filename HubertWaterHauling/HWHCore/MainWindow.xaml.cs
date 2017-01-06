using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HWHCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CompanyDataEditButton_Click(object sender, RoutedEventArgs e)
        {
            var comp = new CompanyDataLanding();
            comp.Show();
            this.Close();
        }

        private void DataEntryButton_Click(object sender, RoutedEventArgs e)
        {
            var acct = new AccountingLanding();
            acct.Show();
            this.Close();
        }

        private void ReportsButton_Click(object sender, RoutedEventArgs e)
        {
            var reps = new ReportsLanding();
            reps.Show();
            this.Close();
        }
    }
}
