using System;
using System.Collections.Generic;

#nullable disable

namespace LogKyrcach.Models
{
    public partial class Department
    {
        public Department()
        {
            Rooms = new HashSet<Room>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int InstituteId { get; set; }
        public int WorkersId { get; set; }

        public virtual Institute Institute { get; set; }
        public virtual Worker Workers { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
