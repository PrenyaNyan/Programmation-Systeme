using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ProjetMVC.Model
{
    class ModelLogDaily : ModelLogTemplate
    {
        public string time { get;}
        public string state { get; set; }
        public string size { get; set; }
        public int fileAmount { get; set; }

        /* States const */
        public const string STATE_END = "END";
        public const string STATE_ACTIVE = "ACTIVE";
        public const string STATE_ERROR = "ERROR";

        /* time setter */
        public ModelLogDaily()
        {
            name = "logDaily";
            pathTarget = "C:\\Users\\Public\\Documents\\logDaily.json";
            pathSource = "C:\\Users\\Public\\Documents\\logDaily.json";
            state = STATE_ACTIVE;
            size = "0";
            fileAmount = 0;

            update(jsonBuilder());
        }

        public object jsonBuilder()
        {
            string StringObjectContent = JsonSerializer.Serialize(this);
            var ObjectContent = JsonConvert.DeserializeObject<JObject>(StringObjectContent);
            return ObjectContent;
        }
    }
}
