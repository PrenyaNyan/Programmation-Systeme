using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Programmation_Systeme_Groupe_B.ViewModels;
using System.Windows.Input;
using System.Windows;

namespace Programmation_Systeme_Groupe_B.Model.Specific
{
    class CreateProject : ICommand
    {
        private ViewModel viewModel;

        public CreateProject(ViewModel vm)
        {
            viewModel = vm;

        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            NewProject();
        }
        public event EventHandler CanExecuteChanged;
        public void NewProject()
        {
            SaveTypeEnum saveType;
            switch (viewModel.NewSaveType)
            {
                case 0:
                    saveType = SaveTypeEnum.Complete;
                    break;
                case 1:
                    saveType = SaveTypeEnum.Differential;
                    break;
                default:
                    saveType = SaveTypeEnum.Complete;
                    break;
            }

            if (viewModel.NewFileName == null | viewModel.NewSourcePath == null | viewModel.NewTargetPath == null)
            {
                if (viewModel.Langue)
                {
                    viewModel.ShowMsgBox("Veuillez remplir tous les champs");
                    return;
                }
                viewModel.ShowMsgBox("Please fill all the fields");
                return;
            }
            if (ModelClass.GetModelClass().ModelSave.NameAlreadyExist(viewModel.NewFileName))
            {
                if (viewModel.Langue)
                {
                    viewModel.ShowMsgBox("Le nom de projet existe déjà, veuillez le renommer");
                    return;
                }
                viewModel.ShowMsgBox("This project name is already used, select another one");
                return;
            }

            if (viewModel.NewSourcePath.Equals(viewModel.NewTargetPath)) return;
            viewModel.saveproject = new SaveProject(viewModel.NewFileName, viewModel.NewSourcePath, viewModel.NewTargetPath, saveType);
            // Append specifics priority extension if there is
            if (viewModel.NewExtension is not null)
            {
                // Every extensions needs to be separated by a semicolon
                foreach (string extension in viewModel.NewExtension.Split(";"))
                {
                    viewModel.saveproject.AddPriorityExtension(extension);
                }
            }

            if (viewModel.NewSizeLimit != 0) 
            {
                viewModel.saveproject.MaxFileSize = viewModel.NewSizeLimit;
            }

            viewModel.saveproject.WorkProgram = viewModel.NewBusinessWorker;

            // Add differents projects to the modelSave for saving, and saveProjects for visual feedback
            ModelClass.GetModelClass().ModelSave.addProject(viewModel.saveproject);
            viewModel.saveProjects.Add(viewModel.saveproject);
        }
    }
}
