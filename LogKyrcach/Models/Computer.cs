using System;
using System.Collections.Generic;

#nullable disable

namespace LogKyrcach.Models
{
    public partial class Computer
    {
        public Computer()
        {
            Components = new HashSet<Component>();
            Installedsoftwares = new HashSet<Installedsoftware>();
            Workplaces = new HashSet<Workplace>();
        }

        public int Id { get; set; }
        public string Inv { get; set; }
        public int IdWorkPlace { get; set; }
        public int IdCompyterType { get; set; }
        public bool? IsWorking { get; set; }
        public int IdComponent { get; set; }

        public virtual Computertype IdCompyterTypeNavigation { get; set; }
        public virtual ICollection<Component> Components { get; set; }
        public virtual ICollection<Installedsoftware> Installedsoftwares { get; set; }
        public virtual ICollection<Workplace> Workplaces { get; set; }
    }
}
