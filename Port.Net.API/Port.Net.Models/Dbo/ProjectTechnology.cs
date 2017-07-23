using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Port.Net.Models.Dbo
{
    public class ProjectTechnology
    {
        public int ProjectTechnologyId { get; set; }
        public int ProjectId { get; set; }
        public string TechnologyName { get; set; }
    }
}
