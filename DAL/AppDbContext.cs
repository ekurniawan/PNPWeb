using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyASPApp.Models;

namespace MyASPApp.DAL
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Trainer> Trainers { get; set; }
    }
}