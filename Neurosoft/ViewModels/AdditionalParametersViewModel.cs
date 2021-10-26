using Neurosoft.Command;
using Neurosoft.ViewModels.Base;
using Neurosoft.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Neurosoft.ViewModels
{
    public class AdditionalParametersViewModel : ViewModel
    {
        private int id;
        private string title;
        private string additionalList;
        private List<string> additionalListArr;
        private ParametrType parametrType;
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        public string Title
        {
            get { return title; } 
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        public string AdditionalList
        {
            get { return additionalList = "Список..."; ; }
            set
            {
                additionalList = value;
                OnPropertyChanged(nameof(AdditionalList));
            }
        }
        public List<string> AdditionalListArr
        {
            get { return additionalListArr; }
            set 
            { 
                additionalListArr = value;
                OnPropertyChanged(nameof(AdditionalListArr));
            }
        }
        public ParametrType ParametrType
        {
            get { return parametrType; }
            set
            {
                if (parametrType != value)
                {
                    parametrType = value;
                    OnPropertyChanged(nameof(ParametrType));
                }
            }
        }
        #region Команды
        private RelayCommand openSecondWindow;
        public RelayCommand OpenSecondWindowCommand
        {
            get
            {
                return openSecondWindow ?? (openSecondWindow = new RelayCommand(obj =>
                {
                    AdditionalParametersViewModel additionalParametrsList = obj as AdditionalParametersViewModel;
                    if (additionalParametrsList.parametrType == ParametrType.valueFromList || additionalParametrsList.parametrType == ParametrType.SetOfValueFromList)
                    {
                        var viewModel = new ListWindowViewModel(additionalParametrsList);
                        ListWindow listWindow = new ListWindow(viewModel);
                        if (listWindow.ShowDialog() == true)
                        {
                            viewModel.ApplyChange();
                        }
                    }
                }));
            }
        }
        #endregion
        public ObservableCollection<AdditionalParametersViewModel> DataList { get; set; }
        public AdditionalParametersViewModel() { }
        public AdditionalParametersViewModel(ObservableCollection<AdditionalParametersViewModel> data)
        {
            DataList = data;
        }
    }
}
