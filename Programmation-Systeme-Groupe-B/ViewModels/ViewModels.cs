using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Forms;
using Programmation_Systeme_Groupe_B.Model.Specific;
using Programmation_Systeme_Groupe_B.View;


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
        private OpenFolderDirectory openFolderDirectory;
        private OpenWindow openWindow;
        private WindowCreateSave windowCreateSave;
        private CloseWindow closeWindow;
        private Button annulbouton;
    #endregion
    public ViewModel()
        {
            openFileBrowser = new OpenFileBrowser(this);
            openFolderDirectory = new(this);
            openWindow = new(this);
            closeWindow = new(this);
            getProjects = new(this);
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
        
    #endregion
    #region Model
        public ICommand GetProjects
        {
            get
            {
                return getProjects;
            }
        }

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
            MessageBox.Show(value);
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
        internal void GetProjectsCommand()
        {
            
        }
    #endregion
    }
}
