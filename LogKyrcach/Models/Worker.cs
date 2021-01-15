using System;
using System.Collections.Generic;

#nullable disable

namespace LogKyrcach.Models
{
    public partial class Worker
    {
        public Worker()
        {
            Installedsoftwares = new HashSet<Installedsoftware>();
            Requests = new HashSet<Request>();
        }

        public int Id { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public int PostId { get; set; }
        public int DepartmentNameId { get; set; }

        public virtual Department DepartmentName { get; set; }
        public virtual PostType Post { get; set; }
        public virtual ICollection<Installedsoftware> Installedsoftwares { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}
