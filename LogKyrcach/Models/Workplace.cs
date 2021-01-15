using System;
using System.Collections.Generic;

#nullable disable

namespace LogKyrcach.Models
{
    public partial class Workplace
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int? IdRoom { get; set; }
        public int IdComputer { get; set; }
        public int IdMonitor { get; set; }

        public virtual Computer IdComputerNavigation { get; set; }
        public virtual Monitor IdMonitorNavigation { get; set; }
        public virtual Room IdRoomNavigation { get; set; }
    }
}
