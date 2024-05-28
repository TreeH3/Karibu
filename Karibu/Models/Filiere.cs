using System;
using System.Collections.Generic;

namespace Karibu.Models
{
    public partial class Filiere
    {
        public Filiere()
        {
            Demandes = new HashSet<Demande>();
            Stagiaires = new HashSet<Stagiaire>();
        }

        public int IdFiliere { get; set; }
        public string Nom { get; set; } = null!;

        public virtual ICollection<Demande> Demandes { get; set; }
        public virtual ICollection<Stagiaire> Stagiaires { get; set; }
    }
}
