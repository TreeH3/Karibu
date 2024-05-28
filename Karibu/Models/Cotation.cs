using System;
using System.Collections.Generic;

namespace Karibu.Models
{
    public partial class Cotation
    {
        public int IdCotation { get; set; }
        public long? IdStage { get; set; }
        public decimal? Presentation { get; set; }
        public decimal? Cooperation { get; set; }
        public decimal? Discipline { get; set; }
        public decimal? QuantiteTravail { get; set; }
        public decimal? QualiteTravail { get; set; }
        public decimal? Organisation { get; set; }
        public decimal? Perfectionnement { get; set; }
        public decimal? Regularite { get; set; }
        public decimal? Generale { get; set; }
        public string? Commentaire { get; set; }
        public DateTime DateEnregistrement { get; set; }

        public virtual Stage? IdStageNavigation { get; set; }
    }
}
