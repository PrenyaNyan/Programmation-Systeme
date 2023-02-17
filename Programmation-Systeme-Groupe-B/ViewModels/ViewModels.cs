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
        private SaveProject saveproject;
        ModelClass modelClass = new();
        #endregion
        public ViewModel()
        {
            openFileBrowser = new OpenFileBrowser(this);
            openFolderDirectory = new(this);
            openWindow = new(this);
            closeWindow = new(this);
            createProject = new(this);
            changeLanguage = new ChangeLanguage(this);
            buttonImageString = "/View/Drapeau-France.png";
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

        public ICommand CreateProject
        {
            get
            {
                return createProject;
            }
        }

        #endregion

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


        #endregion
    }
}
