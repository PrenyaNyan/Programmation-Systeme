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
            int saveTypenum;
            string pathS;
            string pathT;
            string name;
            SaveProject saveproject;
            int savenum;
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
                        name = viewClass.ReadLine();
                        viewClass.WriteLine(modelClass.modelLangage.AskPath(true));
                        pathS = viewClass.ReadLine();
                        viewClass.WriteLine(modelClass.modelLangage.AskPath(false));
                        pathT = viewClass.ReadLine();
                        viewClass.WriteLine(modelClass.modelLangage.AskWhichSaveType());
                        saveTypenum = Convert.ToInt32(viewClass.ReadLine());
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
                        saveproject = new SaveProject(name,pathS,pathT,saveType );
                        modelClass.ModelSave.addProject(saveproject);
                        // "1 : Create a new save project
                        break;
                    //case "2":
                    //    // "2 : Modify an existing project
                    //    viewClass.WriteLine(modelClass.modelLangage.NotImplementedMsg());
                    //    break;
                    case "3":
                        // "3 : List all existing projects
                        viewClass.WriteLine(modelClass.GetProjectList());
                        break;
                    case "4":
                        // "4 : Start a save project
                        viewClass.WriteLine(modelClass.modelLangage.AskWhichSave());
                        viewClass.WriteLine(modelClass.GetProjectList());
                        savenum = Convert.ToInt32(viewClass.ReadLine());
                        if (savenum<0 | savenum > modelClass.ModelSave.Projects.Count - 1)
                        {
                            viewClass.WriteLine(modelClass.modelLangage.GetGenericErrorMsg());
                            break;
                        }
                        SaveProject selectedProject = modelClass.ModelSave.Projects[savenum];
                        selectedProject.Save();
                        selectedProject.GenerateStateLog(ModelLogState.STATE_END);
                        break;
                    case "5":
                        // "5 : Start all save projects
                        foreach (SaveProject project in this.modelClass.ModelSave.Projects)
                        {
                            project.Save();
                        }
                        break;
                    case "6":
                        // "6 : Get the path of the log files
                        viewClass.WriteLine(modelClass.modelLangage.GetLogPath());
                        break;
                    case "7":
                        viewClass.WriteLine(modelClass.modelLangage.AskWhichSave());
                        viewClass.WriteLine(modelClass.GetProjectList());
                        savenum = Convert.ToInt32(viewClass.ReadLine());
                        viewClass.WriteLine(modelClass.modelLangage.GetProjectInfo(modelClass.ModelSave.Projects[savenum]));
                        break;
                    case "2":
                        foreach (SaveProject project in modelClass.ModelSave.Projects)
                        {
                            viewClass.WriteLine(modelClass.modelLangage.GetProjectInfo(project));
                        }
                        break;
                    default:
                        viewClass.WriteLine(modelClass.modelLangage.GetGenericErrorMsg());
                        break;
                }
            }
        }
    }
}
