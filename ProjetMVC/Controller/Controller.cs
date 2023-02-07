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
                        if (!modelClass.CheckNumProject())
                        {
                            viewClass.WriteLine(modelClass.modelLangage.ErrorTooManyProject());
                            break;
                        }
                        viewClass.WriteLine(modelClass.modelLangage.AskProjectName());
                        string name = viewClass.ReadLine();
                        viewClass.WriteLine(modelClass.modelLangage.AskPath(false));
                        string pathT = viewClass.ReadLine();
                        viewClass.WriteLine(modelClass.modelLangage.AskPath(true));
                        string pathS = viewClass.ReadLine();
                        viewClass.WriteLine(modelClass.modelLangage.AskWhichSaveType());
                        int saveTypenum = Convert.ToInt32(viewClass.ReadLine());
                        SaveTypeEnum saveType;
                        switch (saveTypenum)
                        {
                            case 1:
                                saveType = SaveTypeEnum.Complete;
                                break;
                            case 2:
                                saveType = SaveTypeEnum.Differential;
                                break;
                            default:
                                saveType = SaveTypeEnum.Complete;
                                break;
                        }
                        SaveProject saveproject = new SaveProject(name,pathS,pathT,saveType );
                        // "1 : Create a new save project
                        break;
                    case "2":
                        // "2 : Modify an existing project
                        break;
                    case "3":
                        // "3 : List all existing projects
                        break;
                    case "4":
                        // "4 : Start a save project
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
