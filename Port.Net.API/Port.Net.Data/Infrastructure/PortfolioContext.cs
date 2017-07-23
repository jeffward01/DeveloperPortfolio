using Port.Net.Models.Dbo;
using System.Data.Entity;

namespace Port.Net.Data.Infrastructure
{
    public class PortfolioContext : DbContext, IPortfolioContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectImage> ProjectImages { get; set; }
        public DbSet<ProjectTechnology> ProjectTechnologies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasKey(_ => _.ProjectId);
            modelBuilder.Entity<Project>().HasMany(_ => _.ProjectImages)
                .WithOptional().HasForeignKey(_ => _.ProjectId).WillCascadeOnDelete(true);
            modelBuilder.Entity<Project>().HasMany(_ => _.ProjectTechnologies)
                .WithOptional().HasForeignKey(_ => _.ProjectId).WillCascadeOnDelete(true);

            modelBuilder.Entity<ProjectImage>().HasKey(_ => _.ProjectImageId);

            modelBuilder.Entity<ProjectTechnology>().HasKey(_ => _.ProjectTechnologyId);

            base.OnModelCreating(modelBuilder);
        }
    }

    public class MyDbContextInitializer : DropCreateDatabaseIfModelChanges<PortfolioContext>
    {
        protected override void Seed(PortfolioContext dbContext)
        {
            // seed data
            base.Seed(dbContext);

            dbContext.SaveChanges();
        }
    }
}