using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Covid19
{
    public class Importer
    {
        public List<Mortality> GetMortality()
        {
            List<Mortality> jsonList;
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("https://epistat.sciensano.be/Data/COVID19BE_MORT.json");
                jsonList = JsonConvert.DeserializeObject<List<Mortality>>(json);
            }
            return jsonList;
        }

        public List<Mortality> ReadMortalityFromXmlFile(string filename)
        {
            List<Mortality> mortalityList = null;
            XmlSerializer serializer = new XmlSerializer(typeof(List<Mortality>));
            using (StreamReader reader = new StreamReader(filename))
            {
                mortalityList = (List<Mortality>)serializer.Deserialize(reader);
            }
            return mortalityList;
        }

        public List<Mortality> ReadMortalityFromJsonFile(string filename)
        {
            List<Mortality> objects;
            using (StreamReader file = File.OpenText(filename))
            {
                JsonSerializer serializer = new JsonSerializer();
                objects = (List<Mortality>)serializer.Deserialize(file, typeof(List<Mortality>));
            }
            return objects;
        }
    }
}
