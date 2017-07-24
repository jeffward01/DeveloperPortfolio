using System.Collections.Generic;

namespace Port.Net.Models.Dbo
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ShortDesc { get; set; }
        public string ProjectSummary { get; set; }
        public string RepoUrl { get; set; }

        public bool FeaturedProject { get; set; }
        public bool BlockchainProject { get; set; }

        public string FeaturedImageUrl
        {
            get
            {
                var imageUrl = "";
                if (ProjectImages != null)
                {
                    foreach (var image in ProjectImages)
                    {
                        if (image.FeaturedImage)
                        {
                            imageUrl = image.ImageUrl;
                        }
                    }
                }
                  return imageUrl;


            }
        }

        public virtual List<ProjectTechnology> ProjectTechnologies { get; set; }

        public virtual List<ProjectImage> ProjectImages { get; set; }
    }
}