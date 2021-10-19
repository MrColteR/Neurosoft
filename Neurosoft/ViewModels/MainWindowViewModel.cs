using Neurosoft.ViewModels.Base;

namespace Neurosoft.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private string title;
        private string type;
        private string additionalList;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }
        public string Type
        {
            get { return type; }
            set
            {
                type = value;
                OnPropertyChanged("Type");
            }
        }
        public string AdditionalList
        {
            get { return additionalList; }
            set
            {
                additionalList = value;
                OnPropertyChanged("AdditionalList");
            }
        }
    }
}
