using Port.Net.Data.Repositories;
using Port.Net.Models.Dbo;

namespace Port.Net.Business.Managers
{
    public class ProjectTechnologyManager : IProjectTechnologyManager
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IProjectTechnologyRepository _projectTechnologyRepository;

        public ProjectTechnologyManager(IProjectRepository projectRepository, IProjectTechnologyRepository projectTechnologyRepository)
        {
            _projectRepository = projectRepository;
            _projectTechnologyRepository = projectTechnologyRepository;
        }

        public ProjectTechnology AddTech(ProjectTechnology tech, int projectId)
        {
            tech.ProjectId = projectId;
            return _projectTechnologyRepository.Create(tech);
        }

        public ProjectTechnology Edit(ProjectTechnology tech)
        {
            return _projectTechnologyRepository.Edit(tech);
        }

        public ProjectTechnology Delete(int techId)
        {
            var tech = _projectTechnologyRepository.GetByTechnologyId(techId);
            return _projectTechnologyRepository.Delete(tech);
        }
    }
}