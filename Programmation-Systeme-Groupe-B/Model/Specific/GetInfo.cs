using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Programmation_Systeme_Groupe_B.ViewModels;

namespace Programmation_Systeme_Groupe_B.Model.Specific
{
    class GetInfo : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private ViewModel viewModel;
        public GetInfo(ViewModel vm)
        {
            viewModel = vm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.GetInfoCommand();
        }
    }
}
