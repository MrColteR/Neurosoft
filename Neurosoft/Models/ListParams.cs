using Neurosoft.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neurosoft.Models
{
    public class ListParams : Model
    {
        private string itemList;
        public string ItemList
        {
            get { return itemList; }
            set { itemList = value; }
        }
        public ListParams(string str)
        {
            itemList = str;
        }
    }
}
