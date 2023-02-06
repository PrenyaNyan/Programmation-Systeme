using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ProjetMVC.View;
using System.Text.Json;

namespace ProjetMVC.Controller
{
    class ControllerClass
    {

        ViewClass viewClass = new();
        public ControllerClass()
        {
            if (File.Exists("setting.json"))
            {
                Console.WriteLine("vrai");
            }
            else
            {

                Console.WriteLine("false");
                var file = File.Create("setting.json");
                file.Close();
                bool valeur = true;
                string lang = "";
                while (valeur)
                {
                    viewClass.WriteLine("Choissez votre langue entre fr et en\nChoose your langage between fr and en");
                    lang = viewClass.ReadLine();
                    if (lang =="fr" ||lang =="en")
                    {
                        break;
                    }
                    else
                    {
                        viewClass.WriteLine("Erreur!\nError!\nRecommencez !\nTry again !");
                    }

                }
                var texte = new {Langue = lang };
                File.WriteAllText("setting.json", JsonSerializer.Serialize(texte));
            }
        }

        public void run()
        {
            while (true)
            {
                
            }
        }
    }
}
