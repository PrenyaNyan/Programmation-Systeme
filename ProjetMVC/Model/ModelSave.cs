using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetMVC.Model
{
    enum SaveType
    {
        Differential,
        Complete
    }
    class ModelSave
    {
        public string Name { get; set; }
        public string SourcePath { get; set; }
        public string DestPath { get; set; }
        public SaveType savetype { get; set; }
    }
}
