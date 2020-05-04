using System;


namespace DataObject.Models
{
    [Serializable]
    public class Url
    {
        public int Id { get; private set; }
        public string LongUrl { get; set; }

        public Url(string longUrl)
        {
            Id = GenerateRandomId();
            LongUrl = longUrl;
        }

        public int GenerateRandomId()
        {
            Random rand = new Random();
            int randomId = rand.Next(100000, 150000);

            return randomId;
        }

       public void SetId(int randomId)
        {
            Id = randomId;
        }
    }


}
