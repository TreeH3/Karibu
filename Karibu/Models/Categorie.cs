using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Karibu.Models
{
    public partial class Categorie
    {
        public Categorie()
        {
            Demandes = new HashSet<Demande>();
            Sujets = new HashSet<Sujet>();
        }

        [DisplayName("Id")]
        public int IdCategorie { get; set; }
        [DisplayName("Domaine du sujet TFC/Mémoire")]
        public string Domaine { get; set; } = null!;

        public virtual ICollection<Demande> Demandes { get; set; }
        public virtual ICollection<Sujet> Sujets { get; set; }
    }
}
