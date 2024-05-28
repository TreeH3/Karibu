using System;
using System.Collections.Generic;

namespace Karibu.Models
{
    public partial class TypeInstitut
    {
        public TypeInstitut()
        {
            Universites = new HashSet<Universite>();
        }

        public int IdTypeInstitut { get; set; }
        public string Type { get; set; } = null!;

        public virtual ICollection<Universite> Universites { get; set; }
    }
}
