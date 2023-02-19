using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ProjetMVC.Model
{
    class ModelSave
    {
        private List<SaveProject> projects;
        private ModelLogState stateLog;
        private string saveFilePath = "projects.json";
        public List<SaveProject> Projects
        {
            get { return projects; }
        }

        public void addProject(SaveProject project)
        {
            this.projects.Add(project);
            // Ajout du projet au fichier de config
            SaveProjectToFile(project, this.saveFilePath);

            //Log creation
            project.GenerateStateLog(ModelLogState.STATE_CREATED);

        }

        public void RetrieveProject(string path)
        {
            // Lire l'objet associé avec le nom et le charger;
            string jsonPath = File.ReadAllText(path);
            this.projects = JsonConvert.DeserializeObject<List<SaveProject>>(jsonPath);
        }

        private void SaveProjectToFile(SaveProject project, string path)
        {
            string jsonPath = File.ReadAllText(path);
            var json = JsonConvert.DeserializeObject<JArray>(jsonPath);
            var objectContent = JsonBuilder(project);
            json.Add(objectContent);
            File.WriteAllText(path, json.ToString());
        }

        public void InitializeJsonFile(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
                File.WriteAllText(path, "[]");
                this.projects = new List<SaveProject>();
            }
            else
            {
                RetrieveProject(path);
            }
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
