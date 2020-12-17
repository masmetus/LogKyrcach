using System;
using System.Collections.Generic;

#nullable disable

namespace LogKyrcach.Models
{
    public partial class Request
    {
        public int Id { get; set; }
        public int InstalledsoftwareId { get; set; }
        public int IdComputer { get; set; }
        public bool? RequestStatus { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string DescriptionOfTheProblem { get; set; }
        public DateTime? ApplicationClosingDate { get; set; }
        public int? IdEnginner { get; set; }

        public virtual Worker IdEnginnerNavigation { get; set; }
        public virtual Installedsoftware Installedsoftware { get; set; }
    }
}
