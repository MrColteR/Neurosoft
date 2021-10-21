using Neurosoft.Command;
using Neurosoft.Models;
using Neurosoft.ViewModels.Base;
using Neurosoft.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Neurosoft.ViewModels
{
    class ListWindowViewModel : ViewModel
    {
        private int openedItemId;
        private MainWindowViewModel view;
        #region Команды
        private RelayCommand addCommand;
        private RelayCommand removeCommand;
        private RelayCommand okCommand;
        private RelayCommand closeWindowCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ?? (addCommand = new RelayCommand(obj =>
                {
                    ListParams listParamsItem = new ListParams("");
                    DataList.Add(listParamsItem);
                    SelectedDataList = listParamsItem;
                }));
            }
        }
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ?? (removeCommand = new RelayCommand(obj =>
                {
                    ListParams listParams = obj as ListParams;
                    if (listParams != null)
                    {
                        DataList.Remove(listParams);
                    }
                }, (obj) => DataList.Count > 0));
            }
        }
        public RelayCommand OkCommand
        {
            get
            {
                return okCommand ?? (okCommand = new RelayCommand(obj =>
                {
                    List<string> list = new List<string>();
                    if (list != null)
                    {
                        foreach (var item in DataList)
                        {
                            list.Add(item.ItemList);
                        }
                        view.DataList[openedItemId].AdditionalListArr = list;
                    }
                    else
                    {
                        view.DataList[openedItemId].AdditionalListArr = null;
                    }
                    ListWindow wnd = (ListWindow)Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
                    wnd.Close();
                }));
            }
        }
        public RelayCommand CloseWindowCommand
        {
            get
            {
                return closeWindowCommand ?? (closeWindowCommand = new RelayCommand(obj =>
                {
                    ListWindow wnd = (ListWindow)Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
                    wnd.Close();
                }));
            }
        }
        #endregion
        private ListParams selectedDataList;
        public ListParams SelectedDataList
        {
            get { return selectedDataList; }
            set
            {
                selectedDataList = value;
                OnPropertyChanged(nameof(SelectedDataList));
            }
        }
        public ObservableCollection<ListParams> DataList { get; set; }
        public ListWindowViewModel(List<string> list, int openedItemId, MainWindowViewModel view)
        {
            this.openedItemId = openedItemId;
            this.view = view;
            List<ListParams> tmpList = new List<ListParams>();
            if (list != null)
            {
                foreach (var item in list)
                {
                    tmpList.Add(new ListParams(item));
                }
                DataList = new ObservableCollection<ListParams>(tmpList);
            }
            else
            {
                DataList = new ObservableCollection<ListParams>(tmpList);
            }
            
        }
    }
}
