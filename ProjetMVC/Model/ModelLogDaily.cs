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
        public string size { get; set; }

        /* Dailysave log path */
        public const string DAILY_PATH = "Dailysave.json";

        /* States const */
        public const string STATE_END = "END";
        public const string STATE_ACTIVE = "ACTIVE";
        public const string STATE_ERROR = "ERROR";
        
        
        
        public ModelLogDaily()
        {

        }
    }
}
