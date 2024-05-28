using System;
using System.Collections.Generic;

namespace Karibu.Models
{
    public partial class Prolongement
    {
        public int IdProlongement { get; set; }
        public string Motif { get; set; } = null!;
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public long IdStage { get; set; }

        public virtual Stage IdStageNavigation { get; set; } = null!;
    }
}
