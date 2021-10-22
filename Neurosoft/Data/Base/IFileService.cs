using Neurosoft.Models;
using Neurosoft.ViewModels;
using System.Collections.ObjectModel;

namespace Neurosoft.Data.Base
{
    public interface IFileService
    {
        ObservableCollection<AdditionalParametersViewModel> Open(string filename);
        void Save(string filename, ObservableCollection<AdditionalParametersViewModel> phonesList);
    }
}
