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
                        // "1 : Create a new save project
                        if (!modelClass.CheckNumProject())
                        {
                            viewClass.WriteLine(modelClass.modelLangage.ErrorTooManyProject());
                            break;
                        }
                        viewClass.WriteLine(modelClass.modelLangage.AskProjectName());
                        while (true)
                        {
                            name = viewClass.ReadLine();
                            if (!modelClass.ModelSave.NameAlreadyExist(name))
                            {
                                break;
                            }
                            viewClass.WriteLine(modelClass.modelLangage.GetGenericErrorMsg());
                        }
                        viewClass.WriteLine(modelClass.modelLangage.AskPath(issourcepath: true));
                        pathS = viewClass.ReadLine();
                        viewClass.WriteLine(modelClass.modelLangage.AskPath(issourcepath: false));
                        pathT = viewClass.ReadLine();
                        viewClass.WriteLine(modelClass.modelLangage.AskWhichSaveType());
                        try
                        {
                            saveTypenum = Convert.ToInt32(viewClass.ReadLine());
                        }
                        catch (Exception)
                        {
                            viewClass.WriteLine(modelClass.modelLangage.GetGenericErrorMsg());
                            break;
                        }
                        SaveTypeEnum saveType;
                        switch (saveTypenum)
                        {
                            case 0:
                                saveType = SaveTypeEnum.Differential;
                                break;
                            case 1:
                                saveType = SaveTypeEnum.Complete;
                                break;
                            default:
                                saveType = SaveTypeEnum.Complete;
                                break;
                        }
                        saveproject = new SaveProject(name, pathS, pathT, saveType);
                        modelClass.ModelSave.addProject(saveproject);
                        break;

                    case "2":
                        if (modelClass.ModelSave.Projects.Count == 0)
                        {
                            viewClass.WriteLine(modelClass.modelLangage.NoProject());
                            break;
                        }
                        foreach (SaveProject project in modelClass.ModelSave.Projects)
                        {
                            viewClass.WriteLine(modelClass.modelLangage.GetProjectInfo(project));
                        }
                        break;
                    //case "2":
                    //    // "2 : Modify an existing project
                    //    viewClass.WriteLine(modelClass.modelLangage.NotImplementedMsg());
                    //    break;
                    case "3":
                        // "3 : List all existing projects
                        if (modelClass.ModelSave.Projects.Count == 0)
                        {
                            viewClass.WriteLine(modelClass.modelLangage.NoProject());
                            break;
                        }
                        viewClass.WriteLine(modelClass.GetProjectList());
                        break;
                    case "4":
                        // "4 : Start a save project
                        if (modelClass.ModelSave.Projects.Count == 0)
                        {
                            viewClass.WriteLine(modelClass.modelLangage.NoProject());
                            break;
                        }
                        viewClass.WriteLine(modelClass.modelLangage.AskWhichSave());
                        viewClass.WriteLine(modelClass.GetProjectList());
                        try
                        {
                            savenum = Convert.ToInt32(viewClass.ReadLine());
                        }
                        catch (Exception)
                        {
                            viewClass.WriteLine(modelClass.modelLangage.GetGenericErrorMsg());
                            break;
                        }
                        if (savenum < 0 | savenum > modelClass.ModelSave.Projects.Count - 1)
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
                        if (modelClass.ModelSave.Projects.Count == 0)
                        {
                            viewClass.WriteLine(modelClass.modelLangage.NoProject());
                            break;
                        }
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
                        if (modelClass.ModelSave.Projects.Count == 0)
                        {
                            viewClass.WriteLine(modelClass.modelLangage.NoProject());
                            break;
                        }
                        viewClass.WriteLine(modelClass.modelLangage.AskWhichSave());
                        viewClass.WriteLine(modelClass.GetProjectList());
                        try
                        {
                            savenum = Convert.ToInt32(viewClass.ReadLine());
                        }
                        catch (Exception)
                        {
                            viewClass.WriteLine(modelClass.modelLangage.GetGenericErrorMsg());
                            break;
                        }
                        viewClass.WriteLine(modelClass.modelLangage.GetProjectInfo(modelClass.ModelSave.Projects[savenum]));
                        break;
                    case "8":
                        return;

                    //case "9":
                    //    foreach (SaveProject project in modelClass.ModelSave.Projects)
                    //    {
                    //        viewClass.WriteLine(modelClass.modelLangage.GetProjectInfo(project));
                    //    }
                    //    break;
                    default:
                        viewClass.WriteLine(modelClass.modelLangage.GetGenericErrorMsg());
                        break;
                }
            }
        }
    }
}
