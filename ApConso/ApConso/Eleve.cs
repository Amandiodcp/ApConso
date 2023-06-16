using System;
using System.Collections.Generic;

namespace AppAmandio
{
    internal class Eleve
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public List<string> Cours { get; set; }

        public Eleve(int id, string nom, string prenom, DateTime dateNaissance)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            DateNaissance = dateNaissance;
            Cours = new List<string>();
        }
    }
}
