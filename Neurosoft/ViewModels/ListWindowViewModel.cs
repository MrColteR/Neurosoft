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
    public class ListWindowViewModel : ViewModel
    {
        private int openedItemId;
        //private int index;
        private AdditionalParametersViewModel view;
        #region Команды
        private RelayCommand addCommand;
        private RelayCommand removeCommand;
        private RelayCommand moveUpCommand;
        private RelayCommand moveDownCommand;
        private RelayCommand okCommand;
        //private RelayCommand changeCommand;
        //private RelayCommand closeWindowCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ?? (addCommand = new RelayCommand(obj =>
                {
                    var index = DataList.Count;
                    ListValuesViewModel listParamsItem = new ListValuesViewModel();
                    listParamsItem.ListValue = $"Параметр {index}";
                    DataList.Add(listParamsItem);
                    SelectedDataList = listParamsItem;
                    index++;
                }));
            }
        }
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ?? (removeCommand = new RelayCommand(obj =>
                {
                    ListValuesViewModel listParams = obj as ListValuesViewModel;
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
                    var item = obj as ListValuesViewModel;
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
                    var item = obj as ListValuesViewModel;
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
                    ApplyChange();
                }));
            }
        }
        #endregion
        public void ApplyChange()
        {
            List<string> list = new List<string>();
            if (list != null)
            {
                foreach (var item in DataList)
                {
                    list.Add(item.ListValue);
                }
                view.AdditionalListArr = list;
            }
            else
            {
                view.AdditionalListArr = null;
            }
        }
        private ListValuesViewModel selectedDataList;
        public ListValuesViewModel SelectedDataList
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
        public ObservableCollection<ListValuesViewModel> DataList { get; set; }
        public ListWindowViewModel(AdditionalParametersViewModel viewModel)
        {
            openedItemId = viewModel.Id;
            view = viewModel;
            List<ListValuesViewModel> tmpList = new List<ListValuesViewModel>();
            if (viewModel.AdditionalListArr != null)
            {
                for (int i = 0; i < viewModel.AdditionalListArr.Count; i++)
                {
                    ListValuesViewModel item = new ListValuesViewModel();
                    item.ListValue = viewModel.AdditionalListArr[i];
                    tmpList.Add(item);
                }
                DataList = new ObservableCollection<ListValuesViewModel>(tmpList);
                ListValuesViewModel listValuesView = new ListValuesViewModel(DataList);
            }
            else
            {
                DataList = new ObservableCollection<ListValuesViewModel>(tmpList);
                ListValuesViewModel listValuesView = new ListValuesViewModel(DataList);
            }
        }
    }
}
