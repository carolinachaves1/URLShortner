using DataObject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    interface IServices
    {
        String GenerateShortUrl(Url url);
        String GenerateLongUrl(Url url);
    }
}
