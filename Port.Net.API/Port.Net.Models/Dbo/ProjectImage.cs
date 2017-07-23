namespace Port.Net.Models.Dbo
{
    public class ProjectImage
    {
        public int ProjectImageId { get; set; }
        public int ProjectId { get; set; }
        public string ImageUrl { get; set; }
        public bool FeaturedImage { get; set; }
    }
}