using System.Threading.Tasks;

namespace Port.Data.Providers
{
    public interface IHttpProvider
    {
        Task<string> GetGithubInfoTask(string requestUrl);
    }
}