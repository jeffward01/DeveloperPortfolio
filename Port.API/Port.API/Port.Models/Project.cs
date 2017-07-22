using System.Collections.Generic;

namespace Port.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ShortDesc { get; set; }
        public string ProjectSummary { get; set; }
        public string RepoUrl { get; set; }

        public bool FeaturedProject { get; set; }
        public virtual List<ProjectTechnology> ProjectTechnologies { get; set; }

        public virtual List<ProjectImage> ProjectImages { get; set; }
    }
}