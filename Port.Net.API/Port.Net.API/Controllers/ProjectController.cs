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
    [RoutePrefix("api/Project")]
    public class ProjectController : ApiController
    {
        private readonly IProjectManager _projectManager;

        public ProjectController(IProjectManager projectManager)
        {
            _projectManager = projectManager;
        }

        [HttpGet]
        [Route("GetAllProjects")]
        public IHttpActionResult GetAllProjects()
        {
            return Ok(_projectManager.GetAll());
        }

        [HttpGet]
        [Route("GetAllFeaturedProjects")]
        public IHttpActionResult GetAllFeaturedProjects()
        {
            return Ok(_projectManager.GetAllFeaturedProjects());
        }

        [HttpGet]
        [Route("GetAllUnFeaturedProjects")]
        public IHttpActionResult GetAllUnFeaturedProjects()
        {
            return Ok(_projectManager.GetAllUnFeaturedProjects());
        }

        [HttpPost]
        [Route("CreateProject")]
        public IHttpActionResult CreateProject(Project project)
        {
            return Ok(_projectManager.CreateProject(project));
        }

        [HttpPut]
        [Route("EditProject")]
        public IHttpActionResult EditProject(Project project)
        {
            return Ok(_projectManager.EditProject(project));
        }


        [HttpDelete]
        [Route("DeleteProject")]
        public IHttpActionResult DeleteProject(Project project)
        {
            return Ok(_projectManager.DeleteProject(project));
        }
    }
}