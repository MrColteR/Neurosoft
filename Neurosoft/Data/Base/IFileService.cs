using Neurosoft.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Neurosoft.Data.Base
{
    public interface IFileService
    {
        ObservableCollection<AdditionalParametrs> Open(string filename);
        void Save(string filename, ObservableCollection<AdditionalParametrs> phonesList);
    }
}
