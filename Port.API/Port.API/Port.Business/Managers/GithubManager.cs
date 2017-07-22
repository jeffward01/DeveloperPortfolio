using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Port.Data.Providers;
using Port.Models;

namespace Port.Business.Managers
{
    public class GithubManager : IGithubManager
    {
        private readonly IGithubProvider _githubProvider;

        public GithubManager(IGithubProvider githubProvider)
        {
            _githubProvider = githubProvider;
        }

        public async Task<List<GithubRepo>> GetAllRepos()
        {
            return await _githubProvider.GetAllGithubRepos();
        }

        public async Task<GithubUserInfo> GetGithubUserInfo()
        {
            return await _githubProvider.GetGithubUserInfo();
        }

        public async Task<List<GithubRepo>> GetStarredRepos()
        {
            var repos = await _githubProvider.GetAllGithubRepos();
            return repos.Where(_ => _.stargazers_count > 0).ToList();
        }


    }
}
