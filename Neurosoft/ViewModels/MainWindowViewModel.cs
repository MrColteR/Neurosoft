﻿using System;
using System.IO;
using Neurosoft.Command;
using Neurosoft.ViewModels.Base;
using System.Collections.ObjectModel;
using Neurosoft.Models;
using Neurosoft.Data.Base;
using Neurosoft.Views;
using System.Windows;

namespace Neurosoft.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        private static string path = Directory.GetCurrentDirectory();
        public readonly string fileName = path.Substring(0, path.IndexOf("bin"))+"List.json";
        IFileService fileService;
        #region Команды
        private RelayCommand addCommand;
        private RelayCommand removeCommand;
        private RelayCommand moveUpCommand;
        private RelayCommand moveDownCommand;
        //private RelayCommand openSecondWindow;
        private RelayCommand saveCommand;
        private RelayCommand closeWindowCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ?? (addCommand = new RelayCommand(obj =>
                {
                    AdditionalParametersViewModel additionalParametrsItem = new AdditionalParametersViewModel();
                    additionalParametrsItem.Id = DataList.Count;
                    DataList.Add(additionalParametrsItem);
                    SelectedDataList = additionalParametrsItem;
                }));
            }
        }
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ?? (removeCommand = new RelayCommand(obj =>
                {
                    AdditionalParametersViewModel additionalParametrs = obj as AdditionalParametersViewModel;
                    if (additionalParametrs != null)
                    {
                        DataList.Remove(additionalParametrs);
                    }
                },(obj) => DataList.Count > 0));
            }
        }
        public RelayCommand MoveUpCommand
        {
            get
            {
                return moveUpCommand ?? (moveUpCommand = new RelayCommand(obj =>
                {
                    var item = obj as AdditionalParametersViewModel;
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
                    var item = obj as AdditionalParametersViewModel;
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
        //public RelayCommand OpenSecondWindowCommand
        //{
        //    get
        //    {
        //        return openSecondWindow ?? (openSecondWindow = new RelayCommand(obj =>
        //        {
        //            AdditionalParametrs additionalParametrs = obj as AdditionalParametrs;
        //            if (additionalParametrs.Type == "Значение из списка" || additionalParametrs.Type == "Набор значений из списка")
        //            {
        //                var data = SelectedDataList.AdditionalListArr;
        //                openedItemId = SelectedDataList.Id;
        //                ListWindow listWindow = new ListWindow(data, openedItemId, this);
        //                listWindow.Show();
        //            }
        //        }));
        //    }
        //}
        public RelayCommand SaveCommand
        {
            get
            {
                return saveCommand ??
                  (saveCommand = new RelayCommand(obj =>
                  {
                      fileService.Save(fileName, DataList);
                      Application.Current.MainWindow.Close();
                  }));
            }
        }
        public RelayCommand CloseWindowCommand
        {
            get
            {
                return closeWindowCommand ?? (closeWindowCommand = new RelayCommand(obj =>
                    {
                        Application.Current.MainWindow.Close();
                    }));
            }
        }
        #endregion
        //private int openedItemId;
        private AdditionalParametersViewModel selectedDataList;
        public AdditionalParametersViewModel SelectedDataList
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
        public ObservableCollection<AdditionalParametersViewModel> DataList { get; set; }
        public MainWindowViewModel(IFileService fileService)
        {
            this.fileService = fileService;
            DataList = fileService.Open(fileName);
        }
    }
}
