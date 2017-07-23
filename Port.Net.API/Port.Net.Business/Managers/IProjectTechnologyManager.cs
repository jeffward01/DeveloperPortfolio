using Port.Net.Models.Dbo;

namespace Port.Net.Business.Managers
{
    public interface IProjectTechnologyManager
    {
        ProjectTechnology AddTech(ProjectTechnology tech, int projectId);
        ProjectTechnology Edit(ProjectTechnology tech);
        ProjectTechnology Delete(int techId);

    }
}