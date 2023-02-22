using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Programmation_Systeme_Groupe_B.ViewModels;
using System.Windows.Input;

namespace Programmation_Systeme_Groupe_B.Model.Specific
{
    class ChangeLanguage : ICommand
    {
        private ViewModel viewModel;

        public ChangeLanguage(ViewModel vm)
        {
            viewModel = vm;

        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ChangeLanguageCommand();
        }
        public event EventHandler CanExecuteChanged;
        internal void ChangeLanguageCommand()
        {
            viewModel.Langue = !viewModel.Langue;
            if (viewModel.BoutonImagePath == "/View/Drapeau-France.png")
            {
                viewModel.BoutonImagePath = "/View/DrapeauR-U.png";
                Console.WriteLine("OUI");
            }
            else
            {

                viewModel.BoutonImagePath = "/View/Drapeau-France.png";
            }
            Console.WriteLine("NON");
        }
    }
}
