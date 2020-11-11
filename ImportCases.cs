using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Serialization;

namespace Covid19
{
    public class ImportCases
    {
        public List<Cases> GetCases()
        {
            List<Cases> jsonList;
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("https://epistat.sciensano.be/Data/COVID19BE_CASES_MUNI.json");
                jsonList = JsonConvert.DeserializeObject<List<Cases>>(json);
            }
            return jsonList;
        }

        public List<Cases> ReadCasesFromXmlFile(string filename)
        {
            List<Cases> casesList = null;
            XmlSerializer serializer = new XmlSerializer(typeof(List<Cases>));
            using (StreamReader reader = new StreamReader(filename))
            {
                casesList = (List<Cases>)serializer.Deserialize(reader);
            }
            return casesList;
        }

        public List<Cases> ReadCasesFromJsonFile(string filename)
        {
            List<Cases> objects;
            using (StreamReader file = File.OpenText(filename))
            {
                JsonSerializer serializer = new JsonSerializer();
                objects = (List<Cases>)serializer.Deserialize(file, typeof(List<Cases>));
            }
            return objects;
        }
    }
}
