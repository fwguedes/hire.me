namespace Bemobi_Hire.Domain
{
    public class Shorterner
    {

        private readonly IRepository repository;

        public Shorterner(IRepository repository)
        {
            this.repository = repository;
        }

        public bool ShortenUrl(string url,string alias)
        {
            if (repository.GetUrl(alias) != null)
                return false;

            repository.AddShortenUrl(url, alias);

            return true;
        }

        public string RetrieveUrl(string alias)
        {
            repository.AddVisitor(alias);
            return repository.GetUrl(alias);
        }
    }
}
