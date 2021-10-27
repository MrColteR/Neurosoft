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
        private string oldlistValue;
        private int oldID;
        public string ListValue
        {
            get { return listValue; }
            set
            {
                listValue = value;
                OnPropertyChanged(nameof(ListValue));
            }
        }
        public void BeginningEdit(int index)
        {
            oldlistValue = ListValue;
            oldID = index;
        }
        public string RowEditEnding(ObservableCollection<ListValuesViewModel> datagrid, int index)
        {
            for (int i = 0; i < datagrid.Count; i++)
            {
                if (listValue.ToLower() == datagrid[i].ListValue.ToLower() && oldID != i)
                {
                    datagrid[oldID].ListValue = oldlistValue;
                    return "repetition";
                }
                if (listValue == "")
                {
                    datagrid[oldID].ListValue = oldlistValue;
                    return "empty";
                }
            }
            return null;
        }
        public ObservableCollection<ListValuesViewModel> DataList { get; set; }
        public ListValuesViewModel() { }
        public ListValuesViewModel(ObservableCollection<ListValuesViewModel> data)
        {
            DataList = data;
        }
    }
}
