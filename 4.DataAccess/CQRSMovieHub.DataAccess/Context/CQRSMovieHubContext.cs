using CQRSMovieHub.Domain.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRSMovieHub.Queries.DataAccess.Implementations.Context
{
    public class CQRSMovieHubContext : DbContext
    {
        public virtual DbSet<Director> Director { get; set; }

        public virtual DbSet<Movie> Movie { get; set; }

        public CQRSMovieHubContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CQRSMovieHubContext).Assembly);
        }
    }
}
