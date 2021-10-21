using Neurosoft.Data.Base;
using Neurosoft.ViewModels;
using System.Windows;

namespace Neurosoft
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(new JsonFileService());
        }
    }
}
