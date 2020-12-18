﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace LogKyrcach.Models
{
    public partial class Computer
    {
        public Computer()
        {
            Components = new HashSet<Component>();
            Workplaces = new HashSet<Workplace>();
        }

        public int Id { get; set; }
        [Display(Name = "Инв. номер компьютера")]
        public string Inv { get; set; }
        public int IdWorkPlace { get; set; }
        public int IdCompyterType { get; set; }
        public bool? IsWorking { get; set; }
        public int IdComponent { get; set; }

        public virtual Computertype IdCompyterTypeNavigation { get; set; }
        public virtual ICollection<Component> Components { get; set; }
        public virtual ICollection<Workplace> Workplaces { get; set; }
    }
}
