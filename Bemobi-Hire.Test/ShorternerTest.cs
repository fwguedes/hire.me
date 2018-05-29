using Bemobi_Hire.Data;
using Bemobi_Hire.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel;

namespace Bemobi_Hire.Test
{
    [TestClass]
    public class ShorternerTest
    {
        [TestMethod]
        [DisplayName("Url is shortend with a alias and retrieved with the same alias")]
        public void ShortenUrl()
        {
            var shortener = new Shorterner(new RepositoryInMemory());
            var url = "http://www.someurl.com";
            var alias = "someAlias";
            var sucess = shortener.ShortenUrl(url,alias);

            Assert.IsTrue(sucess);

            var urlRetrieved = shortener.RetrieveUrl(alias);

            Assert.AreEqual(url, urlRetrieved);            
        }

        [TestMethod]
        [DisplayName("Same alias used twice")]
        public void ShortenUrlDuplicatedAlias()
        {
            var shortener = new Shorterner(new RepositoryInMemory());
            var url = "http://www.someurl.com";
            var alias = "someAlias";
            var sucess = shortener.ShortenUrl(url, alias);

            Assert.IsTrue(sucess);

            sucess = shortener.ShortenUrl(url, alias);

            Assert.IsFalse(sucess);
        }


        [TestMethod]
        [DisplayName("Get invalid alias")]
        public void GetInvalidAlias()
        {
            var shortener = new Shorterner(new RepositoryInMemory());
            var alias = "someAlias";

            var urlRetrieved = shortener.RetrieveUrl(alias);

            Assert.IsNull(urlRetrieved);
        }

    }
}
