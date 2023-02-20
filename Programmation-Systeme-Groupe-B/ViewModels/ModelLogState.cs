﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Programmation_Systeme_Groupe_B.ViewModels;

namespace Programmation_Systeme_Groupe_B.ViewModels
{
    public class ModelLogState : ModelLogTemplate
    {
        public string time { get; set; }
        public string size { get; set; }
        public string state { get; set; }
        public int fileAmount { get; set; }
        public List<string> priorityExtension { get; set; }


        /* States const */
        public const string STATE_END = "END";
        public const string STATE_ACTIVE = "ACTIVE";
        public const string STATE_ERROR = "ERROR";
        public const string STATE_CREATED = "CREATED";
        public const string STATE_START = "START";


        private ModelLogState()
        {
            this.logPath = "Statesave";
            setLogType();
            setTime(DateTime.Now.ToString());
        }

        private static ModelLogState instance;

        public static ModelLogState GetInstance()
        {
            if (instance == null)
            {
                instance = new ModelLogState();
            }
            return instance;
        }


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

        public void save()
        {
            update(this.logPath, this);
        }
    }
}
