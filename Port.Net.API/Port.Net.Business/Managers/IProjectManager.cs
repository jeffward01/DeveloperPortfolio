using Port.Net.Models.Dbo;
using System.Collections.Generic;

namespace Port.Net.Business.Managers
{
    public interface IProjectManager
    {
        Project CreateProject(Project project);
        Project EditProject(Project project);
        Project DeleteProject(Project project);
        List<Project> GetAll();
        Project GetById(int projectId);
        List<Project> GetAllFeaturedProjects();
        List<Project> GetAllUnFeaturedProjects();
        Project SetFeatured(int projectId);
        Project RemoveFeatured(int projectId);

    }
}