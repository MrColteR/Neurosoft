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
        private string listValue;
        public string ListValue
        {
            get { return listValue; }
            set { listValue = value; }
        }
        public ListParams(string str)
        {
            listValue = str;
        }
    }
}
