using Port.Net.Data.Infrastructure;
using Port.Net.Models.Dbo;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Port.Net.Data.Repositories
{
    public class ProjectTechnologyRepository : IProjectTechnologyRepository
    {
        public ProjectTechnology Create(ProjectTechnology technology)
        {
            using (var context = new PortfolioContext())
            {
                context.Entry(technology).State = EntityState.Added;
                context.SaveChanges();
                return technology;
            }
        }

        public ProjectTechnology Edit(ProjectTechnology technology)
        {
            using (var context = new PortfolioContext())
            {
                context.Entry(technology).State = EntityState.Modified;
                context.SaveChanges();
                return technology;
            }
        }

        public List<ProjectTechnology> GetAllByProjectId(int projectId)
        {
            using (var context = new PortfolioContext())
            {
                return context.ProjectTechnologies.Where(_ => _.ProjectId == projectId).ToList();
            }
        }

        public ProjectTechnology GetByTechnologyId(int techId)
        {
            using (var context = new PortfolioContext())
            {
                return context.ProjectTechnologies.FirstOrDefault(_ => _.ProjectTechnologyId == techId);
            }
        }

        public ProjectTechnology Delete(ProjectTechnology technology)
        {
            using (var context = new PortfolioContext())
            {
                context.Entry(technology).State = EntityState.Deleted;
                context.SaveChanges();
                return technology;
            }
        }
    }
}