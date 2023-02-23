﻿using System;
using System.Linq;
using System.IO;
using System.Text.Json;
using Programmation_Systeme_Groupe_B.Model.Langage;

namespace Programmation_Systeme_Groupe_B.Model
{
    class ModelClass
    {
        Setting setting;
        public ModelLangage modelLangage;
        public ModelSave ModelSave = new();
        private ModelClass()
        {

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