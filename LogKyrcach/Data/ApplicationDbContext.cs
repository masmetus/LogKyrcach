using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LogKyrcach.Models;

namespace LogKyrcach.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //public DbSet<LogKyrcach.Models.Worker> Worker { get; set; }

        public DbSet<Microsoft.AspNetCore.Identity.IdentityRole> Roles { get; set; }
    }
}
