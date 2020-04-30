using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AccessData.Services;
using DataAccess.Exceptions;
using DataObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UrlShortenerAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShortenerController : ControllerBase
    {
        [HttpPost]
        public ActionResult<String> Post([FromBody] Url url)
        {
            try
            {
                string shortUrl = UrlServices.GenerateShortUrl(url);

                return Ok(shortUrl);
            }
            catch
            {
                return BadRequest("Error generating shorter URL");
            }
        }

        [HttpGet("{id}", Name ="Get")]
        public ActionResult<String> Get(int id)
        {
            try
            {
                string longUrl = UrlServices.GenerateLongUrl(id);

                return Redirect(longUrl);
            }
            catch(DataAccessException e)
            {
                return BadRequest(e);
            }          

        }
    }
}