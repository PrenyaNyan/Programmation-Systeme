﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Programmation_Systeme_Groupe_B.ViewModels;
using System.Windows.Input;

namespace Programmation_Systeme_Groupe_B.Model.Specific
{
    class SaveAllProject : ICommand
    {
        private ViewModel viewModel;

        public SaveAllProject(ViewModel vm)
        {
            viewModel = vm;

        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            SaveAll();
        }
        public event EventHandler CanExecuteChanged;
        public void SaveAll()
        {
            foreach (SaveProject project in ModelClass.GetModelClass().ModelSave.Projects)
            {
                project.Save();
            }
            // Add Translation
            viewModel.ShowMsgBox("Sauvegarde effectuée");
        }
    }
}
