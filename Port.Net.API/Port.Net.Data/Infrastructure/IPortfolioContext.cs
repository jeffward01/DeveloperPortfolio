using System.Data.Entity;
using Port.Net.Models.Dbo;

namespace Port.Net.Data.Infrastructure
{
    public interface IPortfolioContext
    {
        DbSet<Project> Projects { get; set; }
        DbSet<ProjectImage> ProjectImages { get; set; }
        DbSet<ProjectTechnology> ProjectTechnologies { get; set; }
        int SaveChanges();
    }
}