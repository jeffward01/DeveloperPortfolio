using Port.Net.Data.Repositories;
using Port.Net.Models.Dbo;
using System.Collections.Generic;

namespace Port.Net.Business.Managers
{
    public class ProjectManager : IProjectManager
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IProjectTechnologyRepository _projectTechnologyRepository;
        private readonly IProjectImageRepository _projectImageRepository;

        public ProjectManager(IProjectRepository projectRepository, IProjectTechnologyRepository projectTechnologyRepository, IProjectImageRepository projectImageRepository)
        {
            _projectRepository = projectRepository;
            _projectTechnologyRepository = projectTechnologyRepository;
            _projectImageRepository = projectImageRepository;
        }

        //Get All
        public List<Project> GetAll()
        {
            return _projectRepository.GetAllProjects();
        }

        public Project GetById(int projectId)
        {
            return _projectRepository.GetById(projectId);
        }

        public List<Project> GetAllFeaturedProjects()
        {
            return _projectRepository.GetAllFeaturedProjects();
        }

        public List<Project> GetAllUnFeaturedProjects()
        {
            return _projectRepository.GetAllUnFeaturedProjects();
        }

        public Project SetFeatured(int projectId)
        {
            var project = _projectRepository.GetById(projectId);
            project.FeaturedProject = true;
            return _projectRepository.Edit(project);
        }

        public Project RemoveFeatured(int projectId)
        {
            var project = _projectRepository.GetById(projectId);
            project.FeaturedProject = false;
            return _projectRepository.Edit(project);
        }

        public Project CreateProject(Project project)
        {
            var _projectTechnologies = project.ProjectTechnologies;
            var _projectImagesUrls = project.ProjectImages;

            project.ProjectTechnologies = null;
            project.ProjectImages = null;

            var savedProject = _projectRepository.Create(project);

            if (_projectTechnologies != null)
            {
                foreach (var tech in _projectTechnologies)
                {
                    tech.ProjectId = savedProject.ProjectId;
                    _projectTechnologyRepository.Create(tech);
                }
            }

            if (project.ProjectTechnologies != null)
            {
                foreach (var image in _projectImagesUrls)
                {
                    image.ProjectId = savedProject.ProjectId;
                    _projectImageRepository.Create(image);
                }
            }

            return _projectRepository.GetById(savedProject.ProjectId);
        }

        public Project EditProject(Project project)
        {
            return _projectRepository.Edit(project);
        }

        public Project DeleteProject(Project project)
        {
            return _projectRepository.Delete(project);
        }
    }
}