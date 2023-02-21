﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programmation_Systeme_Groupe_B.ViewModels
{
    class SaveProject
    {

        // State log object
        public ModelLogState stateLog;
        public ModelLogDaily dailyLog;
        public DateTime logStart;
        // Project Name
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        // Project State
        private string state;
        public string State
        {
            get { return state; }
            set { state = value; }
        }
        public string PercentProgression
        {
            get
            {
                return $"{getPercentage()}";
            }
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

        // Save Thread 
        private static Thread thread;
        public Thread Thread
        {
            get { return thread; }
            set { thread = value; }
        }

        // Priority files
        private List<string> priorityExtension;
        public List<string> PriorityExtension
        {
            get { return priorityExtension; }
            set { priorityExtension = value; }
        }

        // Max file Size
        private long maxFileSize;
        public long MaxFileSize
        {
            get { return maxFileSize; }
            set { maxFileSize = value; }
        }

        // Uncounted copied files (maxSize)
        private long uncountedCopiedSizeFiles;

        // Uncounted copied files (priority extension)
        private long tempPrioritySizeFile;

        //Work program
        //Work program
        private string workProgram;
        public string WorkProgram
        {
            get { return workProgram; }
            set { workProgram = value; }
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
            this.state = ModelLogState.STATE_CREATED;
            this.maxFileSize = 99999999999999999;
            this.priorityExtension = new() { };
            this.workProgram = "";
            this.uncountedCopiedSizeFiles = 0;
            this.tempPrioritySizeFile = 0;
        }

        public void Save()
        {
            if (this.state != ModelLogState.STATE_ACTIVE)
            {
                if (this.workProgram != "")
                {
                    Process[] process = Process.GetProcessesByName(this.workProgram);
                    if (process.Length > 0)
                    {
                        MessageBox.Show("Un logiciel metier est en cours d'utilisation");
                        process[0].WaitForExit();
                    }
                }


                this.progression.FilesSizeCopied = 0;
                this.progression.CopiedFiles = 0;
                this.uncountedCopiedSizeFiles = 0;
                this.tempPrioritySizeFile = 0;
                this.progression.FileSize = DirSize(new DirectoryInfo(this.pathSource));
                this.progression.FileAmount = Directory.GetFiles(this.pathSource, "*", SearchOption.AllDirectories).Length;
                this.logStart = DateTime.Now;

                DirectoryInfo mainDirectory = new DirectoryInfo(this.pathSource);

                // If the source directory does not exist, throw an exception. 
                if (!mainDirectory.Exists)
                {
                    throw new DirectoryNotFoundException(
                        "Source directory does not exist or could not be found: "
                        + this.pathSource);
                }
                GenerateStateLog(ModelLogState.STATE_START);


                if (this.saveType == SaveTypeEnum.Complete)
                {
                    this.state = ModelLogState.STATE_ACTIVE;
                    GenerateDailyLog();

                    // Thread
                    Thread thread = new Thread(() =>
                    {
                        // Priority File Handle
                        if (this.priorityExtension.Count == 0)
                        {
                            CompleteSave(this.pathSource, this.pathTarget, this.progression, "");

                        }
                        else
                        {
                            foreach (string extension in this.priorityExtension)
                            {
                                CompleteSave(this.pathSource, this.pathTarget, this.progression, extension);

                            }
                            CompleteSave(this.pathSource, this.pathTarget, this.progression, "");

                        }
                        state = ModelLogState.STATE_END;
                        GenerateStateLog(ModelLogState.STATE_END);


                    });
                    thread.Start();


                }
                else if (this.saveType == SaveTypeEnum.Differential)
                {
                    this.state = ModelLogState.STATE_ACTIVE;
                    GenerateDailyLog();

                    // Thread
                    Thread thread = new Thread(() =>
                    {
                        if (this.priorityExtension.Count == 0)
                        {

                            DifferentialSave(this.pathSource, this.pathTarget, this.progression, "");

                        }
                        else
                        {
                            foreach (string extension in this.priorityExtension)
                            {
                                DifferentialSave(this.pathSource, this.pathTarget, this.progression, extension);

                            }
                            DifferentialSave(this.pathSource, this.pathTarget, this.progression, "");

                        }
                        state = ModelLogState.STATE_END;
                        GenerateStateLog(ModelLogState.STATE_END);

                    });
                    thread.Start();

                }
            }

        }

        private void CompleteSave(string source, string target, Progression progression, string extension)
        {
            DirectoryInfo mainDirectory = new DirectoryInfo(source);
            DirectoryInfo[] subDirectory = mainDirectory.GetDirectories();

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
                if (extension.Equals("") || extension.Equals(file.Extension))
                {
                    if (file.Length * 1024 < this.maxFileSize)
                    {
                        //file.CopyTo(temppath, true);
                        Encrypt(file, temppath);

                    }
                    else
                    {
                        this.uncountedCopiedSizeFiles += file.Length;
                    }
                    progression.CopiedFiles += 1;
                    progression.FilesSizeCopied += file.Length;
                    /*Percentage*/

                }
                else
                {
                    this.tempPrioritySizeFile++;
                }

                if (getPercentage() > this.stateLog.progression && getPercentage() < 100)
                {
                    GenerateStateLog(ModelLogState.STATE_ACTIVE);
                }



            }

            foreach (DirectoryInfo subdir in subDirectory)
            {
                // Create the subdirectory.
                string temppath = Path.Combine(target, subdir.Name);

                // Copy the subdirectories.
                CompleteSave(subdir.FullName, temppath, progression, extension);
            }
        }
        private void Encrypt(FileInfo file, string outpath)
        {
            #region ProcessEncryptInit
            Process encrypt = new Process();
            string solutionpath = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent}";
            encrypt.StartInfo.FileName = $"{solutionpath}\\Cryptosoft\\bin\\Debug\\net5.0\\Cryptosoft.exe";
            encrypt.StartInfo.UseShellExecute = false;
            encrypt.StartInfo.CreateNoWindow = true;
            encrypt.Exited += Encrypt_Exited;
            #endregion ProcessEncryptInit

            encrypt.StartInfo.Arguments = $"\"{Path.Combine(file.DirectoryName, file.Name)}\" \"{file.Name}\" \"{outpath}\"";
            encrypt.Start();
            while (!encrypt.HasExited)
            {
                encrypt.WaitForExit();
            }
            //GenerateDailyLog();
            // Ajouter le log de l'encryptage
        }

        private void Encrypt_Exited(object sender, EventArgs e)
        {
            var process = sender as Process;
            Trace.WriteLine("HEYYYYY");
            if (process != null)
            {
                var exitcode = process.ExitCode;
                Trace.WriteLine(exitcode);
                dailyLog.encrypttime = $"{exitcode}";
                GenerateDailyLog();
            }
        }

        private void DifferentialSave(string source, string target, Progression progression, string extension)
        {
            DirectoryInfo mainDirectory = new DirectoryInfo(source);
            DirectoryInfo[] subDirectory = mainDirectory.GetDirectories();

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
                if (file.Length * 1024 < this.maxFileSize)
                {
                    // Copy the file. If it already exists, keep the most recent one.
                    if (!File.Exists(temppath))
                    {
                        // Copy the file.
                        if (extension.Equals("") || extension.Equals(file.Extension))
                        {
                            //file.CopyTo(temppath, false);
                            Encrypt(file, temppath);
                            progression.CopiedFiles += 1;
                            progression.FilesSizeCopied += file.Length;
                        }
                        else
                        {
                            this.tempPrioritySizeFile++;
                        }

                    }
                    else
                    {
                        if (extension.Equals("") || extension.Equals(file.Extension))
                        {
                            FileInfo fileInfoSource = new FileInfo(temppath);
                            DateTime fileSourceDate = file.CreationTime;
                            DateTime fileTargetDate = fileInfoSource.CreationTime;
                            if (fileSourceDate.CompareTo(fileTargetDate) < 0)
                            {
                                //file.CopyTo(temppath, true);
                                Encrypt(file, temppath);
                                progression.CopiedFiles += 1;
                                progression.FilesSizeCopied += file.Length;
                            }
                        }
                        else
                        {
                            this.tempPrioritySizeFile++;
                        }

                    }
                    /*Percentage*/

                    if (getPercentage() > this.stateLog.progression && getPercentage() < 100)
                    {
                        GenerateStateLog(ModelLogState.STATE_ACTIVE);
                    }
                }
                else
                {
                    this.uncountedCopiedSizeFiles += file.Length;
                }
            }

            foreach (DirectoryInfo subdir in subDirectory)
            {
                // Create the subdirectory.
                string temppath = Path.Combine(target, subdir.Name);

                // Copy the subdirectories.
                DifferentialSave(subdir.FullName, temppath, progression, extension);
            }
        }
        private long getPercentage()
        {
            if (this.progression.FileSize <= 0)
            {
                return 0;
            }
            return (this.progression.FilesSizeCopied - this.uncountedCopiedSizeFiles) * 100 / this.progression.FileSize - this.tempPrioritySizeFile;
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
            this.stateLog.priorityExtension = this.priorityExtension;
            this.stateLog.workProgram = this.workProgram;
            this.stateLog.maxFileSize = this.maxFileSize;
            this.stateLog.progression = getPercentage();
            this.stateLog.setState(state);
            if (this.stateLog.state == ModelLogState.STATE_ACTIVE)
            {
                this.stateLog.setTime((this.logStart - DateTime.Now).ToString());
            }
            else
            {
                this.stateLog.setTime(DateTime.Now.ToString());
            }

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

        public void ResumeThread()
        {
            if (thread != null) thread.Resume();
        }
        public void PauseThread()
        {
            if (thread != null) thread.Suspend();
        }
        public void DeleteThread()
        {
            if (thread != null) thread.Abort();
        }

        public bool RemovePriorityExtension(string extension)
        {
            return this.priorityExtension.Remove(extension);
        }
        public void AddPriorityExtension(string extension)
        {
            this.priorityExtension.Add(extension);
        }

        public List<string> GetPriorityExtension()
        {
            return this.priorityExtension;
        }



    }
}
