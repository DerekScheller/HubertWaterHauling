using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using HWHCore.Models;

namespace HWHCore.CustomControls
{
    /// <summary>
    /// Interaction logic for QuickSearchSelect.xaml
    /// </summary>
    public partial class QuickSearchSelect : UserControl
    {
        public QuickSearchSelect(ISearchable items)
        {
            Items = CollectionViewSource.GetDefaultView(items);
            InitializeComponent();
        }
        private HWHBase _selectedItem;

        public ICollectionView Items { get; }

        public HWHBase SelectedItem
        {
            get { return this._selectedItem; }
            set
            {
                if (_selectedItem != value)
                {
                    this._selectedItem = value;
                }
            }
        }
    }
}
