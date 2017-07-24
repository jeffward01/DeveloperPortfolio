using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Port.Net.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Email")]
    public class AuthenticateController : ApiController
    {
        private readonly string _adminPassword =  System.Configuration.ConfigurationManager.AppSettings["adminPassword"];
        [HttpGet]
        [Route("Auth")]
        public SqlBoolean SendEmail(string clientPassword)
        {
            return clientPassword == _adminPassword;
        }
    }
}