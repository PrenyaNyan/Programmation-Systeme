using System;
using System.IO;
using Newtonsoft.Json;
using System.Xml.Serialization;
using JsonSerializer = System.Text.Json.JsonSerializer;
using Newtonsoft.Json.Linq;
using ProjetMVC.Model.Langage;

namespace ProjetMVC.Model
{
    public class ModelLogTemplate
    {
        public string logPath { get; set; }
        public string name { get; set; }
        public string pathTarget { get; set; }
        public string pathSource { get; set; }
        public string logType { get; set; }
        public long progression { get; set; }

        public const string JSONLOG = "json";
        public const string XMLLOG = "xml";

        public void save(string path, string content)
        {
            createJsonFile(path);
            File.WriteAllText(path, content);
        }
        
        public void setLogType()
        {
            Setting setting = JsonSerializer.Deserialize<Setting>(File.ReadAllText("settings.json"));
            switch (setting.logType)
            {
                case "json":
                    this.logType = JSONLOG;
                    break;
                case "xml":
                    this.logType = XMLLOG;
                    break;
                default:
                    break;
            }
        }

        public void update(string path, Object obj)
        {
            if (this.logType == JSONLOG)
            {
                string jsonpath = path + ".json";
                var ObjectContent = jsonBuilder(obj);
                createJsonFile(jsonpath);
                JArray json = load(jsonpath);
                json.Add(ObjectContent);
                save(jsonpath, json.ToString());
            }
            else
            {
                string xmlpath = path + ".xml";
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                using (TextWriter writer = new StreamWriter(xmlpath, true))
                {
                    serializer.Serialize(writer, obj);
                }
            }
        }

        public JArray load(string path)
        {
            string Stringjson = File.ReadAllText(path);
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

        public object jsonBuilder(object obj)
        {
            string StringObjectContent = JsonSerializer.Serialize(obj);
            var ObjectContent = JsonConvert.DeserializeObject<JObject>(StringObjectContent);
            return ObjectContent;
        }
    }
}
