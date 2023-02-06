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
                //ModelLangue.MenuTask();
                //Ask what to do
                    //Create a savework
                        //ask for name
                        //ask path
                        //ask new path
                    //modifié un projet existant 
                        //ask which one
                        //which param
                        //new value
                    //Lister les projets existant
                        //list all
                    //faire un travail de save
                        //Ask one or all
                            //
                        //Ask which project to do 
                            //
                        //Do
                            //
            }
        }
    }
}
