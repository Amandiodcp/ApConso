﻿using System;
using System.Collections.Generic;

namespace AppAmandio
{
    static class MenuManager
    {
        public static void MainMenu(List<Eleve> eleves, string filePath)
        {
            while (true)
            {
                Console.WriteLine("-----MENU------");
                Console.WriteLine("1. Elèves");
                Console.WriteLine("2. Cours");
                Console.WriteLine("3. Sortir");

                Console.Write("-Sélectionne un Numero/option: ");
                string selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        EleveMenu.LesEleveMenu(eleves);
                        break;
                    case "2":
                        CoursMenu.LesCoursMenu(eleves);
                        break;
                    case "3":
                        Program.SaveData(filePath, eleves);
                        return;
                    default:
                        Console.WriteLine("Selection invalide.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
