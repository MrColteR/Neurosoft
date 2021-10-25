using Neurosoft.Command;
using Neurosoft.Data.Base;
//using Neurosoft.Models;
using Neurosoft.ViewModels.Base;
using Neurosoft.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
//using System.ComponentModel.DataAnnotations;

namespace Neurosoft.ViewModels
{
    public class AdditionalParametersViewModel : ViewModel/*, IEditableObject*/
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
            //get
            //{
            //    return title;
            //}
            //set
            //{
            //    if (title == value) return;
            //    title = value;
            //    OnPropertyChanged(nameof(Title));
            //}
            get { return title; }
            set
            {
                if (DataList == null)
                {
                    title = value;
                    OnPropertyChanged(nameof(Title));
                }
                else
                {
                    foreach (var item in DataList)
                    {
                        if (value == item.title)
                        {
                            //MessageBox.Show("Имя занято");
                            return;
                        }
                    }
                    title = value;
                    OnPropertyChanged(nameof(Title));
                }
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
        //private void Examination()
        //{
        //    foreach (var item in DataList)
        //    {
        //        if (title == item.title)
        //        {
        //            MessageBox.Show("пп");
        //        }
        //        else
        //        {
        //            title = value;
        //            OnPropertyChanged(nameof(Title));
        //        }
        //    }
        //}
        static public ObservableCollection<AdditionalParametersViewModel> DataList { get; set; }
        public AdditionalParametersViewModel() { }
        public AdditionalParametersViewModel(ObservableCollection<AdditionalParametersViewModel> data)
        {
            DataList = data;
        }

        //private AdditionalParametersViewModel backupCopy;
        //private bool inEdit;

        //public void BeginEdit()
        //{
        //    if (inEdit) return;
        //    inEdit = true;
        //    backupCopy = this.MemberwiseClone() as AdditionalParametersViewModel;
        //}

        //public void EndEdit()
        //{
        //    if (!inEdit) return;
        //    inEdit = false;
        //    this.Title = backupCopy.Title;
        //}

        //public void CancelEdit()
        //{
        //    if (!inEdit) return;
        //    inEdit = false;
        //    backupCopy = null;
        //}
    }
}
