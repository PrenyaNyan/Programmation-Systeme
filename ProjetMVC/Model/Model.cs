using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetMVC.Model
{
    class Model
    {
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
