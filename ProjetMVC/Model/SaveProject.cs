using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetMVC.Model
{
    class SaveProject
    {
        // Project Name
        private string name;
        private string Name
        {
            get { return name; }
            set { name = value; }
        }
        // Project repertory source
        private string repertorySource;
        private string RepertorySource
        {
            get { return repertorySource; }
            set { repertorySource = value; }
        }

        // Project repertory target
        private string repertoryTarget;
        private string RepertoryTarget
        {
            get { return repertoryTarget; }
            set { repertoryTarget = value; }
        }
        // Project progression
        private Progression progression;
        private Progression Progression
        {
            get { return progression; }
            set { progression = value; }
        }
        // Project start time
        private DateTime startTime;
        private DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }
        // File size to save
        private int fileSize;
        private int FileSize
        {
            get { return fileSize; }
            set { fileSize = value; }
        }

        // Save project type
        private SaveTypeEnum saveType;
        public SaveTypeEnum SaveType
        {
            get { return saveType; }
            set { saveType = value; }
        }

        public SaveProject(string name, string repertorySource, string repertoryTarget, SaveTypeEnum saveType)
        {
            this.name = name;
            this.repertorySource = repertorySource;
            this.repertoryTarget = repertoryTarget;
            this.saveType = saveType;

        }

        // TODO: Méthode pour démarrer le processus de sauvegarde, définir : fileSize et la progression 
        public void save() { }
        public SaveProject getInfo()
        {
            return this;
        }

    }
}
