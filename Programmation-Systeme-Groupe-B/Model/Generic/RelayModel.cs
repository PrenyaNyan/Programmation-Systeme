using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Programmation_Systeme_Groupe_B.Model.Generic
{
    class RelayModel : ICommand
    {
        private Action commandTask;

        public void RelayCommand(Action workToDo)
        {
            commandTask = workToDo;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            commandTask();
        }
    }
}
