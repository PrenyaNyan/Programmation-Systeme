using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;
using Programmation_Systeme_Groupe_B.ViewModels;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Programmation_Systeme_Groupe_B.ViewModels
{
    public class ModelLogDaily : ModelLogTemplate
    {
        public string time { get; set; }
        public string size { get; set; }

        private ModelLogDaily()
        {
            this.logPath = DateTime.Now.ToString("dd-MM-yyyy");
            setLogType();
            setTime();
        }

        private static ModelLogDaily instance;

        public static ModelLogDaily GetInstance()
        {
            if (instance == null)
            {
                instance = new ModelLogDaily();
            }
            return instance;
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
