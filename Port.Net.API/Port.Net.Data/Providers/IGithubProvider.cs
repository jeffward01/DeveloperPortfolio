using System.Collections.Generic;
using System.Threading.Tasks;
using Port.Net.Models.Dto;

namespace Port.Net.Data.Providers
{
    public interface IGithubProvider
    {
        Task<GithubUserInfo> GetGithubUserInfo();
        Task<List<GithubRepo>> GetAllGithubRepos();
    }
}