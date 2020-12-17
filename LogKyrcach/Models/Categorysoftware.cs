using System;
using System.Collections.Generic;

#nullable disable

namespace LogKyrcach.Models
{
    public partial class Categorysoftware
    {
        public Categorysoftware()
        {
            Softwares = new HashSet<Software>();
        }

        public int Id { get; set; }
        public string Category { get; set; }

        public virtual ICollection<Software> Softwares { get; set; }
    }
}
