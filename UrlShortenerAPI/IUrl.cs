using DataObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortenerAPI
{
    public interface IUrl
    {
        void GenerateShortUrl(Url url);
        void GenerateLongUrl(int id);
    }
}
