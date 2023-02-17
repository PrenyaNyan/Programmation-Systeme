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
using ProjetMVC.Model;
using System.Xml.Linq;


namespace Programmation_Systeme_Groupe_B.ViewModels
{
    class ViewModel : ViewModelBase
    {
        #region Private Fields
        private OpenFileBrowser openFileBrowser;
        private ChangeLanguage changeLanguage;
        private GetProjects getProjects;
        private string buttonImageString;
        private string newSourcePath;
        private string newTargetPath;
        private string newFileName;
        private int newSaveType;
        private OpenFolderDirectory openFolderDirectory;
        private OpenWindow openWindow;
        private WindowCreateSave windowCreateSave;
        private CloseWindow closeWindow;
        private CreateProject createProject;
        private Button annulbouton;
        #endregion
        #region Private Fields Lang
        private bool langue;//if true then french
        private string boutonCreate, boutonLancerSave, titleCreateSave, textNameCreateSave, textPathSCreateSave, textPathTCreateSave, textSaveTypeCreateSave, textTypeDCreateSave, textTypeCCreateSave, buttonAnnulCreateSave, buttonCreateCreateSave;
        #endregion

        private SaveProject saveproject;
        ModelClass modelClass = new();
        public ViewModel()
        {
            openFileBrowser = new OpenFileBrowser(this);
            openFolderDirectory = new(this);
            openWindow = new(this);
            closeWindow = new(this);
            getProjects = new(this);
            createProject = new(this);
            changeLanguage = new ChangeLanguage(this);
            buttonImageString = "/View/Drapeau-France.png";
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
                    textTypeDCreateSave = "Différentiel";
                    textTypeCCreateSave = "Complète";
                    buttonAnnulCreateSave = "Annuler";
                    buttonCreateCreateSave = "Valider";
                }
                else // He's not FR like us
                {
                    boutonLancerSave = "Start all save";
                    boutonCreate = "Create a new save";
                    titleCreateSave = "Fill the fields to create a new project";
                    textNameCreateSave = "Name :";
                    textPathSCreateSave = "Input Path :";
                    textPathTCreateSave = "Output Path :";
                    textSaveTypeCreateSave = "Type of Save :";
                    textTypeDCreateSave = "Differential";
                    textTypeCCreateSave = "Full";
                    buttonAnnulCreateSave = "Cancel";
                    buttonCreateCreateSave = "Accept";
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
            }
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

        #endregion
        #region Model
        public ICommand GetProjects
        {
            get
            {
                return getProjects;
            }
        }


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
        public ICommand OpenBrowser
        {
            get
            {
                return openFileBrowser;
            }
        }

        public ICommand ChangeLanguage
        {
            get
            {
                return changeLanguage;
            }
        }
        public ICommand OpenFile
        {
            get
            {
                return openFolderDirectory;
            }
        }
        public ICommand OpenWindow
        {
            get
            {
                return openWindow;
            }
        }
        public ICommand CloseWindow
        {
            get
            {
                return closeWindow;
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

        #endregion

        #region Method
        #region Method
        internal void OpenFileBrowserCommand()
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Document"; // Default file name
            dialog.DefaultExt = ".txt"; // Default file extension
            dialog.Filter = "Text documents (.txt)|*.txt";
            // Show open file dialog box
            bool? result = dialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string filename = dialog.FileName;
            }
        }

        internal void OpenFolderDirectoryCommand(object parameter)
        {
            var dialog = new FolderBrowserDialog();
            string value = parameter.ToString();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (value == "Source")
                {
                    NewSourcePath = dialog.SelectedPath.ToString();
                }
                if (value == "Target")
                {
                    NewTargetPath = dialog.SelectedPath.ToString();
                }
            }

        }
        internal void OpenWindowCommand()
        {
            windowCreateSave = new WindowCreateSave();
            annulbouton = new Button();
            windowCreateSave.Show();
            if (!windowCreateSave.IsActive)
            {
                windowCreateSave.Close();
            }

        }
        internal void ChangeLanguageCommand()
        {
            Langue = !Langue;
            if (BoutonImagePath == "/View/Drapeau-France.png")
            {
                BoutonImagePath = "/View/DrapeauR-U.png";
                Console.WriteLine("OUI");
            }
            else
            {

                BoutonImagePath = "/View/Drapeau-France.png";
            }
            Console.WriteLine("NON");
        }
        internal void CloseWindowCommand()
        {

        }

        public void NewProject()
        {
            SaveTypeEnum saveType;
            switch (NewSaveType)
            {
                case 0:
                    saveType = SaveTypeEnum.Complete;
                    break;
                case 1:
                    saveType = SaveTypeEnum.Differential;
                    break;
                default:
                    saveType = SaveTypeEnum.Complete;
                    break;
            }

            if (NewFileName != null && NewSourcePath != null && NewTargetPath != null)
            {
                saveproject = new SaveProject(NewFileName, NewSourcePath, NewTargetPath, saveType);
                modelClass.ModelSave.addProject(saveproject);
                windowCreateSave.Close();
            }
            else
            {
                MessageBox.Show("Veuillez remplir tous les champs");
            }
        }

        internal void GetProjectsCommand()
        {

        }


        #endregion
    }

    #endregion
}
