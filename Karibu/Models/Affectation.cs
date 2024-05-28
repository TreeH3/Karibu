using System;
using System.Collections.Generic;

namespace Karibu.Models
{
    public partial class Affectation
    {
        public int IdAffectation { get; set; }
        public DateTime Date { get; set; }
        public long IdStagiaire { get; set; }
        public string IdDirection { get; set; } = null!;
        public bool? EstAccepte { get; set; }
        public DateTime DateAcceptation { get; set; }

        public virtual Organe IdDirectionNavigation { get; set; } = null!;
        public virtual Stagiaire IdStagiaireNavigation { get; set; } = null!;
    }
}
