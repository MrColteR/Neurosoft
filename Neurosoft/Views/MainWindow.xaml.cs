using Neurosoft.Data.Base;
using Neurosoft.ViewModels;
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
                var viewModel = DataContext as MainWindowViewModel;
                var row = viewModel.SelectedDataList;
                var dataGrid = viewModel.DataList;
                var index = viewModel.SelectedIndex;
                for (int i = 0; i < dataGrid.Count; i++)
                {
                    if (row.Title == dataGrid[i].Title && index != i)
                    {
                        MessageBox.Show("Это имя уже существет");
                        dataGrid[i].Title = "";
                        return;
                    }
                }
            }
        }
    }
}
