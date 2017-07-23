using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Port.Net.Business.Managers;
using Port.Net.Models.Dbo;

namespace Port.Net.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/ProjectTechnology")]
    public class ProjectTechnologyController : ApiController
    {
        private readonly IProjectManager _projectManager;
        private readonly IProjectTechnologyManager _projectTechnologyManager;

        public ProjectTechnologyController(IProjectManager projectManager, IProjectTechnologyManager projectTechnologyManager)
        {
            _projectTechnologyManager = projectTechnologyManager;
            _projectManager = projectManager;
        }

        [HttpPost]
        [Route("AddTechnology/{projectId}")]
        public IHttpActionResult AddTechnology(ProjectTechnology projectTechnology, int projectId)
        {
            return Ok(_projectTechnologyManager.AddTech(projectTechnology, projectId));
        }

        [HttpDelete]
        [Route("RemoveTechnology/{TechnologyId}")]
        public IHttpActionResult RemoveTechnology(int techId)
        {
            return Ok(_projectTechnologyManager.Delete(techId));
        }


        [HttpPut]
        [Route("EditTechnology")]
        public IHttpActionResult EditTechnology(ProjectTechnology projectTechnology)
        {
            return Ok(_projectTechnologyManager.Edit(projectTechnology));
        }

    }
}