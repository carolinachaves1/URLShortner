using System;
using System.Collections.Generic;
using System.Text;

namespace DataObject.Models
{
    [Serializable]
    public class Url
    {
        public int Id { get; private set; }
        public string UrlLong { get; set; }

        public Url(string urlLong)
        {
            Id = GenerateRandomId();
            UrlLong = urlLong;
        }

        public int GenerateRandomId()
        {
            Random rand = new Random();
            int randomId = rand.Next(1000, 1500);

            return randomId;
        }
    }


}
