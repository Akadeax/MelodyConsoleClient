using System;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace MelodyConsoleClient
{
    class SaveLoadHandler
    {
        public static void Save(string path, Client clientState)
        {
            string json = JsonConvert.SerializeObject(clientState);
            File.WriteAllText(path, json);
        }

        public static Client Load(string path)
        {
            string file = File.ReadAllText(path);
            Client obj = JsonConvert.DeserializeObject<Client>(file);
            return obj;

        }
    }
}
