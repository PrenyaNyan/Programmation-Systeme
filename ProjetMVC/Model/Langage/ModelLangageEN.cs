using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetMVC.Model.Langage
{
    class ModelLangageEN : ModelLangage
    {
        public override string GetGenericErrorMsg()
        {
            string text = "";
            text += " / \\ Error, the input is incorrect ! / \\\n";
            text += "/ ! \\          Please retry         / ! \\";
            return text;
        }
        public override string AskPath(bool issourcepath)
        {
            string tpath = "";
            if (issourcepath)
            {
                tpath = "source";
            }
            else
            {
                tpath = "destination";
            }
            return "Please type the "+ tpath +" path for this project.";
        }
        public override string AskWhichSaveType()
        {
            return "Please select which save type you want for this project.\nType :\n\t1 : Full backup\n\t2 : Differential backup";
        }
        public override string MenuTasks()
        {
            string text = "Please select what you want to do :\n";
            text += "1 : Create a new save project\n";
            text += "2 : Get info of all project\n";
            //text += "2 : Modify an existing project\n";
            text += "3 : List all existing projects\n";
            text += "4 : Start a save project\n";
            text += "5 : Start all save projects\n";
            text += "6 : Get the path of the log files\n";
            text += "7 : Get info about a project\n";
            //text += "8 : Get info of all project\n";
            return text;
        }
        public override string AskWhichSave()
        {
            string text = "Select which save you want among the listed ones";
            // Read all existing save, then add into the string
            return text;
        }
        public override string AskProjectName()
        {
            return "Type the name for this project";
        }
        public override string AskSettings()
        {
            return "";
        }
        public override string ErrorTooManyProject()
        {
            return "There's too many project created, it's impossible to make another one";
        }
        public override string GetGenericOkMsg()
        {
            return "Task done successfully !";
        }
        public override string NotImplementedMsg()
        {
            return "Sorry ! This function is not already implemented";
        }
        public override string GetProjectInfo(SaveProject project)
        {
            string text = "";
            text += "Project Name : " + project.Name + "\n";
            text += "SourcePath : " + project.PathSource + "\n";
            text += "TargetPath : " + project.PathTarget + "\n";
            text += "Save Type : " + project.SaveType + "\n";
            return text;
        }
    }
}
