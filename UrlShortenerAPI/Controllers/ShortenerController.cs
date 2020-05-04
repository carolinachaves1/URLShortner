using System;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<String> Post([FromBody] Url url)
        {
            try
            {
                string shortUrl = UrlServices.GenerateShortUrl(url);

                return Ok(shortUrl);
            }
            catch(DataAccessException e)
            {
                return BadRequest($"Error generating shorter URL: {e.Message}");
            }
        }

        [HttpGet("{id}", Name ="Get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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