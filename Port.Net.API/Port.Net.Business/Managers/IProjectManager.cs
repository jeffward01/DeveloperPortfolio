using Port.Net.Models.Dbo;
using System.Collections.Generic;
using Port.Net.Models.Dto;

namespace Port.Net.Business.Managers
{
    public interface IProjectManager
    {
        Project CreateProject(ProjectModel projectmodel);
        List<Project> GetAllBlockchainProjects();
        Project EditProject(ProjectModel project);
        Project DeleteProject(int projectId);
        List<Project> GetAll();
        Project GetById(int projectId);
        List<Project> GetAllFeaturedProjects();
        List<Project> GetAllUnFeaturedProjects();
        Project SetFeatured(int projectId);
        Project RemoveFeatured(int projectId);

    }
}