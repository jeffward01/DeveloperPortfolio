using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Port.Net.Data.Infrastructure;
using Port.Net.Models.Dbo;

namespace Port.Net.Data.Repositories
{
    public class ProjectImageRepository : IProjectImageRepository
    {
        public ProjectImage Create(ProjectImage image)
        {
            using (var context = new PortfolioContext())
            {
                context.Entry(image).State = EntityState.Added;
                context.SaveChanges();
                return image;
            }
        }

        public List<int> GetAllIdsFor(int projectId)
        {
            using (var context = new PortfolioContext())
            {
                return context.ProjectImages.Where(_ => _.ProjectId == projectId)
                    .Select(_ => _.ProjectImageId).ToList();
            }
        }
        public ProjectImage Edit(ProjectImage image)
        {
            using (var context = new PortfolioContext())
            {
                context.Entry(image).State = EntityState.Modified;
                context.SaveChanges();
                return image;
            }
        }

        public List<ProjectImage> GetAllByProjectId(int projectId)
        {
            using (var context = new PortfolioContext())
            {
                return context.ProjectImages.Where(_ => _.ProjectId == projectId).ToList();
            }
        }

        public ProjectImage GetByImageId(int imageId)
        {
            using (var context = new PortfolioContext())
            {
                return context.ProjectImages.FirstOrDefault(_ => _.ProjectImageId == imageId);
            }
        }

        public ProjectImage Delete(ProjectImage image)
        {
            using (var context = new PortfolioContext())
            {
                context.Entry(image).State = EntityState.Deleted;
                context.SaveChanges();
                return image;
            }
        }
    }
}
