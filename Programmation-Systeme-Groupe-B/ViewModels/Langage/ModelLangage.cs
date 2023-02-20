﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Programmation_Systeme_Groupe_B.ViewModels;

namespace Programmation_Systeme_Groupe_B.ViewModels
{
    abstract class ModelLangage
    {
        //virtual public string GetQuestion() => "";
        //virtual public string GetInfos() => "";
        virtual public string GetGenericErrorMsg() => "";
        virtual public string AskWhichSave() => "";
        virtual public string AskPath(bool issourcepath)=> "";
        virtual public string AskWhichSaveType() => "";
        virtual public string MenuTasks() => "";
        virtual public string AskProjectName() => "";
        virtual public string GetLogPath() => Path.GetFullPath("setting.json");
        virtual public string ErrorTooManyProject() => "";
        virtual public string GetGenericOkMsg() => "";
        virtual public string NotImplementedMsg() => "";
        virtual public string GetProjectInfo(SaveProject project) => "";
        virtual public string NoProject() => "";
    }
}
