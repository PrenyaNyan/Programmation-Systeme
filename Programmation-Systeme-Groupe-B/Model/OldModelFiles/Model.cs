using System;
using System.Linq;
using System.IO;
using System.Text.Json;
using Programmation_Systeme_Groupe_B.Model.Langage;
using System.Threading;

namespace Programmation_Systeme_Groupe_B.Model
{
    class ModelClass
    {
        Setting setting;
        public ModelLangage modelLangage;
        public ModelSave ModelSave = new();
        private Thread remoteConnect;
        private ModelClass()
        {
            Server.SeConnecter();
            
            remoteConnect = new Thread(new ParameterizedThreadStart(Server.AccepterConnexion));
            remoteConnect.Start();
        }
        private static ModelClass modelClass;
        public static ModelClass GetModelClass()
        {
            if (modelClass is null)
            {
                modelClass = new();
            }
            return modelClass;
        }
    }
}