using System;
using System.Collections.Generic;
using System.Text;

namespace Port.Models
{
    public class ProjectImage
    {
        public int ProjectImageId { get; set; }
        public int ProjectId { get; set; }
        public string ImageUrl { get; set; }

        public bool FeaturedImage { get; set; }
        public virtual Project Project { get; set; }
    }
}
