using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace LogKyrcach.Models
{
    public partial class Request
    {
        public int Id { get; set; }
        [Display(Name = "Название программы")]
        public int InstalledsoftwareId { get; set; }
        [Display(Name ="Инвентарный номер компьютера")]
        public int IdComputer { get; set; }
        [Display(Name = "Статус заявки")]
        public bool? RequestStatus { get; set; }
        [Display(Name = "Дата создания")]
        public DateTime ApplicationDate { get; set; }
        [Display(Name = "Описание проблемы")]
        public string DescriptionOfTheProblem { get; set; }
        [Display(Name = "Дата закрытия заявки")]
        public DateTime? ApplicationClosingDate { get; set; }
        [Display(Name = "Имя инженера ыыыыыыыыыыыыы")]
        public int? IdEnginner { get; set; }

        [Display(Name = "Имя инженера")]
        public virtual Worker IdEnginnerNavigation { get; set; }
        [Display(Name = "Название программы")]
        public virtual Installedsoftware Installedsoftware { get; set; }
    }
}
