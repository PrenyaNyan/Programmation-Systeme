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
        public string time { get; set; }
        public string size { get; set; }

        /* Dailysave log path */
        public string DAILY_PATH = DateTime.Now.ToString("dd-MM-yyyy") + ".json";


        public ModelLogDaily(string name, string pathTarget, string pathSource)
        {
            this.name = name;
            this.pathTarget = pathTarget;
            this.pathSource = pathSource;
            this.time = DateTime.Now.ToString();
            setTime();
        }

        public void setTime()
        {
            this.time = DateTime.Now.ToString();
        }

        public void setSize(string size)
        {
            this.size = size;
        }



        public void save()
        {
            update(DAILY_PATH, this);
        }
    }
}
