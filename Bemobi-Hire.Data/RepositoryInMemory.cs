using Bemobi_Hire.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bemobi_Hire.Data
{
    public class RepositoryInMemory : IRepository
    {

        private List<UrlShortened> urls = new List<UrlShortened>();

        public void AddShortenUrl(string url, string alias)
        {
            urls.Add(new UrlShortened()
            {
                Url = url,
                Alias = alias,
                Visitors = 0
            });
        }

        public string GetUrl(string alias)
        {
            var urlFound = urls.Find(r => r.Alias == alias);

            if (urlFound != null)
                return urlFound.Url;
            else
                return null;
        }

        public void AddVisitor(string alias)
        {
            var urlFound = urls.Find(r => r.Alias == alias);

            if (urlFound != null)
                urlFound.Visitors++;
                            
        }

        public IEnumerable<string> GetTopUrl()
        {
            return urls.OrderBy(u => u.Visitors).Take(10).Select(u => u.Url);                              
        }

        public int GetVisitors(string alias)
        {
            var urlFound = urls.Find(r => r.Alias == alias);

            if (urlFound != null)
                return urlFound.Visitors;
            else
                return 0;
        }
    }
}
