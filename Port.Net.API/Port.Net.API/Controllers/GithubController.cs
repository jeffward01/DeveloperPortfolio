using Port.Net.Business.Managers;
using Port.Net.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Port.Net.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/githubInfo")]
    public class GithubController : ApiController
    {
        private readonly IGithubManager _githubManager;

        public GithubController(IGithubManager githubManager)
        {
            _githubManager = githubManager;
        }

        [HttpGet]
     //   [Route("get")]
         [Route("getUserInfo")]
        public async Task<GithubUserInfo> GetUserInfo()
        {
            return await _githubManager.GetGithubUserInfo();
        }

        [HttpGet]
        [Route("userRepos")]
        public async Task<List<GithubRepo>> GetUserRepos()
        {
            return await _githubManager.GetAllRepos();
        }

        [HttpGet]
        [Route("userStarredRepos")]
        public async Task<List<GithubRepo>> GetUserStarredRepos()
        {
            return await _githubManager.GetStarredRepos();
        }
    }
}