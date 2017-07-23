using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Port.Models;

namespace Port.Data.Infrastructure
{
    public class PortfolioContext : DbContext
    {
        public string _connectionString { get; set; }

        public PortfolioContext(DbContextOptions<PortfolioContext> options, string connectionString) : base(options)
        {
            _connectionString = connectionString;
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectImage> ProjectImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasKey(_ => _.ProjectId);
            modelBuilder.Entity<Project>().HasMany(_ => _.ProjectImages).WithOne(_ => _.Project).OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            updateUpdatedProperty<Project>();

            return base.SaveChanges();
        }

        private void updateUpdatedProperty<T>() where T : class
        {
            var modifiedSourceInfo =
                ChangeTracker.Entries<T>()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            //foreach (var entry in modifiedSourceInfo)
            //{
            //    entry.Property("UpdatedTimestamp").CurrentValue = DateTime.UtcNow;
            //}
        }
    }
}