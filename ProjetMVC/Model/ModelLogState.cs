using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetMVC.Model;

namespace ProjetMVC
{
    class ModelLogState : ModelLogTemplate
    {
        public string time { get; set; }
        public string size { get; set; }
        public string state { get; set; }
        public int fileAmount { get; set; }

        /* State log path */
        public const string STATE_PATH = "Dailysave.json";

        /* States const */
        public const string STATE_END = "END";
        public const string STATE_ACTIVE = "ACTIVE";
        public const string STATE_ERROR = "ERROR";

        public ModelLogState()
        {
            name = "logDaily";
            pathTarget = "C:\\Users\\Public\\Documents\\logDaily.json";
            pathSource = "C:\\Users\\Public\\Documents\\logDaily.json";
            state = STATE_ACTIVE;
            size = "0";
            fileAmount = 0;

            update(STATE_PATH, this);
        }
    }
}
