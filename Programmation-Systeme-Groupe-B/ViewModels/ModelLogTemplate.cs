using System;
using System.IO;
using Newtonsoft.Json;
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
            createJsonFile(path);
            File.WriteAllText(path, content);
        }

        public void update(string jsonpath, Object obj)
        {
            createJsonFile(jsonpath);
            var ObjectContent = jsonBuilder(obj);
            var json = load(jsonpath);
            json.Add(ObjectContent);
            save(jsonpath, json.ToString());
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
