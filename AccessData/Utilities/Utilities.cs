using DataObject.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
