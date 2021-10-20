using Neurosoft.Models.Base;

namespace Neurosoft.Models
{
    public class AdditionalParametrs : Model
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
            get { return additionalList = "Список"; }
            set
            {
                additionalList = value;
                OnPropertyChanged("AdditionalList");
            }
        }
    }
}
