using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Port.Net.Business.Managers;
using Port.Net.Models.Dbo;
using Port.Net.Models.Dto;

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
        [Route("GetProjectbyId/{projectId}")]
        public IHttpActionResult GetProjectbyId(int projectId)
        {
            return Ok(_projectManager.GetById(projectId));
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
        public IHttpActionResult CreateProject(ProjectModel project)
        {
            return Ok(_projectManager.CreateProject(project));
        }

        [HttpPost]
        [Route("EditProject")]
        public IHttpActionResult EditProject(ProjectModel project)
        {
            return Ok(_projectManager.EditProject(project));
        }


        [HttpPost]
        [Route("DeleteProject/{projectId}")]
        public IHttpActionResult DeleteProject(int projectId)
        {
            return Ok(_projectManager.DeleteProject(projectId));
        }
    }
}