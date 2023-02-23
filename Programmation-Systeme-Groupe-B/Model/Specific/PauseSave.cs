using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Programmation_Systeme_Groupe_B.ViewModels;
using System.Windows.Input;

namespace Programmation_Systeme_Groupe_B.Model.Specific
{
    class PauseSave : ICommand
    {
        private ViewModel viewModel;

        public PauseSave(ViewModel vm)
        {
            viewModel = vm;

        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Pause(parameter);
        }
        public event EventHandler CanExecuteChanged;
        public void Pause(object parameter)
        {
            foreach (SaveProject project in ModelClass.GetModelClass().ModelSave.Projects)
            {
                if (project.Name == parameter.ToString())
                {
                    project.PauseThread();
                }
            }
            viewModel.ShowMsgBox("Pause !");
        }
    }
}
