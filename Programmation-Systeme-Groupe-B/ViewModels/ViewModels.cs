using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Programmation_Systeme_Groupe_B.Model.Specific;


namespace Programmation_Systeme_Groupe_B.ViewModels
{
    class ViewModel : ViewModelBase
    {
    #region Private Fields
    private OpenFileBrowser openFileBrowser;
    #endregion
    public ViewModel()
        {
            openFileBrowser = new OpenFileBrowser(this);
        }
    #region Public Properties
 
        
    #endregion
    #region Model
        public ICommand OpenBrowser
        {
            get
            {
                return openFileBrowser;
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
    
    #endregion
}
}
