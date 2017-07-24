using Port.Net.Data.Infrastructure;
using Port.Net.Models.Dbo;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Port.Net.Data.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        public Project Create(Project project)
        {
            using (var context = new PortfolioContext())
            {
                context.Entry(project).State = EntityState.Added;
                context.SaveChanges();
                return project;
            }
        }

        public Project Edit(Project project)
        {
            using (var context = new PortfolioContext())
            {
                context.Entry(project).State = EntityState.Modified;
                context.SaveChanges();
                return project;
            }
        }

        public List<Project> GetAllProjects()
        {
            using (var context = new PortfolioContext())
            {
                return context.Projects
                    .Include("ProjectTechnologies")
                    .Include("ProjectImages").ToList();


            }
        }
        public List<Project> GetAllFeaturedProjects()
        {
            using (var context = new PortfolioContext())
            {
                return context.Projects
                    .Include("ProjectTechnologies")
                    .Include("ProjectImages").Where(_ => _.FeaturedProject == true).ToList();


            }
        }

        public List<Project> GetAllUnFeaturedProjects()
        {
            using (var context = new PortfolioContext())
            {
                return context.Projects
                    .Include("ProjectTechnologies")
                    .Include("ProjectImages").Where(_ => _.FeaturedProject == false).ToList();


            }
        }
        public Project GetById(int projectId)
        {
            using (var context = new PortfolioContext())
            {
                return context.Projects
                    .Include("ProjectTechnologies")
                    .Include("ProjectImages")
                    .FirstOrDefault(_ => _.ProjectId == projectId);
            }
        }

        public Project Delete(int projectId)
        {
            using (var context = new PortfolioContext())
            {
                var project = context.Projects.FirstOrDefault(_ => _.ProjectId == projectId);
                context.Entry(project).State = EntityState.Deleted;
                context.SaveChanges();
                return project;
            }
        }
    }
}