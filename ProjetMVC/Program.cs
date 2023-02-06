using ProjetMVC.Model;
using System;
using ProjetMVC.Controller;

namespace ProjetMVC
{
    class Program
    {
        static void Main(string[] args)
        {
            SaveProject saveProject = new SaveProject("test", "C:\\Users\\leroc\\Desktop\\sourceTest", "C:\\Users\\leroc\\Desktop\\targetTest", SaveTypeEnum.Complete);
            saveProject.Save();
            int copiedFile = saveProject.Progression.CopiedFiles;
            long fileSizeCopied = saveProject.Progression.FilesSizeCopied;
           
            Console.WriteLine("fichiers totaux : " + saveProject.Progression.FileAmount + " taille totale: " + saveProject.Progression.FileSize);
            Console.WriteLine("fichiers copiés : " + copiedFile + " taille des trucs copiés: " + fileSizeCopied);
            ControllerClass controllerClass = new ControllerClass();
        }
    }
}
