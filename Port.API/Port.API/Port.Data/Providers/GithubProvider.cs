using Microsoft.Extensions.Options;
using Port.Data.Utility;
using Port.Models;
using Port.Models.Settings;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Port.Data.Providers
{
    public class GithubProvider : IGithubProvider
    {
        private readonly AppSettings _appSettings;
        private readonly IHttpProvider _httpProvider;

        public GithubProvider(IOptions<AppSettings> appSettings, IHttpProvider provider)
        {
            _httpProvider = provider;
            _appSettings = appSettings.Value;
        }

        public async Task<GithubUserInfo> GetGithubUserInfo()
        {
            var info = await _httpProvider.GetGithubInfoTask(_appSettings.jeffGithubUserInfo);
            return JsonUtil.DeserializeObject<GithubUserInfo>(info);
        }

        public async Task<List<GithubRepo>> GetAllGithubRepos()
        {
            var info = await _httpProvider.GetGithubInfoTask(_appSettings.jeffGithubRepositories);
            return JsonUtil.DeserializeObject<List<GithubRepo>>(info);
        }

        private string buildRequest(string request)
        {
            return request + "&client_id=" + _appSettings.githibAPIKey + "&client_secret=" +
                   _appSettings.githubAPISecret;
        }
    }
}