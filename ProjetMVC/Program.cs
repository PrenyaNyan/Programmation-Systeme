using ProjetMVC.Model;
using System;
using System.Collections.Generic;
using ProjetMVC.Controller;

namespace ProjetMVC
{
    class Program
    {
        static void Main(string[] args)
        {
            ModelSave model = new ModelSave();
            /*SaveProject project = new SaveProject("Test", "aaa", "eee", SaveTypeEnum.Complete);
            SaveProject project2 = new SaveProject("TOTO", "AAAEE", "EEE", SaveTypeEnum.Differential);
            model.addProject(project);
            model.addProject(project2);
            List<SaveProject> projects = model.Projects;
            foreach (SaveProject p in projects)
            Console.WriteLine(p.Name);*/
            ControllerClass controllerClass = new ControllerClass();
        }
    }
}
