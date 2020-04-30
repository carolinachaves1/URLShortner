using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortenerAPI.Services
{
    public static class StoreData
    {
        public static void StoreDataAction(List<Url> list, Url url)
        {
            list.Add(url);
        }

        public static int StoreDataFind(List<Url> list, string urlShort)
        {
           int con = list.Count;

            return con;
        }
        
    }
}
