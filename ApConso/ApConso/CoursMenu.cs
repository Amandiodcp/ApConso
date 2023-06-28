using System;
using System.Collections.Generic;

namespace AppAmandio
{
    static class CoursMenu
    {
        public static void LesCoursMenu(List<Eleve> eleves)
        {
            while (true)
            {
                Console.WriteLine("-----MENU COURS-----");
                Console.WriteLine("1. Lister les cours");
                Console.WriteLine("2. Ajouter un nouveau cours");
                Console.WriteLine("3. Supprimer un cours");
                Console.WriteLine("4. Revenir au menu principal");

                Console.Write("Choix : ");
                string? choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        AfficherCours(eleves);
                        break;
                    case "2":
                        AjouterCours(eleves);
                        break;
                    case "3":
                        SupprimerCours(eleves);
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Choix invalide.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void AfficherCours(List<Eleve> eleves)
        {
            Console.WriteLine("---- COURS ----");

            List<string> cours = new List<string>();

            foreach (Eleve eleve in eleves)
            {
                foreach (string coursEleve in eleve.Cours)
                {
                    if (!cours.Contains(coursEleve))
                    {
                        cours.Add(coursEleve);
                    }
                }
            }

            if (cours.Count == 0)
            {
                Console.WriteLine("Aucun cours trouvé.");
            }
            else
            {
                foreach (string coursItem in cours)
                {
                    Console.WriteLine(coursItem);
                }
            }
        }

        static void AjouterCours(List<Eleve> eleves)
        {
            Console.WriteLine("--AJOUTER COURS--");

            Console.Write("ID de l'élève : ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
            {
                Console.WriteLine("error , un numero");
                Console.Write("ID de l'élève : ");
            }

            Eleve eleve = eleves.Find(e => e.Id == id);

            if (eleve == null)
            {
                Console.WriteLine("Pas d'ID trouvé.");
                return;
            }

            Console.Write("Nom du cours : ");
            string nomCours = Console.ReadLine();

            eleve.Cours.Add(nomCours);

            Console.WriteLine("Cours ajouté avec succès !");
        }

        static void SupprimerCours(List<Eleve> eleves)
        {
            Console.WriteLine("--SUPPRIMER UN COURS--");

            Console.Write("ID de l'élève : ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
            {
                Console.WriteLine("error. Veuillez entrer un numero.");
                Console.Write("ID de l'élève : ");
            }

            Eleve eleve = eleves.Find(e => e.Id == id);

            if (eleve == null)
            {
                Console.WriteLine("Aucun élève trouvé avec cet ID.");
                return;
            }

            Console.Write("Nom du cours : ");
            string nomCours = Console.ReadLine();

            if (eleve.Cours.Contains(nomCours))
            {
                eleve.Cours.Remove(nomCours);
                Console.WriteLine("Cours supprimé avec succès !");
            }
            else
            {
                Console.WriteLine("Le cours n'est pas inscrit pour cet élève.");
            }
        }
    }
}


