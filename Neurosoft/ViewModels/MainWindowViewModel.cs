using System;
using System.IO;
using Neurosoft.Command;
using Neurosoft.ViewModels.Base;
using System.Collections.ObjectModel;
using Neurosoft.Data.Base;
using System.Windows;
using System.Collections.Generic;
using Neurosoft.Data;
using System.Linq;

namespace Neurosoft.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        private static string path = Directory.GetCurrentDirectory();
        public readonly string fileName = path.Substring(0, path.IndexOf("bin")) + "List.json";
        IFileService fileService;
        //private string oldTitle;
        //public string OldTitle { get; set; }
        #region Команды
        private RelayCommand addCommand;
        private RelayCommand removeCommand;
        private RelayCommand moveUpCommand;
        private RelayCommand moveDownCommand;
        private RelayCommand saveAndCloseCommand;
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
                    additionalParametrsItem.Title = $"Параметр {additionalParametrsItem.Id}";
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
                    var item = obj as AdditionalParametersViewModel;
                    var index = DataList.IndexOf(item);
                    if (item != null)
                    {
                        DataList.Remove(item);
                        SelectedIndex = index - 1;
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
                    //if (item != null)
                    //{
                        var index = DataList.IndexOf(item);
                        if (index != 0)
                        {
                            var temp = DataList[index - 1];
                            DataList[index - 1] = DataList[index];
                            DataList[index] = temp;
                            SelectedIndex = index - 1;
                        }
                    //}
                    //else
                    //{
                    //    MainWindow.ItemNotSelectedWarning();
                    //}
                },(obj) => SelectedIndex != -1 ));
            }
        }
        public RelayCommand MoveDownCommand
        {
            get
            {
                return moveDownCommand ?? (moveDownCommand = new RelayCommand(obj =>
                {
                    var item = obj as AdditionalParametersViewModel;
                    //if (item != null)
                    //{
                        var index = DataList.IndexOf(item);
                        if (index != DataList.Count - 1)
                        {
                            var temp = DataList[index + 1];
                            DataList[index + 1] = DataList[index];
                            DataList[index] = temp;
                            SelectedIndex = index + 1;
                        }
                    //}
                    //else
                    //{
                    //    MainWindow.ItemNotSelectedWarning();
                    //}
                },(obj) => SelectedIndex != -1));
            }
        }
        public RelayCommand SaveAndCloseCommand
        {
            get
            {
                return saveAndCloseCommand ??
                  (saveAndCloseCommand = new RelayCommand(obj =>
                  {
                      fileService.Save(fileName, DataList);
                      Application.Current.MainWindow.Close();
                  }));
            }
        }
        public RelayCommand SaveCommand
        {
            get
            {
                return saveCommand ??
                  (saveCommand = new RelayCommand(obj =>
                  {
                      fileService.Save(fileName, DataList);
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
        private List<ParametrType> parametrTypes = new List<ParametrType>()
        {
            ParametrType.simpleString,
            ParametrType.stringWithHistory,
            ParametrType.valueFromList,
            ParametrType.SetOfValueFromList
        };
        public List<ParametrType> ParametrTypes
        {
            get { return parametrTypes; }
            set
            {
                parametrTypes = value;
                OnPropertyChanged(nameof(ParametrTypes));
            }
        }
        //public void BeginningEdit(string oldTitle)
        //{
        //    this.oldTitle = oldTitle;
        //}
        public ObservableCollection<AdditionalParametersViewModel> DataList { get; set; }
        public MainWindowViewModel(IFileService fileService)
        {
            this.fileService = fileService;
            DataList = fileService.Open(fileName);
            AdditionalParametersViewModel viewModel = new AdditionalParametersViewModel(DataList);
        }
    }
}
