using System.Collections.Generic;
using System.Threading.Tasks;
using Port.Models;

namespace Port.Business.Managers
{
    public interface IGithubManager
    {
        Task<List<GithubRepo>> GetAllRepos();
        Task<GithubUserInfo> GetGithubUserInfo();
        Task<List<GithubRepo>> GetStarredRepos();
    }
}