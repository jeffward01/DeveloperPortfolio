using Port.Net.Business.Managers;
using Port.Net.Models.Dto;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Port.Net.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Email")]
    public class EmailController : ApiController
    {
        private readonly IEmailManager _emailManager;

        public EmailController(IEmailManager emailManager)
        {
            _emailManager = emailManager;
        }

        [HttpPost]
        [Route("SendEmail")]
        public IHttpActionResult SendEmail(EmailModel email)
        {
            var result = _emailManager.SendEmail(email);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Error sending email");
            }
        }
    }
}