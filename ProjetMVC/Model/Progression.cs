using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetMVC.Model
{
    class Progression
    {
        // File copied amount
        private int copiedFiles;
        public int CopiedFiles

        {
            get { return copiedFiles; }
            set { copiedFiles = value; }
        }
        // Size file copied
        private long filesSizeCopied;
        public long FilesSizeCopied
        {
            get { return filesSizeCopied; }
            set { filesSizeCopied = value; }
        }

        // Total file amount
        private int fileAmount;
        public int FileAmount

        {
            get { return fileAmount; }
            set { fileAmount = value; }
        }

        // Total file size 
        private long fileSize;
        public long FileSize
        {
            get { return fileSize; }
            set { fileSize = value; }
        }

        public Progression(int copiedFiles, int fileAmount, long filesSizeCopied, long fileSize)
        {
            this.copiedFiles = copiedFiles;
            this.fileAmount = fileAmount;
            this.filesSizeCopied = filesSizeCopied;
            this.fileSize = fileSize;
        }
        public Progression()
        {
            this.copiedFiles = 0;
            this.fileAmount = 0;
            this.filesSizeCopied = 0;
            this.fileSize = 0;
        }
    }
}
