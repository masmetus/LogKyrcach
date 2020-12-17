using System;
using System.Collections.Generic;

#nullable disable

namespace LogKyrcach.Models
{
    public partial class Software
    {
        public Software()
        {
            Installedsoftwares = new HashSet<Installedsoftware>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int IdCompany { get; set; }
        public int IdCategory { get; set; }

        public virtual Categorysoftware IdCategoryNavigation { get; set; }
        public virtual Company IdCompanyNavigation { get; set; }
        public virtual ICollection<Installedsoftware> Installedsoftwares { get; set; }
    }
}
