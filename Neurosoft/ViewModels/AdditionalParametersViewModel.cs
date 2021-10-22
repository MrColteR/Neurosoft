using Neurosoft.Command;
using Neurosoft.Models;
using Neurosoft.ViewModels.Base;
using Neurosoft.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Neurosoft.ViewModels
{
    public class AdditionalParametersViewModel : ViewModel
    {
        private int openedItemId;
        private int id;
        private string title;
        private string type;
        private string additionalList;
        private List<string> additionalListArr;
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
        public string Type
        {
            get { return type; }
            set
            {
                type = value;
                OnPropertyChanged(nameof(Type));
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
            set { additionalListArr = value; OnPropertyChanged(nameof(AdditionalListArr)); }
        }
        private RelayCommand openSecondWindow;
        public RelayCommand OpenSecondWindowCommand
        {
            get
            {
                return openSecondWindow ?? (openSecondWindow = new RelayCommand(obj =>
                {
                    AdditionalParametersViewModel additionalParametrs = obj as AdditionalParametersViewModel;
                    if (additionalParametrs.Type == "Значение из списка" || additionalParametrs.Type == "Набор значений из списка")
                    {
                        var data = SelectedDataList.AdditionalListArr;
                        openedItemId = SelectedDataList.Id;
                        ListWindow listWindow = new ListWindow(data, openedItemId, this);
                        listWindow.Show();
                    }
                }));
            }
        }
        public ObservableCollection<AdditionalParametrs> DataList { get; set; }
        public AdditionalParametersViewModel()
        {

        }
    }
}
