using Neurosoft.ViewModels;
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
    }
}
