﻿using Neurosoft.Models.Base;
using Neurosoft.ViewModels;
using Neurosoft.Command;
using System.Collections.ObjectModel;
using Neurosoft.Views;

namespace Neurosoft.Models
{
    class AdditionalParametrs : Model
    {
        #region Команды
        private RelayCommand addCommand;
        private RelayCommand removeCommand;
        //private RelayCommand moveUpCommand;
        private RelayCommand openSecondWindow;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ?? (addCommand = new RelayCommand(obj =>
                {
                    MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
                    DataList.Insert(0, mainWindowViewModel);
                    SelectedDataList = mainWindowViewModel;
                }));
            }
        }
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ?? (removeCommand = new RelayCommand(obj =>
                {
                    MainWindowViewModel mainWindowViewModel = obj as MainWindowViewModel;
                    if (mainWindowViewModel != null)
                    {
                        DataList.Remove(mainWindowViewModel);
                    }
                },
                    (obj) => DataList.Count > 0));
            }
        }
        //public RelayCommand MoveUpCommand
        //{
        //    get
        //    {
        //        return moveUpCommand ?? (moveUpCommand = new RelayCommand(obj =>
        //        {
        //            MainWindowViewModel mainWindowViewModel =
        //        };
        //    }
        //}
        public RelayCommand OpenSecondWindow // Работает для кнопок
        {
            get
            {
                return openSecondWindow ?? (openSecondWindow = new RelayCommand(obj =>
                {
                    ListWindow listWindow = new ListWindow();
                    listWindow.Show();
                }));
            }
        }
        #endregion
        private MainWindowViewModel selectedDataList;
        public MainWindowViewModel SelectedDataList
        {
            get { return selectedDataList; }
            set
            {
                selectedDataList = value;
                OnPropertyChanged("SelectedDataList");
            }
        }
        public ObservableCollection<MainWindowViewModel> DataList { get; set; }
        public AdditionalParametrs()
        {
            DataList = new ObservableCollection<MainWindowViewModel>
            {
                new MainWindowViewModel { AdditionalList = "1", Title = "1" },
                new MainWindowViewModel { AdditionalList = "2", Title = "2" },
                new MainWindowViewModel { AdditionalList = "3", Title = "3" },
                new MainWindowViewModel { AdditionalList = "4", Title = "4" },
            };
        }
    }
}
