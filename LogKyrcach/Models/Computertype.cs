using System;
using System.Collections.Generic;

#nullable disable

namespace LogKyrcach.Models
{
    public partial class Computertype
    {
        public Computertype()
        {
            Components = new HashSet<Component>();
            Computers = new HashSet<Computer>();
        }

        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Component> Components { get; set; }
        public virtual ICollection<Computer> Computers { get; set; }
    }
}
