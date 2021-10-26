using Neurosoft.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neurosoft.ViewModels
{
    public class ListValuesViewModel : ViewModel
    {
        private string listValue;
        public string ListValue
        {
            get { return listValue; }
            set
            {
                listValue = value;
                OnPropertyChanged(nameof(ListValue));
            }
        }
        public ObservableCollection<ListValuesViewModel> DataList { get; set; }
        public ListValuesViewModel() { }
        public ListValuesViewModel(ObservableCollection<ListValuesViewModel> data)
        {
            DataList = data;
        }
    }
}
