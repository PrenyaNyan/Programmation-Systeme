﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetMVC.Model;

namespace ProjetMVC
{
    public class ModelLogState : ModelLogTemplate
    {
        public string time { get; set; }
        public string size { get; set; }
        public string state { get; set; }
        public int fileAmount { get; set; }

        /* States const */
        public const string STATE_END = "END";
        public const string STATE_ACTIVE = "ACTIVE";
        public const string STATE_ERROR = "ERROR";
        public const string STATE_CREATED = "CREATED";

        public ModelLogState()
        {
            this.logPath = "Statesave";
            setLogType();
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
