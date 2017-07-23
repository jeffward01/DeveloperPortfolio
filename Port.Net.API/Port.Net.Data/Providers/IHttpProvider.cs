using System.Threading.Tasks;

namespace Port.Net.Data.Providers
{
    public interface IHttpProvider
    {
        Task<string> GetGithubInfoTask(string requestUrl);
    }
}