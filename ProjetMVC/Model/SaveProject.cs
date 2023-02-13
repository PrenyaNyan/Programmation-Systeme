﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetMVC.Model
{
    class SaveProject
    {

        // State log object
        public ModelLogState stateLog;
        public ModelLogDaily dailyLog;
        // Project Name
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        // Project repertory source
        private string pathSource;
        public string PathSource
        {
            get { return pathSource; }
            set { pathSource = value; }
        }

        // Project repertory target
        private string pathTarget;
        public string PathTarget
        {
            get { return pathTarget; }
            set { pathTarget = value; }
        }
        // Project progression
        private Progression progression;
        public Progression Progression
        {
            get { return progression; }
            set { progression = value; }
        }
        // Project start time
        private DateTime startTime;
        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }
        // File size to save
        private long fileSize;
        public long FileSize
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

        public SaveProject(string name, string pathSource, string pathTarget, SaveTypeEnum saveType)
        {
            this.name = name;
            this.pathSource = pathSource;
            this.pathTarget = pathTarget;
            this.saveType = saveType;
            this.progression = new Progression();
            this.startTime = DateTime.Now;
            this.stateLog = ModelLogState.GetInstance();
            this.dailyLog = ModelLogDaily.GetInstance();
        }

        // TODO: Méthode pour démarrer le processus de sauvegarde, définir : fileSize et la progression 
        public void Save()
        {
            this.progression.FileSize = DirSize(new DirectoryInfo(this.pathSource));
            this.progression.FileAmount = Directory.GetFiles(this.pathSource, "*", SearchOption.AllDirectories).Length;


            if (this.saveType == SaveTypeEnum.Complete)
            {
                GenerateStateLog(ModelLogState.STATE_ACTIVE);
                GenerateDailyLog();
                CompleteSave(this.pathSource, this.pathTarget, this.progression);

            }
            else if (this.saveType == SaveTypeEnum.Differential)
            {
                GenerateStateLog(ModelLogState.STATE_ACTIVE);
                GenerateDailyLog();
                DifferentialSave(this.pathSource, this.pathTarget, this.progression);

            }

        }

        private void CompleteSave(string source, string target, Progression progression)
        {
            DirectoryInfo mainDirectory = new DirectoryInfo(source);
            DirectoryInfo[] subDirectory = mainDirectory.GetDirectories();



            // If the source directory does not exist, throw an exception. //TODO Message d'erreur
            if (!mainDirectory.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + source);
            }

            // If the destination directory does not exist, create it.
            if (!Directory.Exists(target))
            {
                Directory.CreateDirectory(target);
            }


            // Get the file contents of the directory to copy.
            FileInfo[] files = mainDirectory.GetFiles();

            foreach (FileInfo file in files)
            {
                // Create the path to the new copy of the file.
                string temppath = Path.Combine(target, file.Name);

                // Copy the file.
                file.CopyTo(temppath, true);
                progression.CopiedFiles += 1;
                progression.FilesSizeCopied += file.Length;
            }

            foreach (DirectoryInfo subdir in subDirectory)
            {
                // Create the subdirectory.
                string temppath = Path.Combine(target, subdir.Name);

                // Copy the subdirectories.
                CompleteSave(subdir.FullName, temppath, progression);
            }
        }

        private void DifferentialSave(string source, string target, Progression progression)
        {
            DirectoryInfo mainDirectory = new DirectoryInfo(source);
            DirectoryInfo[] subDirectory = mainDirectory.GetDirectories();


            // If the source directory does not exist, throw an exception. //TODO Message d'erreur
            if (!mainDirectory.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + source);
            }

            // If the destination directory does not exist, create it.
            if (!Directory.Exists(target))
            {
                Directory.CreateDirectory(target);
            }


            // Get the file contents of the directory to copy.
            FileInfo[] files = mainDirectory.GetFiles();

            foreach (FileInfo file in files)
            {
                // Create the path to the new copy of the file.
                string temppath = Path.Combine(target, file.Name);

                // Copy the file. If it already exists, keep the most recent one.
                if (!File.Exists(temppath))
                {
                    file.CopyTo(temppath, false);
                    progression.CopiedFiles += 1;
                    progression.FilesSizeCopied += file.Length;
                }
                else
                {
                    FileInfo fileInfoSource = new FileInfo(temppath);
                    DateTime fileSourceDate = file.CreationTime;
                    DateTime fileTargetDate = fileInfoSource.CreationTime;
                    if (fileSourceDate.CompareTo(fileTargetDate) < 0)
                    {
                        file.CopyTo(temppath, true);
                    }
                    progression.CopiedFiles += 1;
                    progression.FilesSizeCopied += file.Length;
                }
            }

            foreach (DirectoryInfo subdir in subDirectory)
            {
                // Create the subdirectory.
                string temppath = Path.Combine(target, subdir.Name);

                // Copy the subdirectories.
                DifferentialSave(subdir.FullName, temppath, progression);
            }
        }
        public SaveProject GetInfo()
        {
            return this;
        }

        public static long DirSize(DirectoryInfo d)
        {
            long size = 0;
            // Add file sizes.
            FileInfo[] fis = d.GetFiles();
            foreach (FileInfo fi in fis)
            {
                size += fi.Length;
            }
            // Add subdirectory sizes.
            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                size += DirSize(di);
            }
            return size;
        }

        public override string ToString()
        {
            return this.name + " " + this.PathSource + " " + this.PathTarget + " " + this.SaveType;
        }

        // Generate active state log
        public void GenerateStateLog(string state)
        {
            /*this.name, this.pathSource, this.pathTarget*/
            this.stateLog.name = this.name;
            this.stateLog.pathSource = this.pathSource;
            this.stateLog.pathTarget = this.pathTarget;
            this.stateLog.fileAmount = this.progression.FileAmount;
            this.stateLog.size = this.progression.FileSize.ToString();
            this.stateLog.setState(state);
            this.stateLog.setTime();
            this.stateLog.save();
        }

        public void GenerateDailyLog()
        {
            this.dailyLog.name = this.name;
            this.dailyLog.pathSource = this.pathSource;
            this.dailyLog.pathTarget = this.pathTarget;
            this.dailyLog.size = this.progression.FileSize.ToString();
            this.dailyLog.setTime();
            this.dailyLog.save();
        }
    }
}
