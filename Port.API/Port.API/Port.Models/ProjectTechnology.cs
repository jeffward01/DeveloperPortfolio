namespace Port.Models
{
    public class ProjectTechnology
    {
        public int ProjectTechnologyId { get; set; }
        public string TechnologyName { get; set; }
        public Project Project { get; set; }
    }
}