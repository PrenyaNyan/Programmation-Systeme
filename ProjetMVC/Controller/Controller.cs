using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ProjetMVC.View;
using ProjetMVC.Model;
using System.Text.Json;

namespace ProjetMVC.Controller
{
    class ControllerClass
    {

        ViewClass viewClass = new();
        ModelClass modelClass = new();
        public ControllerClass()
        {
            viewClass.WriteLine(modelClass.GetAppBanner());
            modelClass.CheckSetting();
        }
        
        public void run()
        {
            while (true)
            {
                viewClass.WriteLine(modelClass.modelLangage.MenuTasks());
                string option = viewClass.ReadLine();
                switch (option)
                {
                    case "1":
                        // "1 : Create a new save project
                        if (!modelClass.CheckNumProject())
                        {
                            viewClass.WriteLine(modelClass.modelLangage.ErrorTooManyProject());
                            break;
                        }                        
                        break;
                    case "2":
                        // "2 : Modify an existing project
                        viewClass.WriteLine(modelClass.modelLangage.NotImplementedMsg());
                        break;
                    case "3":
                        // "3 : List all existing projects
                        break;
                    case "4":
                        // "4 : Start a save project
                        viewClass.WriteLine(modelClass.modelLangage.AskWhichSave());
                        int savenum = Convert.ToInt32(viewClass.ReadLine());
                        modelClass.ModelSave.Projects[savenum].Save();
                        break;
                    case "5":
                        // "5 : Start all save projects
                        break;
                    case "6":
                        // "6 : Get the path of the log files
                        break;
                    default:
                        viewClass.WriteLine(modelClass.modelLangage.GetGenericErrorMsg());
                        break;
                }

            }
        }
    }
}
