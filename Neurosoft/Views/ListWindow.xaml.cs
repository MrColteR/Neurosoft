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
        private void dgList_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (dgList != null)
            {
                var row = (e.Row.Item as ListValuesViewModel).ListValue;
                var index = (sender as DataGrid).SelectedIndex;
                var datagrid = (sender as DataGrid).ItemsSource as ObservableCollection<ListValuesViewModel>;
                for (int i = 0; i < datagrid.Count; i++)
                {
                    if (row == datagrid[i].ListValue && index != i)
                    {
                        MessageBox.Show("Это имя уже существет");
                        datagrid[index].ListValue = "";
                        return;
                    }
                    if (row == "")
                    {
                        MessageBox.Show("Поле не может быть пустым!");
                        datagrid[index].ListValue = "Параметр";
                        return;
                    }
                }
            }
        }
    }
}
