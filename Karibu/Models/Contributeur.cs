using System;
using System.Collections.Generic;

namespace Karibu.Models
{
    public partial class Contributeur
    {
        public int Id { get; set; }
        public string? Surnom { get; set; }
        public string? NomComplet { get; set; }
        public string? Genre { get; set; }
        public string? Universite { get; set; }
        public string? Promotion { get; set; }
        public int? Annee { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
