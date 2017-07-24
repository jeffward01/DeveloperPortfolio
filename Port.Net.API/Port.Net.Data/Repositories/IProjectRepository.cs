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
        List<Project> GetAllBlockchainProjects();
        Project Delete(int projectId);
        List<Project> GetAllFeaturedProjects();
        List<Project> GetAllUnFeaturedProjects();
    }
}