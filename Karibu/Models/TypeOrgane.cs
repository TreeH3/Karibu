using System;
using System.Collections.Generic;

namespace Karibu.Models
{
    public partial class TypeOrgane
    {
        public TypeOrgane()
        {
            Organes = new HashSet<Organe>();
        }

        public int IdTypeOrgane { get; set; }
        public string NomType { get; set; } = null!;

        public virtual ICollection<Organe> Organes { get; set; }
    }
}
