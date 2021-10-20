using System;
using System.IO;
using Neurosoft.Command;
using Neurosoft.ViewModels.Base;
using System.Collections.ObjectModel;
using Neurosoft.Models;
using Neurosoft.Data.Base;
using Neurosoft.Views;

namespace Neurosoft.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        private readonly string fileName = $"{Environment.CurrentDirectory}\\List.json";
        IFileService fileService;

        #region Команды
        private RelayCommand addCommand;
        private RelayCommand removeCommand;
        //private RelayCommand moveUpCommand;
        private RelayCommand openSecondWindow;
        private RelayCommand saveCommand;
        private RelayCommand closeWindowCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ?? (addCommand = new RelayCommand(obj =>
                {
                    AdditionalParametrs additionalParametrs = new AdditionalParametrs();
                    DataList.Insert(0, additionalParametrs);
                    SelectedDataList = additionalParametrs;
                }));
            }
        }
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ?? (removeCommand = new RelayCommand(obj =>
                {
                    AdditionalParametrs additionalParametrs = obj as AdditionalParametrs;
                    if (additionalParametrs != null)
                    {
                        DataList.Remove(additionalParametrs);
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
        public RelayCommand OpenSecondWindowCommand
        {
            get
            {
                return openSecondWindow ?? (openSecondWindow = new RelayCommand(obj =>
                {
                    AdditionalParametrs additionalParametrs = obj as AdditionalParametrs;
                    if (additionalParametrs.Type == "Значение из списка" || additionalParametrs.Type == "Набор значений из списка")
                    {
                        ListWindow listWindow = new ListWindow();
                        listWindow.Show();
                    }
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
                        MainWindow mv = obj as MainWindow;
                        mv.Close();
                    }));
            }
        }   /*o => ((MainWindow)o).Close())*/ // Спросить у Димы
        

    #endregion

    private AdditionalParametrs selectedDataList;
        public AdditionalParametrs SelectedDataList
        {
            get { return selectedDataList; }
            set
            {
                selectedDataList = value;
                OnPropertyChanged("SelectedDataList");
            }
        }
        public ObservableCollection<AdditionalParametrs> DataList { get; set; }
        public MainWindowViewModel(IFileService fileService)
        {
            this.fileService = fileService;
            DataList = fileService.Open(fileName);
        }
    }
}
