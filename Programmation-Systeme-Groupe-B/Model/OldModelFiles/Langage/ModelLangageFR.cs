using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Programmation_Systeme_Groupe_B.Model.Langage
{
    class ModelLangageFR : ModelLangage
    {
        public override string GetGenericErrorMsg()
        {
            string text = "";
            text += "\t / \\ Erreur, la saisie est incorrecte / \\\n";
            text += "\t/ ! \\      Veuillez recommencer      / ! \\";
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
            return "\tVeuillez saisir le chemin " + tpath + " pour le projet de sauvegarde.";
        }
        public override string AskWhichSaveType()
        {
            return "\tVeuillez saisir quel type de sauvegarde choisir pour ce projet.\nSaisissez :\n\t0 : Sauvegarde Différentielle\n\t1 : Sauvegarde Complète";
        }
        public override string MenuTasks()
        {
            string text = "";
            text += "\t┌────────────────────────────────────────────────────────────┐\n";
            text += "\t│ Veuillez sélectionner quelle tâche vous voulez effectuer : │\n";
            text += "\t│\t1 : Créer un nouveau projet de sauvegarde            │\n";
            //text += "2 : Modifier un projet existant\n";
            text += "\t│\t2 : Renvoyer les infos de tout les projets           │\n";
            text += "\t│\t3 : Lister les projets existants                     │\n";
            text += "\t│\t4 : Lancer un projet de sauvegarde                   │\n";
            text += "\t│\t5 : Lancer tout les projets de sauvegarde            │\n";
            text += "\t│\t6 : Renvoyer le chemin de sauvegarde                 │\n";
            text += "\t│\t7 : Renvoyer les infos d'un projet                   │\n";
            text += "\t│\t8 : Quitter l'application                            │\n";
            text += "\t└────────────────────────────────────────────────────────────┘";
            //text += "8 : Renvoyer les infos de tout les projets\n";
            return text;
        }
        public override string AskWhichSave()
        {
            string text = "\tVeuillez choisir le projet que vous souhaitez";
            // Read all existing save, then add into the string
            return text;
        }
        public override string AskProjectName()
        {
            return "\tVeuillez saisir le nom du projet";
        }
        public override string ErrorTooManyProject()
        {
            return "\tIl y a trop de projets déjà existant, il est impossible d'en créer un nouveau";
        }
        public override string GetGenericOkMsg()
        {
            return "\tTâche effectuée avec succès !";
        }
        public override string NotImplementedMsg()
        {
            return "\tDésolé! Cette fonction n'est pas encore disponible";
        }
        public override string GetProjectInfo(SaveProject project)
        {
            string text = "";
            text += "\tNom du projet : " + project.Name + "\n";
            text += "\tChemin source : " + project.PathSource + "\n";
            text += "\tChemin destination : " + project.PathTarget + "\n";
            text += "\tType de sauvegarde : " + project.SaveType + "\n";
            return text;
        }
        public override string NoProject()
        {
            return "\tAucun projet n'a été créé, veuillez en créer un avant d'exécuter cette fonction\n";
        }
    }
}
