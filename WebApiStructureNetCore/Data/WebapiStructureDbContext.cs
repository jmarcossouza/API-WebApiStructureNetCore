using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiStructureNetCore.Models;

namespace WebApiStructureNetCore.Data
{
    public class WebapiStructureDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public WebapiStructureDbContext(DbContextOptions<WebapiStructureDbContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Connection string here
            optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=WebapiStructureDatabase;Data Source=DESKTOP-5DKEVPB");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var UsuarioEntity = modelBuilder.Entity<Usuario>();
            UsuarioEntity
                .HasIndex(e => e.Email)
                .IsUnique();
            UsuarioEntity
                .Property(x => x.CriadoEm)
                .HasColumnType("smalldatetime");
        }
    }
}
