using DataAccess.Exceptions;
using DataAccess.Utilities;
using DataObject.Models;
using System;
using System.Collections.Generic;

namespace AccessData.Services
{
    public static class UrlServices 
    {
        private static List<Url> urlsList = new List<Url>();
        static int port = 44377;

        public static String GenerateShortUrl(Url url)
        {
            try
            {
                Utilities.CheckIfValidURL(url);

                var checkShortUrl = Utilities.CheckIfContainsOnList(urlsList, url.Id);
                
                if (checkShortUrl == true)
                {
                    var randomId = url.GenerateRandomId();
                    url.SetId(randomId);
                }

                urlsList.Add(url);

                return $"https://localhost:{port}/Shortener/{url.Id}";
            }
            catch(DataAccessException e)
            {
                throw new DataAccessException(e.Message);
            }
        }

        public static String GenerateLongUrl(int id)
        {
            Url results = urlsList.Find(x => x.Id == id);

            if(results == null)
            {
                throw new DataAccessException("Not Found"); 
            }
            else
            {
                return results.LongUrl;
            }
        }
    }
}
