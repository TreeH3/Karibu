using System;
using System.Collections.Generic;

namespace Karibu.Models
{
    public partial class Stage
    {
        public Stage()
        {
            Cotations = new HashSet<Cotation>();
            Prolongements = new HashSet<Prolongement>();
        }

        public long IdStage { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public long IdStagiaire { get; set; }
        public string IdService { get; set; } = null!;
        public DateTime DateEnregistrement { get; set; }

        public virtual Organe IdServiceNavigation { get; set; } = null!;
        public virtual Stagiaire IdStagiaireNavigation { get; set; } = null!;
        public virtual ICollection<Cotation> Cotations { get; set; }
        public virtual ICollection<Prolongement> Prolongements { get; set; }
    }
}
