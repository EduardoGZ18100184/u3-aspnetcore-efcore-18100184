using System;
using System.Collections.Generic;

#nullable disable

namespace u3_aspnetcore_efcore_18100184.Models
{
    public partial class Productora
    {
        public Productora()
        {
            Series = new HashSet<Serie>();
        }

        public int IdProductora { get; set; }
        public string NombreProductora { get; set; }

        public virtual ICollection<Serie> Series { get; set; }
    }
}
