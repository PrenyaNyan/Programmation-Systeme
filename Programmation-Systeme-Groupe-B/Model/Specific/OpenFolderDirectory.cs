using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Programmation_Systeme_Groupe_B.ViewModels;
using System.Windows.Input;
using System.Windows.Forms;

namespace Programmation_Systeme_Groupe_B.Model.Specific
{
    class OpenFolderDirectory : ICommand
    {
        private ViewModel viewModel;

        public OpenFolderDirectory(ViewModel vm)
        {
            viewModel = vm;

        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            OpenFolderDirectoryCommand(parameter);
        }
        public event EventHandler CanExecuteChanged;
        internal void OpenFolderDirectoryCommand(object parameter)
        {
            var dialog = new FolderBrowserDialog();
            string value = parameter.ToString();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (value == "Source")
                {
                    viewModel.NewSourcePath = dialog.SelectedPath.ToString();
                }
                if (value == "Target")
                {
                    viewModel.NewTargetPath = dialog.SelectedPath.ToString();
                }
            }
        }
    }
}

