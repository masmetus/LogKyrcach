using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace LogKyrcach.Models
{
    public partial class Workplace
    {
        public int Id { get; set; }
        [Display(Name = "Номер рабочего места")]
        public string Number { get; set; }
        public int? IdRoom { get; set; }
        public int IdComputer { get; set; }
        public int IdMonitor { get; set; }

        [Display(Name = "Инв. номер компьютера")]
        public virtual Computer IdComputerNavigation { get; set; }
        [Display(Name = "Инв. номер монитора")]
        public virtual Monitor IdMonitorNavigation { get; set; }
        public virtual Room IdRoomNavigation { get; set; }
    }
}
