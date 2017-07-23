using System.Collections.Generic;
using System.Threading.Tasks;
using Port.Net.Models.Dto;

namespace Port.Net.Business.Managers
{
    public interface IGithubManager
    {
        Task<List<GithubRepo>> GetAllRepos();
        Task<GithubUserInfo> GetGithubUserInfo();
        Task<List<GithubRepo>> GetStarredRepos();
    }
}