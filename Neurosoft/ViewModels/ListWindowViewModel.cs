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
        private AdditionalParametersViewModel view;
        #region Команды
        private RelayCommand addCommand;
        private RelayCommand removeCommand;
        private RelayCommand moveUpCommand;
        private RelayCommand moveDownCommand;
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
        public RelayCommand MoveUpCommand
        {
            get
            {
                return moveUpCommand ?? (moveUpCommand = new RelayCommand(obj =>
                {
                    var item = obj as ListParams;
                    var index = DataList.IndexOf(item);
                    if (index != 0)
                    {
                        var temp = DataList[index - 1];
                        DataList[index - 1] = DataList[index];
                        DataList[index] = temp;
                        SelectedIndex = index - 1;
                    }
                }));
            }
        }
        public RelayCommand MoveDownCommand
        {
            get
            {
                return moveDownCommand ?? (moveDownCommand = new RelayCommand(obj =>
                {
                    var item = obj as ListParams;
                    var index = DataList.IndexOf(item);
                    if (index != DataList.Count - 1)
                    {
                        var temp = DataList[index + 1];
                        DataList[index + 1] = DataList[index];
                        DataList[index] = temp;
                        SelectedIndex = index + 1;
                    }
                }));
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
        private int selectedIndex;
        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                selectedIndex = value;
                OnPropertyChanged(nameof(SelectedIndex));
            }
        }
        public ObservableCollection<ListParams> DataList { get; set; }
        public ListWindowViewModel(List<string> list, int openedItemId, AdditionalParametersViewModel view)
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
