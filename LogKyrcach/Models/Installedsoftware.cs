using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "Дата активации лицензии")]
        public DateTime LicenseStart { get; set; }
        [Display(Name = "Дата окончания действия лицензии")]
        public DateTime LicenseEnd { get; set; }
        [Display(Name = "Тип лицензии")]
        public int TypeLicenseId { get; set; }
        public int IdEnginere { get; set; }
        [Display(Name="Дата установки")]
        public DateTime InstallationDate { get; set; }
        public bool? WorkStatus { get; set; }
        public int IdRoom { get; set; }

        [Display(Name = "Установивший инженер")]
        public virtual Worker IdEnginereNavigation { get; set; }
        [Display(Name = "Наименовани программы")]
        public virtual Software IdSoftwareNavigation { get; set; }
        [Display(Name = "Тип лицензии")]
        public virtual Typelicense TypeLicense { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}
