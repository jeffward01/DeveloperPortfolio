using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Port.Net.Models.Dto
{
    [DataContract]
    public class ProjectModel
    {
        [DataMember(Name = "ProjectId")]
        public int? ProjectId { get; set; }

        [DataMember(Name = "ProjectName")]
        public string ProjectName { get; set; }

        [DataMember(Name = "ShortDesc")]
        public string ShortDesc { get; set; }

        [DataMember(Name = "projectSummary")]
        public string ProjectSummary { get; set; }

        [DataMember(Name = "RepoUrl")]
        public string RepoUrl { get; set; }

        [DataMember(Name = "FeaturedProject")]
        public bool FeaturedProject { get; set; }

        [DataMember(Name = "BlockchainProject")]
        public bool BlockchainProject { get; set; }

        [DataMember(Name = "projectTechnologies")]
        public virtual List<ProjectTechModel> ProjectTechnologies { get; set; }

        [DataMember(Name = "projectImages")]
        public virtual List<ProjectImageModel> ProjectImages { get; set; }
    }
}