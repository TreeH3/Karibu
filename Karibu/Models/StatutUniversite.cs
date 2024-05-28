using System;
using System.Collections.Generic;

namespace Karibu.Models
{
    public partial class StatutUniversite
    {
        public StatutUniversite()
        {
            Universites = new HashSet<Universite>();
        }

        public int IdStatutUniversite { get; set; }
        public string Statut { get; set; } = null!;

        public virtual ICollection<Universite> Universites { get; set; }
    }
}
