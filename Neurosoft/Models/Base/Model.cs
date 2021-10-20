using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Neurosoft.Models.Base
{
    public class Model
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
