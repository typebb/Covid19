using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Covid19
{
    public class ExportCases
    {
        public void WriteXmlFile(List<Cases> collection, string filename)
        {
            XmlSerializer x = new XmlSerializer(typeof(List<Cases>));
            using (TextWriter writer = new StreamWriter(filename))
            {
                x.Serialize(writer, collection);
            }
        }
        public void WriteJsonFile(List<Cases> collection, string filename)
        {
            using (StreamWriter writer = File.CreateText(filename))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, collection);
            }
        }
    }
}
