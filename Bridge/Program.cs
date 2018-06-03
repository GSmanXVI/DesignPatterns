using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bridge
{
    class DataRepository
    {
        public List<string> Data { get; set; }
        public IExporter Exporter { get; set; }

        public DataRepository()
        {
            Data = new List<string>();
        }

        public void Add(string text)
        {
            Data.Add(text);
        }

        public void Remove(int index)
        {
            Data.RemoveAt(index);
        }

        public void Save(string filename)
        {
            if (Exporter != null)
                Exporter.Export(Data, filename);
            else
                Console.WriteLine("The exporter was not setted!");
        }
    }

    interface IExporter
    {
        void Export(List<string> data, string filename);
    }

    class JsonExporter : IExporter
    {
        public void Export(List<string> data, string filename)
        {
            var json = JsonConvert.SerializeObject(data);
            File.WriteAllText($"{filename}.json", json);
            Console.WriteLine("Saved to json file.");
        }
    }

    class XmlExporter : IExporter
    {
        public void Export(List<string> data, string filename)
        {
            var xs = new XmlSerializer(data.GetType());
            using (var fs = new FileStream($"{filename}.xml", FileMode.Create))
            {
                xs.Serialize(fs, data);
            }
            Console.WriteLine("Saved to xml file.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var repository = new DataRepository();
            repository.Add("Data one");
            repository.Add("Data two");
            repository.Add("Data three");

            repository.Exporter = new JsonExporter();
            repository.Save("file");

            repository.Exporter = new XmlExporter();
            repository.Save("file");
        }
    }
}
