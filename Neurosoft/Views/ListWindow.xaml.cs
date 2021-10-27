using Neurosoft.ViewModels;
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

namespace Neurosoft.Views
{
    public partial class ListWindow : Window
    {
        public ListWindow(ListWindowViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
        private void btnOkay_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
        private void dgList_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            var index = (sender as DataGrid).SelectedIndex;
            (e.Row.Item as ListValuesViewModel).BeginningEdit(index);
        }
        private void dgList_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            var index = (sender as DataGrid).SelectedIndex;

            var datagrid = (sender as DataGrid).ItemsSource as ObservableCollection<ListValuesViewModel>;
            var str = (e.Row.Item as ListValuesViewModel).RowEditEnding(datagrid, index);
            if (str == "repetition")
            {
                MessageBox.Show("Это имя уже существет");
            }
            else if (str == "empty")
            {
                MessageBox.Show("Поле не может быть пустым!");
            }
        }
    }
}
