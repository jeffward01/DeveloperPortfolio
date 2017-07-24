using Port.Net.Data.Repositories;
using Port.Net.Models.Dbo;
using Port.Net.Models.Dto;
using System.Collections.Generic;
using System.Linq;

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
        public List<Project> GetAllBlockchainProjects()
        {
            return _projectRepository.GetAllBlockchainProjects();
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

        public Project CreateProject(ProjectModel projectmodel)
        {
            //cast to dbo
            var project = CastToDbo(projectmodel);
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

            if (_projectImagesUrls != null)
            {
                foreach (var image in _projectImagesUrls)
                {
                    image.ProjectId = savedProject.ProjectId;
                    _projectImageRepository.Create(image);
                }
            }

            return _projectRepository.GetById(savedProject.ProjectId);
        }

        public Project EditProject(ProjectModel projectModel)
        {
            var project = CastToDbo(projectModel);
            var _projectTechnologies = project.ProjectTechnologies;
            var _projectImagesUrls = project.ProjectImages;

            project.ProjectTechnologies = null;
            project.ProjectImages = null;

            var savedProject = _projectRepository.Edit(project);

            if (_projectTechnologies != null)
            {
                foreach (var tech in _projectTechnologies)
                {
                    if (tech.ProjectTechnologyId != 0)
                    {
                        tech.ProjectId = savedProject.ProjectId;
                        _projectTechnologyRepository.Edit(tech);
                    }
                    else
                    {
                        _projectTechnologyRepository.Create(tech);
                    }
                }

                //delete all deleted techs
                var techsToSave = _projectTechnologies.Select(_ => _.ProjectTechnologyId);
                var allTechIds = _projectTechnologyRepository.GetAllIdsFor(savedProject.ProjectId);
                var idsToDelete = allTechIds.Except(techsToSave).ToList();
                foreach (var id in idsToDelete)
                {
                    var tech = _projectTechnologyRepository.GetByTechnologyId(id);
                    _projectTechnologyRepository.Delete(tech);
                }
            }

            if (_projectImagesUrls != null)
            {
                foreach (var image in _projectImagesUrls)
                {
                    if (image.ProjectImageId != 0)
                    {
                        image.ProjectId = savedProject.ProjectId;
                        _projectImageRepository.Edit(image);
                    }
                    else
                    {
                        _projectImageRepository.Create(image);
                    }
                }
                //delete all deleted techs
                var techsToSave = _projectImagesUrls.Select(_ => _.ProjectImageId);
                var allImageIds = _projectImageRepository.GetAllIdsFor(savedProject.ProjectId);
                var idsToDelete = allImageIds.Except(techsToSave).ToList();
                foreach (var id in idsToDelete)
                {
                    var tech = _projectImageRepository.GetByImageId(id);
                    _projectImageRepository.Delete(tech);
                }
            }

            return _projectRepository.GetById(project.ProjectId);
        }

        public Project DeleteProject(int projectid)
        {
            return _projectRepository.Delete(projectid);
        }

        private Project CastToDbo(ProjectModel projectModel)
        {
            var projectId = 0;
            if (projectModel.ProjectId != null)
            {
                projectId = projectModel.ProjectId.Value;
            }
            List<ProjectImage> projectImages = castToDboImages(projectModel.ProjectImages);
            List<ProjectTechnology> projectTechnologies = castToDboTech(projectModel.ProjectTechnologies);
            return new Project
            {
                ProjectId = projectId,
                BlockchainProject = projectModel.BlockchainProject,
                ProjectName = projectModel.ProjectName,
                ProjectSummary = projectModel.ProjectSummary,
                ShortDesc = projectModel.ShortDesc,
                RepoUrl = projectModel.RepoUrl,
                ProjectTechnologies = projectTechnologies,
                ProjectImages = projectImages,
                FeaturedProject = projectModel.FeaturedProject
            };
        }

        private List<ProjectImage> castToDboImages(List<ProjectImageModel> projectImageModels)
        {
            List<ProjectImage> projectImages = new List<ProjectImage>();
            foreach (var projectImageModel in projectImageModels)
            {
                var imageId = 0;
                var projectId = 0;

                if (projectImageModel.ProjectImageId != null)
                {
                    imageId = projectImageModel.ProjectImageId.Value;
                }

                if (projectImageModel.ProjectId != null)
                {
                    projectId = projectImageModel.ProjectId.Value;
                }

                projectImages.Add(new ProjectImage
                {
                    ProjectId = projectId,
                    ProjectImageId = imageId,
                    FeaturedImage = projectImageModel.FeaturedImage,
                    ImageUrl = projectImageModel.ImageUrl
                });
            }
            return projectImages;
        }

        private List<ProjectTechnology> castToDboTech(List<ProjectTechModel> projectTechModels)
        {
            List<ProjectTechnology> projectTechs = new List<ProjectTechnology>();
            foreach (var tech in projectTechModels)
            {
                var projectTechId = 0;
                var projectId = 0;
                if (tech.ProjectTechnologyId != null)
                {
                    projectTechId = tech.ProjectTechnologyId.Value;
                }

                if (tech.ProjectId != null)
                {
                    projectId = tech.ProjectId.Value;
                }

                projectTechs.Add(new ProjectTechnology
                {
                    ProjectTechnologyId = projectTechId,
                    ProjectId = projectId,
                    TechnologyName = tech.TechnologyName
                });
            }
            return projectTechs;
        }
    }
}