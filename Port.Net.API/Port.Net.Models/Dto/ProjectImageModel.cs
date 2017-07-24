using System.Runtime.Serialization;

namespace Port.Net.Models.Dto
{
    [DataContract]
    public class ProjectImageModel
    {
        [DataMember(Name = "ProjectId")]
        public int? ProjectId { get; set; }

        [DataMember(Name = "ImageUrl")]
        public string ImageUrl { get; set; }

        [DataMember(Name = "FeaturedImage")]
        public bool FeaturedImage { get; set; }

        [DataMember(Name = "ProjectImageId")]
        public int? ProjectImageId { get; set; }
    }
}