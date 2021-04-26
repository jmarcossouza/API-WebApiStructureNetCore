using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApiStructureNetCore.Entities;

namespace WebApiStructureNetCore.Data
{
    public class WebapiStructureDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<LogErrors> LogErrors { get; set; }

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
                .Property(x => x.Senha)
                .HasColumnType("varchar");

            var LogErrorsEntity = modelBuilder.Entity<LogErrors>();
            LogErrorsEntity
                .HasOne(c => c.Usuario)
                .WithMany(e => e.LogErrors)
                .OnDelete(DeleteBehavior.SetNull);
            LogErrorsEntity
                .Property(c => c.Resolvido)
                .HasDefaultValue(false);
            LogErrorsEntity
                .Property(x => x.Erro)
                .HasColumnType("varchar");
        }

        /// <summary>
        /// Método para "Detach" todas as entidades que estejam sendo rastreadas pelo contexto.
        /// Tive de implementar esse método pois se tentar usar o 'SaveChanges()' depois de ter dado algum erro em algum outro 'SaveChanges()' anterior, irá dar throw no primeiro erro ocorrido no 'SaveChanges()'.
        /// Portanto usar o 'DetachAllEntities()' após algum erro no 'SaveChanges()' se quiser executá-lo novamente.
        /// </summary>
        public void DetachAllEntities()
        {
            var changedEntriesCopy = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted)
                .ToList();

            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }
    }
}
