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
            //SystemColors.HighlightBrush.
        }
        private void dgList_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            var index = (sender as DataGrid).SelectedIndex;
            (e.Row.Item as AdditionalParametersViewModel).BeginningEdit(index);
        }
        private void dgList_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            var datagrid = (sender as DataGrid).ItemsSource as ObservableCollection<AdditionalParametersViewModel>;
            var str = (e.Row.Item as AdditionalParametersViewModel).RowEditEnding(datagrid);
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
