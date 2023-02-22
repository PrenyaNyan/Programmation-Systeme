﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Forms;
using Programmation_Systeme_Groupe_B.Model.Specific;
using Programmation_Systeme_Groupe_B.View;
using Programmation_Systeme_Groupe_B.Model;
using System.Xml.Linq;
using System.IO;
using System.Text.Json;
using System.Collections.ObjectModel;

namespace Programmation_Systeme_Groupe_B.ViewModels
{
    class ViewModel : ViewModelBase
    {
        #region Private Fields
        private ChangeLanguage changeLanguage;
        private string buttonImageString;
        private string newSourcePath;
        private string newTargetPath;
        private string newBusinessWorker;
        private string newFileName;
        private string newExtension;
        private int newSaveType;
        private OpenFolderDirectory openFolderDirectory;
        private CreateProject createProject;
        private SaveAllProject saveAllProject;
        private SaveOneProject saveOneProject;
        private Button annulbouton;
        #endregion
        #region Private Fields Lang
        private bool langue;//if true then french
        private string boutonCreate, boutonLancerSave, titleCreateSave, textNameCreateSave, textPathSCreateSave, textPathTCreateSave, textSaveTypeCreateSave, textTypeDCreateSave, textTypeCCreateSave, buttonAnnulCreateSave, buttonCreateCreateSave, textSaveTypeExtension, textSaveTypeMetier,boutonSave;
        #endregion

        public SaveProject saveproject;
        private ObservableCollection<SaveProject> _saveProjects = new ObservableCollection<SaveProject>();
        public ObservableCollection<SaveProject> saveProjects
        {
            get
            {
                return this._saveProjects;
            }
        }
        ModelClass modelClass = ModelClass.GetModelClass();

        public ViewModel()
        {
            string setfile = "settings.json";
            if (!File.Exists(setfile))
            {
                var file = File.Create(setfile);
                file.Close();
                var texte = new { logType = "json" };
                File.WriteAllText(setfile, JsonSerializer.Serialize(texte));
                file.Close();
            }
            openFolderDirectory = new(this);
            createProject = new(this);
            saveAllProject = new(this);
            saveOneProject = new(this);
            changeLanguage = new ChangeLanguage(this);
            buttonImageString = "/View/Drapeau-France.png";
            foreach (var item in modelClass.ModelSave.Projects)
            {
                saveProjects.Add(item);
            }
            Langue = true;
        }
        #region Public Properties
        public bool Langue
        {
            get
            {
                return langue;
            }
            set
            {
                langue = value;
                if (langue) // If FR bro he is like us
                {
                    boutonLancerSave = "Lancer toutes les sauvegardes";
                    boutonCreate = "Créer une sauvegarde";
                    titleCreateSave = "Rentrez les champs pour créer votre nouveau projet";
                    textNameCreateSave = "Nom :";
                    textPathSCreateSave = "Chemin d'entrée :";
                    textPathTCreateSave = "Chemin de sortie :";
                    textSaveTypeCreateSave = "Type de sauvegarde :";
                    textSaveTypeExtension = "Extension prioritaire";
                    textTypeDCreateSave = "Différentiel";
                    textTypeCCreateSave = "Complète";
                    textSaveTypeMetier = "Logiciel metier ?";
                    buttonAnnulCreateSave = "Annuler";
                    buttonCreateCreateSave = "Valider";
                    boutonSave = "Sauvegarder";
                }
                else // He's not FR like us
                {
                    boutonLancerSave = "Start all save";
                    boutonCreate = "Create a new save";
                    titleCreateSave = "Fill the fields to create a new project";
                    textNameCreateSave = "Name :";
                    textPathSCreateSave = "Input Path :";
                    textPathTCreateSave = "Output Path :";
                    textSaveTypeExtension = "Prioritized expansion";
                    textSaveTypeCreateSave = "Type of Save :";
                    textTypeDCreateSave = "Differential";
                    textTypeCCreateSave = "Full";
                    textSaveTypeMetier = "Business software ?";
                    buttonAnnulCreateSave = "Cancel";
                    buttonCreateCreateSave = "Accept";
                    boutonSave = "Save";
                }
                OnPropertyChanged("BoutonLancerSave");
                OnPropertyChanged("BoutonCreate");
                OnPropertyChanged("TitleCreateSave");
                OnPropertyChanged("TextNameCreateSave");
                OnPropertyChanged("TextPathSCreateSave");
                OnPropertyChanged("TextPathTCreateSave");
                OnPropertyChanged("TextSaveTypeCreateSave");
                OnPropertyChanged("TextTypeDCreateSave");
                OnPropertyChanged("TextTypeCCreateSave");
                OnPropertyChanged("ButtonAnnulCreateSave");
                OnPropertyChanged("ButtonCreateCreateSave");
                OnPropertyChanged("TextSaveTypeExtension");
                OnPropertyChanged("TextSaveTypeMetier");
                OnPropertyChanged("BoutonSave");
            }
        }
        public string BoutonSave
        {
            get
            {
                return boutonSave;
            }
        }

        public ObservableCollection<SaveProject> SaveProjects
        {
            get { return this.saveProjects; }
        }
        public string BoutonLancerSave
        {
            get
            {
                return boutonLancerSave;
            }
        }
        public string BoutonCreate
        {
            get
            {
                return boutonCreate;
            }
        }
        public string TitleCreateSave
        {
            get
            {
                return titleCreateSave;
            }
        }
        public string TextNameCreateSave
        {
            get
            {
                return textNameCreateSave;
            }
        }
        public string TextPathSCreateSave
        {
            get
            {
                return textPathSCreateSave;
            }
        }
        public string TextPathTCreateSave
        {
            get
            {
                return textPathTCreateSave;
            }
        }
        public string TextSaveTypeCreateSave
        {
            get
            {
                return textSaveTypeCreateSave;
            }
        }

        public string TextSaveTypeMetier
        {
            get
            {
                return textSaveTypeMetier;
            }
        }



        public string TextSaveTypeExtension
        {
            get
            {
                return textSaveTypeExtension;
            }
        }
        public string TextTypeDCreateSave
        {
            get
            {
                return textTypeDCreateSave;
            }
        }
        public string TextTypeCCreateSave
        {
            get
            {
                return textTypeCCreateSave;
            }
        }
        public string ButtonAnnulCreateSave
        {
            get
            {
                return buttonAnnulCreateSave;
            }
        }
        public string ButtonCreateCreateSave
        {
            get
            {
                return buttonCreateCreateSave;
            }
        }
        #region Public Properties
        public Button AnnulButton
        {
            get
            {
                return annulbouton;
            }
        }
        public string BoutonImagePath
        {
            get
            {
                return buttonImageString;
            }
            set
            {
                buttonImageString = value;
                OnPropertyChanged("ButtonImageString");
            }
        }
        public string NewSourcePath
        {
            get
            {
                return newSourcePath;
            }
            set
            {
                newSourcePath = value;
                OnPropertyChanged("NewSourcePath");
            }
        }
        public string NewTargetPath
        {
            get
            {
                return newTargetPath;
            }
            set
            {
                newTargetPath = value;
                OnPropertyChanged("NewTargetPath");
            }
        }

        public string NewBusinessWorker
        {
            get
            {
                return newBusinessWorker;
            }
            set
            {
                newBusinessWorker = value;
                OnPropertyChanged("NewBusinessWorker");
            }
        }



        #endregion
        #region Model


        public string NewFileName
        {
            get
            {
                return newFileName;
            }
            set
            {
                newFileName = value;
                OnPropertyChanged("NewFileName");
            }
        }

        public string NewExtension
        {
            get
            {
                return newExtension;
            }
            set
            {
                newExtension = value;
                OnPropertyChanged("NewFileName");
            }
        }

        public int NewSaveType
        {
            get
            {
                return newSaveType;
            }
            set
            {
                newSaveType = value;
                OnPropertyChanged("NewFileName");
            }
        }

        #endregion
        #region Model

        public ICommand ChangeLanguage
        {
            get
            {
                return changeLanguage;
            }
        }
        public ICommand OpenFolderDirectory
        {
            get
            {
                return openFolderDirectory;
            }
        }

        #endregion
        public ICommand CreateProject
        {
            get
            {
                return createProject;
            }
        }

        public ICommand SaveAllProject
        {
            get
            {
                return saveAllProject;
            }
        }

        public ICommand SaveOneProject
        {
            get
            {
                return saveOneProject;
            }
        }
        #endregion

        #region Method


        public void ShowMsgBox(string msg)
        {
            MessageBox.Show(msg);
        }
        #endregion
    }
}
