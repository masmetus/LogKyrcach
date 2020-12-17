using System;
using System.Collections.Generic;

#nullable disable

namespace LogKyrcach.Models
{
    public partial class PostType
    {
        public PostType()
        {
            Workers = new HashSet<Worker>();
        }

        public int Id { get; set; }
        public string PostType1 { get; set; }

        public virtual ICollection<Worker> Workers { get; set; }
    }
}
