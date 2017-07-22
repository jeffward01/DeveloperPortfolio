using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Port.Data.Providers
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