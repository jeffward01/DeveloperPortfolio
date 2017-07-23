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
    [RoutePrefix("api/ProjectImage")]
    public class ProjectImageController : ApiController
    {
        private readonly IProjectManager _projectManager;
        private readonly IProjectImageManager _projectImageManager;

        public ProjectImageController(IProjectManager projectManager, IProjectImageManager projectImageManager)
        {
            _projectImageManager = projectImageManager;
            _projectManager = projectManager;
        }

        [HttpPost]
        [Route("AddImage/{projectId}")]
        public IHttpActionResult AddImage(ProjectImage projectImage, int projectId)
        {
            return Ok(_projectImageManager.AddImage(projectImage, projectId));
        }

        [HttpDelete]
        [Route("RemoveImage/{imageId}")]
        public IHttpActionResult RemoveImage(int imageId)
        {
            return Ok(_projectImageManager.Delete(imageId));
        }


        [HttpPut]
        [Route("EditImage")]
        public IHttpActionResult EditImage(ProjectImage projectImage)
        {
            return Ok(_projectImageManager.Edit(projectImage));
        }


    }
}