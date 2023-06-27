using Microsoft.EntityFrameworkCore;
using Watchflix.Api.Movies.Models.Entities;
using Watchflix.Shared.Models;

namespace Watchflix.Api.Movies.EntityFramework
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Category>().HasData(DataSeeding.SeedCategories());
            //modelBuilder.Entity<Movie>().HasData(DataSeeding.SeedMovies());
            //modelBuilder.Entity<Series>().HasData(DataSeeding.SeedSeries());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<Category> Categories { get; set; }

        public override int SaveChanges()
        {
            GenerateDateTime();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            GenerateDateTime();
            return base.SaveChangesAsync(cancellationToken);
        }

        protected void GenerateDateTime()
        {
            var entities = ChangeTracker.Entries<BaseEntity>();

            foreach (var entity in entities)
            {
                _ = entity.State switch
                {
                    EntityState.Added => entity.Entity.CreatedDate = DateTime.Now,
                    EntityState.Modified => entity.Entity.UpdatedDate = DateTime.Now,
                    _ => DateTime.Now
                };
            }
        }
    }

    
}
