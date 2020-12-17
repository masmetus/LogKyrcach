using System;
using System.Collections.Generic;

#nullable disable

namespace LogKyrcach.Models
{
    public partial class Component
    {
        public int Id { get; set; }
        public int IdComponentType { get; set; }
        public string Specs { get; set; }
        public string SN { get; set; }
        public bool? IsWorking { get; set; }
        public int? IdComputer { get; set; }

        public virtual Computertype IdComponentTypeNavigation { get; set; }
        public virtual Computer IdComputerNavigation { get; set; }
    }
}
