using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using System.Net.Http.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using Newtonsoft.Json.Linq;

namespace ProjetMVC.Model
{
    class ModelLogTemplate
    {
        public string name { get; set; }
        public string pathTarget { get; set; }
        public string pathSource { get; set; }

        public void save(string path, string content)
        {
            string jsonpath = path + ".json";
            createJsonFile(jsonpath);
            File.WriteAllText(jsonpath, content);
        }

        public void update(Object ObjectContent)
        {
            var json = load("Dailysave");
            json.Add(ObjectContent);
            save("Dailysave", json.ToString());
        }

        public JArray load(string path)
        {
            string Stringjson = File.ReadAllText("Dailysave.json");
            var json = JsonConvert.DeserializeObject<JArray>(Stringjson);
            return json;
        }

        public void createJsonFile(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
                File.WriteAllText(path, "[]");
            }
        }
    }
}
