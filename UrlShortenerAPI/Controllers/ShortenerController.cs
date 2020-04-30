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
        private static readonly List<Url> urlsList = new List<Url>();

        [HttpPost]
        public ActionResult Post([FromBody] Url url)
        {
            urlsList.Add(url);

            return Ok($"{urlsList.Count}");

        }

        [HttpGet("{url}", Name ="Get")]
        public ActionResult<int> Get(String url)
        {
            //int con = urls.Count;
            //List<Url> results = urls.FindAll(x => x.UrlShort == url);


            return urlsList.Count;
        }
    }
}