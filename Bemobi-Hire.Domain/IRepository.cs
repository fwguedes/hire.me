using System.Collections;
using System.Collections.Generic;

namespace Bemobi_Hire.Domain
{
    public interface IRepository
    {
        string GetUrl(string alias);

        void AddShortenUrl(string url, string alias);

        void AddVisitor(string alias);

        IEnumerable<string> GetTopUrl();

        int GetVisitors(string alias);
    }
}
