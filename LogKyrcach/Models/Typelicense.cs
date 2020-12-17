using System;
using System.Collections.Generic;

#nullable disable

namespace LogKyrcach.Models
{
    public partial class Typelicense
    {
        public Typelicense()
        {
            Installedsoftwares = new HashSet<Installedsoftware>();
        }

        public int Id { get; set; }
        public string TypeLicense1 { get; set; }

        public virtual ICollection<Installedsoftware> Installedsoftwares { get; set; }
    }
}
