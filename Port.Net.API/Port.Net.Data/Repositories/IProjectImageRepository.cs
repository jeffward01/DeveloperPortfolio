using Port.Net.Models.Dbo;
using System.Collections.Generic;

namespace Port.Net.Data.Repositories
{
    public interface IProjectImageRepository
    {
        ProjectImage Create(ProjectImage image);

        ProjectImage Edit(ProjectImage image);

        List<ProjectImage> GetAllByProjectId(int projectId);

        ProjectImage GetByImageId(int imageId);

        ProjectImage Delete(ProjectImage image);
    }
}