using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NLog;
using Port.Business.Managers;
using Port.Models.Settings;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Server;
using Port.Models;

namespace Port.API.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private readonly AppSettings _appSettings;
        private readonly DatabaseSettings _databaseSettings;
        private readonly IGithubManager _githubManager;

        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        // private readonly ITestManager _testManager;

        public TestController(IOptions<AppSettings> appSettings, IOptions<DatabaseSettings> databaseSettings, IGithubManager githubManager)//, ITestManager testManager)
        {
            //  _testManager = testManager;
            _githubManager = githubManager;
            _databaseSettings = databaseSettings.Value;
            _appSettings = appSettings.Value;
        }

        // GET api/values
        [HttpGet("getTest")]
        public IEnumerable<string> Get()
        {
            _logger.Debug("Endpoint Hit");
            _logger.Info("Index page says hello");

            return new string[] { "val22ue1", "value2", "33223", _appSettings.MainUrl, _databaseSettings.ConnectionString };
        }

        [HttpGet("userInfo")]
        public async Task<GithubUserInfo> GetUserInfo()
        {
            return await _githubManager.GetGithubUserInfo();
        }
        [HttpGet("userRepos")]
        public async Task<List<GithubRepo>> GetUserRepos()
        {
            return await _githubManager.GetAllRepos();
        }
        [HttpGet("userStarredRepos")]
        public async Task<List<GithubRepo>> GetUserStarredRepos()
        {
            return await _githubManager.GetStarredRepos();
        }
       // // GET api/values/5
       // [HttpGet("{id}")]
       // public string Get(int id)
       // {
       //     return "value";
       // }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}