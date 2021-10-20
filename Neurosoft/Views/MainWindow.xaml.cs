using Neurosoft.Data.Base;
using Neurosoft.ViewModels;
using System.Windows;

namespace Neurosoft
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(new JsonFileService());
        }
    }
}
