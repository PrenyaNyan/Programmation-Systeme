using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using Programmation_Systeme_Groupe_B.Model;
using JsonSerializer = System.Text.Json.JsonSerializer;
using System.Collections.ObjectModel;

namespace Programmation_Systeme_Groupe_B.Model
{
    class ModelSave
    {
        private ObservableCollection<SaveProject> projects = new ObservableCollection<SaveProject>();
        //private ModelLogState stateLog;
        private string saveFilePath = "projects.json";
        public ObservableCollection<SaveProject> Projects
        {
            get { return projects; }
        }

        public void addProject(SaveProject project)
        {
            this.projects.Add(project);
            // Ajout du projet au fichier de config
            // Add the project to config file
            SaveProjectToFile(project, this.saveFilePath);

            //Log creation
            project.GenerateStateLog(ModelLogState.STATE_CREATED);

        }

        public void RetrieveProject(string path)
        {
            // Lire l'objet associé avec le nom et le charger;
            // Read the object with associated name and load it
            string jsonPath = File.ReadAllText(path);
            this.projects = JsonConvert.DeserializeObject<ObservableCollection<SaveProject>>(jsonPath);
        }

        private void SaveProjectToFile(SaveProject project, string path)
        {
            // Save the project into a file
            string jsonPath = File.ReadAllText(path);
            var json = JsonConvert.DeserializeObject<JArray>(jsonPath);
            var objectContent = JsonBuilder(project);
            json.Add(objectContent);
            File.WriteAllText(path, json.ToString());
        }

        public void InitializeJsonFile(string path)
        {
            if (!File.Exists(path))
                // Create a project file if it doesn't exist
            {
                File.Create(path).Close();
                File.WriteAllText(path, "[]");
                this.projects = new ObservableCollection<SaveProject>();
                return;
            }
            // Recover all SaveProjects that are saved into the .json file
            RetrieveProject(path);
        }

        public static JObject JsonBuilder(object obj)
        {
            string StringObjectContent = JsonSerializer.Serialize(obj);
            return JsonConvert.DeserializeObject<JObject>(StringObjectContent);
        }

        public ModelSave()
        {
            InitializeJsonFile(this.saveFilePath);
        }

        public bool NameAlreadyExist(string name)
        {
            bool isPresent = false;
            foreach(SaveProject p in this.Projects)
            {
                if (p.Name.Equals(name)) isPresent = true;
            }
            return isPresent;
        }
    }
}
