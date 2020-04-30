using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UrlShortenerAPI.Services;

namespace UrlShortenerAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShortenerController : ControllerBase
    {
        private static List<Url> urlsList = new List<Url>();

        [HttpPost]
        public ActionResult Post([FromBody] Url url)
        {
            urlsList.Add(url);

            return Ok($"{url.UrlShort}");

        }

        [HttpGet("{url}", Name ="Get")]
        public ActionResult<String> Get(String url)
        {
            url = "https://localhost:44377/Shortener/" + url;
            //int con = urls.Count;
            Url results = urlsList.Find(x => x.UrlShort == url);


            return Redirect(results.UrlLong);
        }
    }
}