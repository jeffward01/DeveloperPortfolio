using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Port.Data.Infrastructure;
using Port.Models;

namespace Port.Data.Repositories
{
    public class ProjectRepository
    {
        public ProjectRepository()
        {
            
        }

        public Project CreateProject(Project project)
        {
            using (var context = new PortfolioContext())
            {
                context.Entry(project).Entity = EntityState.Added;
                context.SaveChanges();
                return project;
            }
        }
    }
}
