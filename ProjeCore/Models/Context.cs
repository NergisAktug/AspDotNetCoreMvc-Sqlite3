using Microsoft.EntityFrameworkCore;
using ProjeCore.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjeCore.Models
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename = Birim.db");
        }
        public DbSet<Birim>  Birims{ get; set; }
        public DbSet<Personel>  Personels{ get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
