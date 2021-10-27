using Neurosoft.Data.Base;
using Neurosoft.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Neurosoft
{
    public partial class MainWindow : Window
    {
        private string oldTitleRow; 
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(new JsonFileService());
            //SystemColors.HighlightBrush.
        }
        private void dgList_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            oldTitleRow = (e.Row.Item as AdditionalParametersViewModel).Title;
            //var a = (e.Row.Item as AdditionalParametersViewModel).
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
                    if (row.ToLower() == datagrid[i].Title.ToLower() && index != i)
                    {
                        MessageBox.Show("Это имя уже существет");
                        datagrid[index].Title = oldTitleRow;
                        return;
                    }
                    if (row == "")
                    {
                        MessageBox.Show("Поле не может быть пустым!");
                        datagrid[index].Title = oldTitleRow;
                        return;
                    }
                }
            }
        }
    }
}
