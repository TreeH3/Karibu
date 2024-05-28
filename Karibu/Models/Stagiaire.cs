using System;
using System.Collections.Generic;

namespace Karibu.Models
{
    public partial class Stagiaire
    {
        public Stagiaire()
        {
            Affectations = new HashSet<Affectation>();
            Stages = new HashSet<Stage>();
        }

        public long IdStagiaire { get; set; }
        public string Nom { get; set; } = null!;
        public string? Postnom { get; set; }
        public string? Prenom { get; set; }
        public string? IdNationalite { get; set; }
        public string Genre { get; set; } = null!;
        public int? LieuNaissance { get; set; }
        public DateTime? DateNaissance { get; set; }
        public string AdresseDomicile { get; set; } = null!;
        public string Promotion { get; set; } = null!;
        public int? IdFilliere { get; set; }
        public int? IdUniversite { get; set; }
        public int? IdSujet { get; set; }
        public long? IdDemande { get; set; }
        public int? IdCommune { get; set; }
        public byte[]? Photo { get; set; }
        public DateTime DateEnregistrement { get; set; }

        public virtual Commune? IdCommuneNavigation { get; set; }
        public virtual Demande? IdDemandeNavigation { get; set; }
        public virtual Filiere? IdFilliereNavigation { get; set; }
        public virtual Pay? IdNationaliteNavigation { get; set; }
        public virtual Sujet? IdSujetNavigation { get; set; }
        public virtual Universite? IdUniversiteNavigation { get; set; }
        public virtual ICollection<Affectation> Affectations { get; set; }
        public virtual ICollection<Stage> Stages { get; set; }
    }
}
