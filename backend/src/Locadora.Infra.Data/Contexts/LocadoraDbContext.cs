using Locadora.Domain.Features.Genres;
using Locadora.Domain.Features.Movies;
using Locadora.Domain.Features.Rents;
using Locadora.Infra.Data.Features.Genres;
using Locadora.Infra.Data.Features.Movies;
using Locadora.Infra.Data.Features.Rents;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Infra.Data.Contexts
{
    public class LocadoraDbContext : DbContext
    {
        public LocadoraDbContext(DbContextOptions<LocadoraDbContext> options) : base(options)
        {
        }

        protected LocadoraDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Rent> Rents { get; set; }

        /// <summary>
        /// Método que é executado quando o modelo de banco de dados está sendo criado pelo EF.
        /// Útil para realizar configurações
        /// </summary>
        /// <param name="modelBuilder">É o construtor de modelos do EF</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GenreEntityConfiguration());
            modelBuilder.ApplyConfiguration(new MovieEntityConfiguration());
            modelBuilder.ApplyConfiguration(new RentEntityConfiguration());

            modelBuilder.HasDefaultSchema("locadora");

            // Chama o OnModelCreating do EF para dar continuidade na criação do modelo
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(false);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
