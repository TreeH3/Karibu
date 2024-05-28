using System;
using System.Collections.Generic;

namespace Karibu.Models
{
    public partial class Universite
    {
        public Universite()
        {
            Demandes = new HashSet<Demande>();
            Stagiaires = new HashSet<Stagiaire>();
        }

        public int IdUniversite { get; set; }
        public string Nom { get; set; } = null!;
        public string? Sigle { get; set; }
        public string? Adresse { get; set; }
        public string? NomRecteur { get; set; }
        public int IdStatutUniversite { get; set; }
        public int? IdTypeInstitut { get; set; }

        public virtual StatutUniversite IdStatutUniversiteNavigation { get; set; } = null!;
        public virtual TypeInstitut? IdTypeInstitutNavigation { get; set; }
        public virtual ICollection<Demande> Demandes { get; set; }
        public virtual ICollection<Stagiaire> Stagiaires { get; set; }
    }
}
