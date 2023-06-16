
using Newtonsoft.Json;

namespace AppAmandio
{
    class Program
    {
        static void Main(string[] args)
        {
          
            if (args.Length == 0)
            {
                Console.WriteLine("start let's go");
                return;
            }
            
            string filePath = args[0];

            List<Eleve> eleves = LoadData(filePath);

            MenuManager.MainMenu(eleves, filePath);
        }

        static List<Eleve> LoadData(string filePath)
        {
            if (File.Exists(filePath))
            {
                Console.WriteLine("chargement du fichier " + filePath);
                string jsonData = File.ReadAllText(filePath);
                List<Eleve> eleves = JsonConvert.DeserializeObject<List<Eleve>>(jsonData);
                return eleves;
            }
            else
            {
                return new List<Eleve>();
            }
        }

        public static void SaveData(string filePath, List<Eleve> eleves)
        {
            string jsonData = JsonConvert.SerializeObject(eleves);
            File.WriteAllText(filePath, jsonData);
            Console.WriteLine("enregistre !");
        }
    }
}


