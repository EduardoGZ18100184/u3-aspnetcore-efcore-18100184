using System;
using System.Collections.Generic;

#nullable disable

namespace u3_aspnetcore_efcore_18100184.Models
{
    public partial class Serie
    {
        public int SerieId { get; set; }
        public string NombreSerie { get; set; }
        public int IdProductora { get; set; }

        public virtual Productora IdProductoraNavigation { get; set; }
    }
}
