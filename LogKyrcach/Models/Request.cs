using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace LogKyrcach.Models
{
    public partial class Request
    {
        public int Id { get; set; }
        [Display(Name ="Номер кабинета")]
        public int IdRoom { get; set; }
        [Display(Name = "Инв. номер компьютера")]
        public int IdComputer { get; set; }
        public int InstalledsoftwareId { get; set; }
        [Display(Name = "Статус")]
        public bool? RequestStatus { get; set; }
        [Display(Name = "Дата создания")]
        public DateTime ApplicationDate { get; set; }
        [Display(Name = "Описание проблемы")]
        public string DescriptionOfTheProblem { get; set; }
        [Display(Name = "Дата закрытия")]
        public DateTime? ApplicationClosingDate { get; set; }

        public int? IdEngineer { get; set; }

        [Display(Name = "Инженер")]
        public virtual Worker IdEngineerNavigation { get; set; }
        [Display(Name = "Номер кабинета")]
        public virtual Room IdRoomNavigation { get; set; }
        [Display(Name = "Название программы")]
        public virtual Installedsoftware Installedsoftware { get; set; }
    }
}
