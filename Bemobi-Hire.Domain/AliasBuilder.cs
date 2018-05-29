using System;
using System.Linq;

namespace Bemobi_Hire.Domain
{
    public static class AliasBuilder
    {
        public static string GetAlias()
        {
            string capitalLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lowLettes = capitalLetters.ToLower();
            string allLetters = capitalLetters + lowLettes;
            string alias = string.Empty;
            var random = new Random((int)DateTime.Now.Ticks);

            var chars = Enumerable.Repeat(allLetters, 6)
                      .Select(s => s[random.Next(s.Length)])
                      .ToArray();

            alias = new string(chars);
            
            return alias;
        }
    }
}

