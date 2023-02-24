using System;
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
        private int newSizeLimit;
        private string newFileName;
        private string newExtension;
        private int newSaveType;
        private OpenFolderDirectory openFolderDirectory;
        private CreateProject createProject;
        private PauseSave pauseSave;
        private StopSave stopSave;
        private ResumeSave resumeSave;
        private SaveAllProject saveAllProject;
        private SaveOneProject saveOneProject;
        private Button annulbouton;
        private ChangeLog changeLog;
        #endregion
        #region Private Fields Lang
        private bool langue;//if true then french
        private string boutonCreate, boutonLancerSave, titleCreateSave, textNameCreateSave, textPathSCreateSave, textPathTCreateSave, textSaveTypeCreateSave, textTypeDCreateSave, textTypeCCreateSave, buttonAnnulCreateSave, buttonCreateCreateSave, textSaveTypeExtension, textSaveTypeMetier, boutonSave, textSaveSize;
        //private ObservableCollection<SaveProject> _saveProjects = new ObservableCollection<SaveProject>();
        private string logType;
        #endregion

        public ViewModel()
        {
            logType = "json";
            openFolderDirectory = new(this);
            createProject = new(this);
            saveAllProject = new(this);
            saveOneProject = new(this);
            pauseSave = new(this);
            stopSave = new(this);
            resumeSave = new(this);
            changeLog = new(this);
            changeLanguage = new ChangeLanguage(this);
            buttonImageString = "/View/Drapeau-France.png";
            Langue = true;
        }
        #region Public Properties
        public ModelClass modelClass = ModelClass.GetModelClass();

        public string LogType
        {
            get
            {
                return logType;
            }
            set
            {
                logType = value;
                OnPropertyChanged("LogType");
            }
        }

        public SaveProject saveproject;
        public ObservableCollection<SaveProject> saveProjects
        {
            get
            {
                return this.modelClass.ModelSave.Projects;
            }
        }
        public bool Langue
        {
            get
            {
                return langue;
            }
            set
            {
                langue = value;
                if (langue) // FR
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
                    textSaveSize = "Taille ( ko )";
                    buttonAnnulCreateSave = "Annuler";
                    buttonCreateCreateSave = "Valider";
                    boutonSave = "Sauvegarder";
                }
                else // EN
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
                    textSaveSize = "Size ( kb )";
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
                OnPropertyChanged("TextSaveSize");
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

        public string TextSaveSize
        {
            get
            {
                return textSaveSize;
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
                OnPropertyChanged("BoutonImagePath");
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

        public int NewSizeLimit
        {
            get
            {
                return newSizeLimit;
            }
            set
            {
                newSizeLimit = value;
                OnPropertyChanged("NewSizeLimit");
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

        public ICommand ChangeLogType
        {
            get
            {
                return changeLog;
            }
        }
        public ICommand CreateProject
        {
            get
            {
                return createProject;
            }
        }

        public ICommand PauseSave
        {
            get
            {
                return pauseSave;
            }
        }

        public ICommand StopSave
        {
            get
            {
                return stopSave;
            }
        }

        public ICommand ResumeSave
        {
            get
            {
                return resumeSave;
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
