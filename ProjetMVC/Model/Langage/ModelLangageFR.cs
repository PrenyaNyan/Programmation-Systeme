using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetMVC.Model.Langage
{
    class ModelLangageFR : ModelLangage
    {
        public override string GetGenericErrorMsg()
        {
            string text = "";
            text += " / \\ Erreur, la saisie est incorrecte / \\\n";
            text += "/ ! \\      Veuillez recommencer      / ! \\";
            return text;
        }
        public override string AskPath(bool issourcepath)
        {
            string tpath = "";
            if (issourcepath)
            {
                tpath = "source";
            }
            else
            {
                tpath = "de sortie";
            }
            return "Veuillez saisir le chemin " + tpath + " pour le projet de sauvegarde.";
        }
        public override string AskWhichSaveType()
        {
            return "Veuillez saisir quel type de sauvegarde choisir pour ce projet.\nSaisissez :\n\t1 : Sauvegarde Complète\n\t2 : Sauvegarde Différentielle";
        }
        public override string MenuTasks()
        {
            string text = "Veuillez sélectionner quelle tâche vous voulez effectuer :\n";
            text += "1 : Créer un nouveau projet de sauvegarde\n";
            text += "2 : Modifier un projet existant\n";
            text += "3 : Lister les projets existants\n";
            text += "4 : Lancer un projet de sauvegarde\n";
            text += "5 : Lancer tout les projets de sauvegarde\n";
            text += "6 : Renvoyer le chemin de sauvegarde\n";
            return text;
        }
        public override string AskWhichSave()
        {
            string text = "Veuillez choisir la sauvegarde que vous souhaitez";
            // Read all existing save, then add into the string
            return text;
        }
        public override string AskProjectName()
        {
            return "Veuillez saisir le nom du projet";
        }
        public override string AskSettings()
        {
            return "";
        }
        public override string ErrorTooManyProject()
        {
            return "Il y a trop de projets déjà existant, il est impossible d'en créer un nouveau";
        }
        public override string GetGenericOkMsg()
        {
            return "Tâche effectuée avec succès !";
        }
    }
}
