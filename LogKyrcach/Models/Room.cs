﻿using System;
using System.Collections.Generic;

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
        public string RoomNumber { get; set; }
        public int IdDepartment { get; set; }

        public virtual Department IdDepartmentNavigation { get; set; }
        public virtual ICollection<Workplace> Workplaces { get; set; }
    }
}
