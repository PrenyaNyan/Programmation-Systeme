using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using ProjetMVC.Model.Langage;

namespace ProjetMVC.Model
{
    class ModelClass
    {
        Setting setting;
        public ModelLangage modelLangage;
        public ModelSave ModelSave = new();
        public ModelClass()
        {
            
        }
        public void CheckSetting()
        {
            string setfile = "setting.json";
            if (File.Exists(setfile))
            {
                Console.WriteLine("vrai");
            }
            else
            {

                Console.WriteLine("false");
                var file = File.Create(setfile);
                file.Close();
                string lang = "";
                while (true)
                {
                    Console.WriteLine("Choissez votre langue entre fr et en\nChoose your langage between fr and en");
                    lang = Console.ReadLine();
                    if (lang == "fr" || lang == "en")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Erreur!\nError!\nRecommencez !\nTry again !");
                    }

                }
                var texte = new { Langue = lang };
                File.WriteAllText(setfile, JsonSerializer.Serialize(texte));
                file.Close();
            }
            // Get settings from settings file
            setting = JsonSerializer.Deserialize<Setting>(File.ReadAllText(setfile));
            switch (setting.Langue)
            {
                case "fr":
                    modelLangage = new ModelLangageFR();
                    break;
                case "en":
                    modelLangage = new ModelLangageEN();
                    break;
                default:
                    break;
            }
        }

        public bool CheckNumProject()
        {
            int count = this.ModelSave.Projects.Count();
            return 0<=count & count<5;
        }
        public string GetProjectList()
        {
            string text = "";
            int i = 0;
            foreach (SaveProject project in this.ModelSave.Projects)
            {
                text += "\t" + i + " : " + project.Name + "\n";
                i++;
            }
            return text;
        }
        public string GetAppBanner()
        {
            string text = "";
            text += "     ┌─────────────────────────────────────────────────────────┐\n";
            text += "     │     ______                   _____                      │\n";
            text += "     │    |  ____|                 / ____|                     │\n";
            text += "     │    | |__   __ _ ___ _   _  | (___   __ ___   _____      │\n";
            text += "     │    |  __| / _` / __| | | |  \\___ \\ / _` \\ \\ / / _ \\     │\n";
            text += "     │    | |___| (_| \\__ \\ |_| |  ____) | (_| |\\ V /  __/     │\n";
            text += "     │    |______\\__,_|___/\\__, | |_____/ \\__,_| \\_/ \\___|     │\n";
            text += "     │                      __/ |                              │\n";
            text += "     │                     |___/                               │\n";
            text += "     └─────────────────────────────────────────────────────────┘\n";
            return text;
        }
    }
}