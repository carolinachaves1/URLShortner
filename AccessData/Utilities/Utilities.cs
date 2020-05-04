using DataAccess.Exceptions;
using DataObject.Models;
using System.Collections.Generic;

namespace DataAccess.Utilities
{
    public static class Utilities
    {
        public static bool CheckIfContainsOnList(List<Url> list, int id)
        {
            if (list.Find(x => x.Id == id) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public static Url CheckIfValidURL(Url url)
        {

            if (url.LongUrl.StartsWith("http://") || url.LongUrl.StartsWith("https://") || url.LongUrl.Contains("."))
            {
                    return url;
            }
            else
            {
                throw new DataAccessException("Invalid URL");
            } 
        }
    }
}
