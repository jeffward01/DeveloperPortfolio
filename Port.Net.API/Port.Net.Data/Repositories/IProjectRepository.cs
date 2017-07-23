using System.Collections.Generic;
using Port.Net.Models.Dbo;

namespace Port.Net.Data.Repositories
{
    public interface IProjectRepository
    {
        Project Create(Project project);
        Project Edit(Project project);
        List<Project> GetAllProjects();
        Project GetById(int projectId);
        Project Delete(Project project);
        List<Project> GetAllFeaturedProjects();
        List<Project> GetAllUnFeaturedProjects();
    }
}