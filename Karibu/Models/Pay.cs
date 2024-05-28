using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Karibu.Models
{
    public partial class Pay
    {
        public Pay()
        {
            Demandes = new HashSet<Demande>();
            Stagiaires = new HashSet<Stagiaire>();
        }

        [DisplayName("Id")]
        public string IdPays { get; set; } = null!;
        [DisplayName("Pays")]
        public string? NomPays { get; set; }

        public virtual ICollection<Demande> Demandes { get; set; }
        public virtual ICollection<Stagiaire> Stagiaires { get; set; }
    }
}
