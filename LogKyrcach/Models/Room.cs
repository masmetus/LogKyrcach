using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace LogKyrcach.Models
{
    public partial class Room
    {
        public Room()
        {
            Workplaces = new HashSet<Workplace>();
        }

        public int Id { get; set; }
        [Display(Name = "Номер кабинета")]
        public string RoomNumber { get; set; }
        public int IdDepartment { get; set; }

        [Display(Name = "Кафедра")]
        public virtual Department IdDepartmentNavigation { get; set; }
        public virtual ICollection<Workplace> Workplaces { get; set; }
    }
}
