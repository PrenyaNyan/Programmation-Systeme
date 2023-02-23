using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;
using Programmation_Systeme_Groupe_B.Model;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Programmation_Systeme_Groupe_B.Model
{
    public class ModelLogDaily : ModelLogTemplate
    {
        // Tranfer time
        public string time { get; set; }
        // Total size of files
        public string size { get; set; }
        // Time for encrypting the file
        public string encrypttime { get; set; }
        private ModelLogDaily()
        {
            this.logPath = DateTime.Now.ToString("dd-MM-yyyy");
            setLogType();
            setTime();
        }
        // Used as a singleton
        private static ModelLogDaily instance;
        // function to get the instance of ModelLogDaily
        public static ModelLogDaily GetInstance()
        {
            if (instance == null)
            {
                instance = new ModelLogDaily();
            }
            return instance;
        }
        #region accessors 

        // update time
        public void setTime()
        {
            this.time = DateTime.Now.ToString();
        }

        #endregion
        // Add new values to the dailylog
        public void save()
        {
            update(this.logPath, this);
        }
    }
}
