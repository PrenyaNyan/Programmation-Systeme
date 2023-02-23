using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Programmation_Systeme_Groupe_B.Model;

namespace Programmation_Systeme_Groupe_B.Model
{
    public class ModelLogState : ModelLogTemplate
    {
        // Tranfer time
        public string time { get; set; }
        // Total size of files
        public string size { get; set; }
        // State to know if the save started, is running or has finished
        public string state { get; set; }
        // Amount of files
        public int fileAmount { get; set; }
        // List of files extension that will be prioritized
        public List<string> priorityExtension { get; set; }
        // List of files extension that will be encrypted
        public List<string> encryptExtension { get; set; }
        // Maximum file size to tranfer
        public long maxFileSize { get; set; }
        // Business softwares
        public string workProgram { get; set; }

        /* States const */
        public const string STATE_END = "END";
        public const string STATE_ACTIVE = "ACTIVE";
        public const string STATE_ERROR = "ERROR";
        public const string STATE_CREATED = "CREATED";
        public const string STATE_START = "START";
        public const string STATE_PAUSE = "PAUSE";
        public const string STATE_REMOVED = "REMOVED";



        private ModelLogState()
        {
            this.logPath = "StateSave";
            setLogType();
            setTime(DateTime.Now.ToString());
        }
        // Singleton class
        private static ModelLogState instance;

        // function to get the instance of ModelLogState
        public static ModelLogState GetInstance()
        {
            if (instance == null)
            {
                instance = new ModelLogState();
            }
            return instance;
        }

        #region accessors 
        public void setTime(string time)
        {
            this.time = time;
        }

        public void setSize(string size)
        {
            this.size = size;
        }

        public void setState(string state)
        {
            this.state = state;
        }

        public void setFileAmount(int fileAmount)
        {
            this.fileAmount = fileAmount;
        }
        #endregion
        public void save()
        {
            update(this.logPath, this);
        }

    }
}
