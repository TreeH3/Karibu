using System;
using System.Collections.Generic;

namespace Karibu.Models
{
    public partial class Sujet
    {
        public Sujet()
        {
            Stagiaires = new HashSet<Stagiaire>();
        }

        public int IdSujet { get; set; }
        public string Titre { get; set; } = null!;
        public string? Description { get; set; }
        public int? IdDomaine { get; set; }

        public virtual Categorie? IdDomaineNavigation { get; set; }
        public virtual ICollection<Stagiaire> Stagiaires { get; set; }
    }
}
