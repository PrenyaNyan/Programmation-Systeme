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
    public class ModelLogDaily : ModelLogTemplate
    {
        public string time { get; set; }
        public string size { get; set; }

        public ModelLogDaily()
        {
            this.logPath = DateTime.Now.ToString("dd-MM-yyyy");
            setLogType();
            setTime();
        }

        public void setTime()
        {
            this.time = DateTime.Now.ToString();
        }

        public void save()
        {
            update(this.logPath, this);
        }
    }
}
