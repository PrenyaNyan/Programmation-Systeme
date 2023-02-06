using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace ProjetMVC.Model
{
    class ModelClass
    {
        public ModelClass()
        {

            ModelLangage modelLangage;
            ModelSave modelSave;
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
                File.WriteAllText("setting.json", JsonSerializer.Serialize(texte));
                file.Close();
            }
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