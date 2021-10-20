using Neurosoft.Data.Base;
using Neurosoft.Models;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Neurosoft
{
    public class JsonFileService : IFileService
    {
        public ObservableCollection<AdditionalParametrs> Open(string filename)
        {
            ObservableCollection<AdditionalParametrs> phones = new ObservableCollection<AdditionalParametrs>();
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(ObservableCollection<AdditionalParametrs>));
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                phones = jsonFormatter.ReadObject(fs) as ObservableCollection<AdditionalParametrs>;
            }
            return phones;
        }

        public void Save(string filename, ObservableCollection<AdditionalParametrs> phonesList)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(ObservableCollection<AdditionalParametrs>));
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                jsonFormatter.WriteObject(fs, phonesList);
            }
        }
    }
}
