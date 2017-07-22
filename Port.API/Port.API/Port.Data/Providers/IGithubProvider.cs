using System.Collections.Generic;
using System.Threading.Tasks;
using Port.Models;

namespace Port.Data.Providers
{
    public interface IGithubProvider
    {
        Task<GithubUserInfo> GetGithubUserInfo();
        Task<List<GithubRepo>> GetAllGithubRepos();
    }
}