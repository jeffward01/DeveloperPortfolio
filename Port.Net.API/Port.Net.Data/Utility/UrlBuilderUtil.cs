using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Port.Net.Data.Utility
{
   public static class UrlBuilderUtil
    {
        private static readonly string _githubReposUrl = System.Configuration.ConfigurationManager.AppSettings["jeffGithubRepositories"];
        private static readonly string _githubUserInfoUrl = System.Configuration.ConfigurationManager.AppSettings["jeffGithubUserInfo"];
        private static readonly string _githubSecret = System.Configuration.ConfigurationManager.AppSettings["githubAPISecret"];
        private static readonly string _githubKey = System.Configuration.ConfigurationManager.AppSettings["githubAPIKey"];

        public static string GetGithubReposApiString()
        {
            return _githubReposUrl + "?per_page=1000&client_id=" + _githubKey + "&client_secret=" + _githubSecret;
        }

        public static string GetGithubUserInfoApiString()
        {
            return _githubUserInfoUrl + "?client_id=" + _githubKey + "&client_secret=" + _githubSecret;
        }
    }
}
