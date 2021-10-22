using Neurosoft.Data.Base;
using Neurosoft.Models;
using Neurosoft.ViewModels;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Neurosoft
{
    public class JsonFileService : IFileService
    {
        public ObservableCollection<AdditionalParametersViewModel> Open(string filename)
        {
            ObservableCollection<AdditionalParametersViewModel> items = new ObservableCollection<AdditionalParametersViewModel>() { };
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(ObservableCollection<AdditionalParametersViewModel>));
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                items = jsonFormatter.ReadObject(fs) as ObservableCollection<AdditionalParametersViewModel>;
            }
            return items;
        }
        public void Save(string filename, ObservableCollection<AdditionalParametersViewModel> itemsList)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(ObservableCollection<AdditionalParametersViewModel>));
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                jsonFormatter.WriteObject(fs, itemsList);
            }
        }
    }
}
