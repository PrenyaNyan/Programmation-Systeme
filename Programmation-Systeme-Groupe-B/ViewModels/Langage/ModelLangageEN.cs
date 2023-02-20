using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Programmation_Systeme_Groupe_B.ViewModels.Langage
{
    class ModelLangageEN : ModelLangage
    {
        public override string GetGenericErrorMsg()
        {
            string text = "";
            text += "\t / \\ Error, the input is incorrect ! / \\\n";
            text += "\t/ ! \\          Please retry         / ! \\";
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
            return "\tPlease type the " + tpath +" path for this project.";
        }
        public override string AskWhichSaveType()
        {
            return "\tPlease select which save type you want for this project.\nType :\n\t0 : Differential backup\n\t1 : Full backup";
        }
        public override string MenuTasks()
        {
            string text = "";
            text += "\t┌────────────────────────────────────────────────┐\n";
            text += "\t│ Please select what you want to do :\t\t │\n";
            text += "\t│\t1 : Create a new save project    \t │\n";
            text += "\t│\t2 : Get info of all project      \t │\n";
            //text += "2 : Modify an existing project\n";
            text += "\t│\t3 : List all existing projects   \t │\n";
            text += "\t│\t4 : Start a save project         \t │\n";
            text += "\t│\t5 : Start all save projects      \t │\n";
            text += "\t│\t6 : Get the path of the log files\t │\n";
            text += "\t│\t7 : Get info about a project     \t │\n";
            text += "\t│\t8 : Quit the app                 \t │\n";
            text += "\t└────────────────────────────────────────────────┘";
            //text += "8 : Get info of all project\n";
            return text;
        }
        public override string AskWhichSave()
        {
            string text = "\tSelect which project you want among the listed ones";
            // Read all existing save, then add into the string
            return text;
        }
        public override string AskProjectName()
        {
            return "\tType the name for this project";
        }
        public override string ErrorTooManyProject()
        {
            return "\tThere's too many project created, it's impossible to make another one";
        }
        public override string GetGenericOkMsg()
        {
            return "\tTask done successfully !";
        }
        public override string NotImplementedMsg()
        {
            return "\tSorry ! This function is not already implemented";
        }
        public override string GetProjectInfo(SaveProject project)
        {
            string text = "";
            text += "\tProject Name : " + project.Name + "\n";
            text += "\tSourcePath : " + project.PathSource + "\n";
            text += "\tTargetPath : " + project.PathTarget + "\n";
            text += "\tSave Type : " + project.SaveType + "\n";
            return text;
        }
        public override string NoProject()
        {
            return "\tThere's no project created, please make one before executing that function\n";
        }
    }
}
