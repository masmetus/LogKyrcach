using System;
using System.Collections.Generic;

#nullable disable

namespace LogKyrcach.Models
{
    public partial class Monitor
    {
        public Monitor()
        {
            Workplaces = new HashSet<Workplace>();
        }

        public int Id { get; set; }
        public string Model { get; set; }
        public string SN { get; set; }
        public string Inv { get; set; }
        public bool? IsWorking { get; set; }
        public int IdWorkPlace { get; set; }

        public virtual ICollection<Workplace> Workplaces { get; set; }
    }
}
