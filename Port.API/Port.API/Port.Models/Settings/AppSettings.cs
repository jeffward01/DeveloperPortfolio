namespace Port.Models.Settings
{
    public class AppSettings
    {
        public string MainUrl { get; set; }
        public string githibAPIKey { get; set; }
        public string githubAPISecret { get; set; }
        public string jeffGithubRepositories { get; set; }
        public string jeffGithubUserInfo { get; set; }

        public string PortfolioContext { get; set; }
    }
}