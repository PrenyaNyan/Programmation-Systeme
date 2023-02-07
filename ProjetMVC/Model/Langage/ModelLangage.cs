using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetMVC.Model
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
        virtual public string AskSettings() => "";
        virtual public string ErrorTooManyProject() => "";
        virtual public string GetGenericOkMsg() => "";
        virtual public string NotImplementedMsg() => "";
        virtual public string GetProjectInfo(SaveProject project) => "";
    }
}
