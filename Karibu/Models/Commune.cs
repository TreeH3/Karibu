using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Karibu.Models
{
    public partial class Commune
    {
        public Commune()
        {
            Demandes = new HashSet<Demande>();
            Stagiaires = new HashSet<Stagiaire>();
        }

        [DisplayName("Id")]
        public int IdCommune { get; set; }
        [DisplayName("Commune")]
        public string NomCommune { get; set; } = null!;

        public virtual ICollection<Demande> Demandes { get; set; }
        public virtual ICollection<Stagiaire> Stagiaires { get; set; }
    }
}
