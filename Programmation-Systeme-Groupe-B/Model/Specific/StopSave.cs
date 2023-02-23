using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Programmation_Systeme_Groupe_B.ViewModels;
using System.Windows.Input;

namespace Programmation_Systeme_Groupe_B.Model.Specific
{
    class StopSave : ICommand
    {
        private ViewModel viewModel;

        public StopSave(ViewModel vm)
        {
            viewModel = vm;

        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Stop(parameter);
        }
        public event EventHandler CanExecuteChanged;
        public void Stop(object parameter)
        {
            foreach (SaveProject project in ModelClass.GetModelClass().ModelSave.Projects)
            {
                if (project.Name == parameter.ToString())
                {
                    project.DeleteThread();
                }
            }
            viewModel.ShowMsgBox("Stop !");
        }
    }
}
