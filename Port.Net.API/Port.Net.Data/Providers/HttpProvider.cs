using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Port.Net.Data.Providers
{
    public class HttpProvider : IHttpProvider
    {
        public async Task<string> GetGithubInfoTask(string requestUrl)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", "Jeff Ward | Porfolio App");
            var stream = await client.GetStringAsync(requestUrl);
            return stream;
        }
    }
}
