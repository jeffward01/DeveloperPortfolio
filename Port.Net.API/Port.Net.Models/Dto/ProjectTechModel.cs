using System.Runtime.Serialization;

namespace Port.Net.Models.Dto
{
    [DataContract]
    public class ProjectTechModel
    {
        [DataMember(Name = "TechnologyName")]
        public string TechnologyName { get; set; }

        [DataMember(Name = "ProjectTechnologyId")]
        public int? ProjectTechnologyId { get; set; }

        [DataMember(Name = "ProjectId")]
        public int? ProjectId { get; set; }
    }
}