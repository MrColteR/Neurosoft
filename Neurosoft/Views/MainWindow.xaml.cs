using Neurosoft.Data.Base;
using Neurosoft.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Neurosoft
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(new JsonFileService());
        }
        private void dgList_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (dgList != null)
            {
                var row = (e.Row.Item as AdditionalParametersViewModel).Title;
                var index = (e.Row.Item as AdditionalParametersViewModel).Id;
                var datagrid = (sender as DataGrid).ItemsSource as ObservableCollection<AdditionalParametersViewModel>;
                for (int i = 0; i < datagrid.Count; i++)
                {
                    if (row == datagrid[i].Title && index != i)
                    {
                        MessageBox.Show("Это имя уже существет");
                        datagrid[index].Title = "ааа";
                        return;
                    }
                    if (row == "")
                    {
                        MessageBox.Show("Поле не может быть пустым!");
                        datagrid[index].Title = "Параметр";
                        return;
                    }
                }
            }
        }
        public static void ItemNotSelectedWarning()
        {
            MessageBox.Show("Выберите элемент");
        }
    }
}
