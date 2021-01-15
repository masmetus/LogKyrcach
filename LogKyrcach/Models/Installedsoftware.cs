using System;
using System.Collections.Generic;

#nullable disable

namespace LogKyrcach.Models
{
    public partial class Installedsoftware
    {
        public Installedsoftware()
        {
            Requests = new HashSet<Request>();
        }

        public int Id { get; set; }
        public int IdSoftware { get; set; }
        public int IdComputer { get; set; }
        public DateTime LicenseStart { get; set; }
        public DateTime LicenseEnd { get; set; }
        public int TypeLicenseId { get; set; }
        public int IdEnginere { get; set; }
        public DateTime InstallationDate { get; set; }
        public bool? WorkStatus { get; set; }
        public int IdRoom { get; set; }

        public virtual Computer IdComputerNavigation { get; set; }
        public virtual Worker IdEnginereNavigation { get; set; }
        public virtual Room IdRoomNavigation { get; set; }
        public virtual Software IdSoftwareNavigation { get; set; }
        public virtual Typelicense TypeLicense { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}
