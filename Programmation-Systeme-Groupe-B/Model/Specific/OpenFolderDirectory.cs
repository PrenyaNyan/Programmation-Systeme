using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Programmation_Systeme_Groupe_B.ViewModels;
using System.Windows.Input;

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
            viewModel.OpenFolderDirectoryCommand(parameter);
        }
        public event EventHandler CanExecuteChanged;
    }
}

