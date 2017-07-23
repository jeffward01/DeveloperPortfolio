using Port.Net.Data.Utility;
using Port.Net.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Port.Net.Data.Providers
{
    public class GithubProvider : IGithubProvider
    {
        private readonly IHttpProvider _httpProvider;

        public GithubProvider(IHttpProvider provider)
        {
            _httpProvider = provider;
        }

        public async Task<GithubUserInfo> GetGithubUserInfo()
        {
            var info = await _httpProvider.GetGithubInfoTask(UrlBuilderUtil.GetGithubUserInfoApiString());
            return JsonUtil.DeserializeObject<GithubUserInfo>(info);
        }

        public async Task<List<GithubRepo>> GetAllGithubRepos()
        {
            var info = await _httpProvider.GetGithubInfoTask(UrlBuilderUtil.GetGithubReposApiString());
            return JsonUtil.DeserializeObject<List<GithubRepo>>(info);
        }
    }
}