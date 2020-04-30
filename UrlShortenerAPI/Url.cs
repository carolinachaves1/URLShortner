using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortenerAPI
{
    [Serializable]
    public class Url
    {
        public string UrlLong { get; set; }
        public string UrlShort { get; set; }

        public Url(string urlLong)
        {
            UrlLong = urlLong;
            UrlShort = "https://localhost:44377/Shortener/1";
        }
    }
}
