using System;
using System.Collections.Generic;

#nullable disable

namespace LogKyrcach.Models
{
    public partial class Company
    {
        public Company()
        {
            Softwares = new HashSet<Software>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactInfoSupport { get; set; }

        public virtual ICollection<Software> Softwares { get; set; }
    }
}
