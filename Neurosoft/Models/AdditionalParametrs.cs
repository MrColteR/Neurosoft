using System;
using System.IO;
using Neurosoft.Models.Base;
using Neurosoft.ViewModels;
using Neurosoft.Command;
using System.Collections.ObjectModel;
using Neurosoft.Views;
using Newtonsoft.Json;
using System.Windows;

namespace Neurosoft.Models
{
    class AdditionalParametrs : Model
    {
        #region Команды
        private RelayCommand addCommand;
        private RelayCommand removeCommand;
        //private RelayCommand moveUpCommand;
        private RelayCommand openSecondWindow;
        private RelayCommand saveDataCommand;
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
        public RelayCommand OpenSecondWindow // Работает для command
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
        public RelayCommand SaveDataCommand
        {
            get
            {
                return saveDataCommand ?? (saveDataCommand = new RelayCommand(obj =>
                {
                    SaveJson(DataList);
                    MessageBox.Show("Сохранил");
                }));
            }
        }
        #endregion

        private readonly string fileName = $"{Environment.CurrentDirectory}\\List.json";
        private ObservableCollection<MainWindowViewModel> ReadJson()
        {
            if (!File.Exists(fileName))
            {
                File.CreateText(fileName).Dispose();
                return new ObservableCollection<MainWindowViewModel>();
            }
            using (StreamReader reader = File.OpenText(fileName))
            {
                var file = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<ObservableCollection<MainWindowViewModel>>(file);
            }
        }
        private void SaveJson(object data)
        {
            using (StreamWriter sw = File.CreateText(fileName))
            {
                string file = JsonConvert.SerializeObject(data);
                sw.Write(file);
            }
        }

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
            //DataList = ReadJson();
            DataList = new ObservableCollection<MainWindowViewModel>
            {
                new MainWindowViewModel { AdditionalList = "1", Title = "1", Type = "1" },
                new MainWindowViewModel { AdditionalList = "2", Title = "2", Type = "1" },
                new MainWindowViewModel { AdditionalList = "3", Title = "3", Type = "1" },
                new MainWindowViewModel { AdditionalList = "4", Title = "4", Type = "1" },
            };
        }
    }
}
