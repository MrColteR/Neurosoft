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
        private string oldTitle;
       public string OldTitle
        {
            get { return oldTitle; }
            set
            {
                oldTitle = value;
            }
        }
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
            }
        }
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
            }
        }
        public string Type
        {
            get { return type; }
            set
            {
                type = value;
            }
        }
        public string AdditionalList
        {
            get { return additionalList; }
            set
            {
                additionalList = value;
            }
        }
        public List<string> AdditionalListArr
        {
            get { return additionalListArr; }
            set { additionalListArr = value; }
        }
    }
}
