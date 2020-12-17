using System;
using System.Collections.Generic;

#nullable disable

namespace LogKyrcach.Models
{
    public partial class Institute
    {
        public Institute()
        {
            Departments = new HashSet<Department>();
        }

        public int Id { get; set; }
        public string InstituteName { get; set; }

        public virtual ICollection<Department> Departments { get; set; }
    }
}
