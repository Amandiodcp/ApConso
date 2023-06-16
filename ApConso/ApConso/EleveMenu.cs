using System;
using System.Collections.Generic;

namespace AppAmandio
{
    static class EleveMenu
    {
        public static void LesEleveMenu(List<Eleve> eleves)
        {
            while (true)
            {
                Console.WriteLine("menu eleve");
                Console.WriteLine("1. Lister les élèves");
                Console.WriteLine("2. Créer un nouvel élève");
                Console.WriteLine("3. Consulter un élève");
                Console.WriteLine("4. Menu");

                Console.Write("Choix : ");
                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        AfficherEleves(eleves);
                        break;
                    case "2":
                        CreerEleve(eleves);
                        break;
                    case "3":
                        ConsulterEleve(eleves);
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("selection invalide.");
                        break;
                }

                Console.WriteLine();
            }

        }

        static void AfficherEleves(List<Eleve> eleves)
        {
            Console.WriteLine("LES ELEVES");

            if (eleves.Count == 0)
            {
                Console.WriteLine("Aucun élève trouvé.");
            }
            else
            {
                foreach (Eleve eleve in eleves)
                {
                    Console.WriteLine($"ID : {eleve.Id}");
                    Console.WriteLine($"Nom : {eleve.Nom}");
                    Console.WriteLine($"Prénom : {eleve.Prenom}");
                    Console.WriteLine($"Date de naissance : {eleve.DateNaissance.ToShortDateString()}");
                    Console.WriteLine($"Cours : {eleve.Cours.Count}");
                    Console.WriteLine();
                }
            }
        }

        static void CreerEleve(List<Eleve> eleves)
        {
            Console.WriteLine("---- CREER UN NOUVEL ELEVE ----");

            Console.Write("ID : ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
            {
                Console.WriteLine("ID invalide. Veuillez entrer un entier positif.");
                Console.Write("ID : ");
            }

            Console.Write("Nom : ");
            string nom = Console.ReadLine();

            Console.Write("Prénom : ");
            string prenom = Console.ReadLine();

            Console.Write("Date de naissance (jj/mm/aaaa) : ");
            DateTime dateNaissance;
            while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dateNaissance))
            {
                Console.WriteLine("Date de naissance invalide. Veuillez entrer une date au format jj/mm/aaaa.");
                Console.Write("Date de naissance (jj/mm/aaaa) : ");
            }

            Eleve nouvelEleve = new Eleve(id, nom, prenom, dateNaissance);
            eleves.Add(nouvelEleve);

            Console.WriteLine("Elève créé avec succès !");
        }

        static void ConsulterEleve(List<Eleve> eleves)
        {
            Console.WriteLine("---- CONSULTER UN ELEVE ----");

            Console.Write("ID de l'élève : ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
            {
                Console.WriteLine("ID invalide. Veuillez entrer un entier positif.");
                Console.Write("ID de l'élève : ");
            }

            Eleve eleve = eleves.Find(e => e.Id == id);

            if (eleve == null)
            {
                Console.WriteLine("Aucun élève trouvé avec cet ID.");
            }
            else
            {
                Console.WriteLine($"ID : {eleve.Id}");
                Console.WriteLine($"Nom : {eleve.Nom}");
                Console.WriteLine($"Prénom : {eleve.Prenom}");
                Console.WriteLine($"Date de naissance : {eleve.DateNaissance.ToShortDateString()}");
                Console.WriteLine($"Cours : {eleve.Cours.Count}");
                Console.WriteLine();
            }
        }
    }
}
