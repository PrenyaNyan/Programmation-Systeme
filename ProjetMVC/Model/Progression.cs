using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetMVC.Model
{
    class Progression
    {
        // Remaining file amount
        private int remainingFileAmount;
        public int RemainingFileAmount

        {
            get { return remainingFileAmount; }
            set { remainingFileAmount = value; }
        }
        // Remaining file size 
        private int remainingFileSize;
        public int RemainingFileSize
        {
            get { return remainingFileSize; }
            set { remainingFileSize = value; }
        }

        public Progression(int remainingFileAmount, int remainingFileSize)
        {
            this.remainingFileAmount = remainingFileAmount;
            this.remainingFileSize = remainingFileSize;
        }
    }
}
