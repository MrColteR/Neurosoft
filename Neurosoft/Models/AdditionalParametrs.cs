using Neurosoft.Models.Base;
using System.Collections.Generic;

namespace Neurosoft.Models
{
    public class AdditionalParametrs : Model
    {
        private int id;
        private string title;
        private string type;
        private string additionalList;
        private List<string> additionalListArr;
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                //OnPropertyChanged(nameof(Title)); // не надо
            }
        }
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                //OnPropertyChanged(nameof(Title)); // не надо
            }
        }
        public string Type
        {
            get { return type; }
            set
            {
                type = value;
                //OnPropertyChanged(nameof(Type));
            }
        }
        public string AdditionalList
        {
            get { return additionalList = "Список..."; }
            set
            {
                additionalList = value;
                //OnPropertyChanged(nameof(AdditionalList));
            }
        }
        public List<string> AdditionalListArr
        {
            get { return additionalListArr; }
            set { additionalListArr = value; }
        }
    }
}
