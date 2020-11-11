using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Covid19
{
    public class Exporter
    {
        public void WriteXmlFile(List<Mortality> collection, string filename)
        {
            XmlSerializer x = new XmlSerializer(typeof(List<Mortality>));
            using (TextWriter writer = new StreamWriter(filename))
            {
                x.Serialize(writer, collection);
            }
        }
        public void WriteJsonFile(List<Mortality> collection, string filename)
        {
            using (StreamWriter writer = File.CreateText(filename))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, collection);
            }
        }
    }
}
