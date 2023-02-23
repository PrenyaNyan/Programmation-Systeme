using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Programmation_Systeme_Groupe_B.ViewModels;
using System.Windows.Input;

namespace Programmation_Systeme_Groupe_B.Model.Specific
{
    class ChangeLog : ICommand
    {
        private ViewModel viewModel;

        public ChangeLog(ViewModel vm)
        {
            viewModel = vm;

        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ChangeLogCommand();
        }
        public event EventHandler CanExecuteChanged;
        internal void ChangeLogCommand()
        {
            if (viewModel.LogType == "json")
            {
                viewModel.LogType = "xml";
            }
            else
            {

                viewModel.LogType = "json";
            }
        }
    }
}
