using System.Collections.Generic;
using Port.Net.Models.Dbo;

namespace Port.Net.Data.Repositories
{
    public interface IProjectTechnologyRepository
    {
        ProjectTechnology Create(ProjectTechnology technology);
        ProjectTechnology Edit(ProjectTechnology technology);
        List<ProjectTechnology> GetAllByProjectId(int projectId);
        ProjectTechnology GetByTechnologyId(int techId);
        ProjectTechnology Delete(ProjectTechnology technology);
    }
}