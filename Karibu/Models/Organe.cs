using System;
using System.Collections.Generic;

namespace Karibu.Models
{
    public partial class Organe
    {
        public Organe()
        {
            Affectations = new HashSet<Affectation>();
            InverseIdOrganeParentNavigation = new HashSet<Organe>();
            Stages = new HashSet<Stage>();
        }

        public string IdOrgane { get; set; } = null!;
        public string NomOrgane { get; set; } = null!;
        public int IdTypeOrgane { get; set; }
        public string? IdOrganeParent { get; set; }

        public virtual Organe? IdOrganeParentNavigation { get; set; }
        public virtual TypeOrgane IdTypeOrganeNavigation { get; set; } = null!;
        public virtual ICollection<Affectation> Affectations { get; set; }
        public virtual ICollection<Organe> InverseIdOrganeParentNavigation { get; set; }
        public virtual ICollection<Stage> Stages { get; set; }
    }
}
