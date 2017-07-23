using Port.Net.Models.Dbo;

namespace Port.Net.Business.Managers
{
    public interface IProjectImageManager
    {
        ProjectImage AddImage(ProjectImage image, int projectId);
        ProjectImage Edit(ProjectImage image);
        ProjectImage Delete(int imageId);
    }
}