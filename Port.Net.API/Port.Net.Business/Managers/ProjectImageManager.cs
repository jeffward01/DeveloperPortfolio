using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Port.Net.Data.Repositories;
using Port.Net.Models.Dbo;

namespace Port.Net.Business.Managers
{
    public class ProjectImageManager : IProjectImageManager
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IProjectImageRepository _projectImageRepository;

        public ProjectImageManager(IProjectRepository projectRepository, IProjectImageRepository projectImageRepository)
        {
            _projectRepository = projectRepository;
            _projectImageRepository = projectImageRepository;
        }

        public ProjectImage AddImage(ProjectImage image, int projectId)
        {
            image.ProjectId = projectId;
            return _projectImageRepository.Create(image);
        }

        public ProjectImage Edit(ProjectImage image)
        {
            return _projectImageRepository.Edit(image);
        }

        public ProjectImage Delete(int imageId)
        {
            var image = _projectImageRepository.GetByImageId(imageId);
            return _projectImageRepository.Delete(image);
        }
    }
}
