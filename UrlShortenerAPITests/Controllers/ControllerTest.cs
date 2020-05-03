using DataObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UrlShortenerAPI.Controllers;

namespace UrlShortenerAPITests
{
    [TestClass]
    public class ControllerTest
    {
        //WhenSettingPerson_PassingEmptyName_ShouldReturnException
        [TestMethod]
        public void WhenIPostLongURL_PassingURL_ShouldReturnShortUrl()
        {
            Url url = new Url("http://www.google.com");

            var controller = new ShortenerController();

            OkObjectResult result = new OkObjectResult(controller.Post(url));

            Assert.AreEqual(200, result.StatusCode);

        }

        [TestMethod]
        public void WhenIPostLongUrl_PassingInvalidURL_ShouldReturnError()
        {
            Url url = new Url("tesssst");

            var controller = new ShortenerController();

            BadRequestObjectResult result = new BadRequestObjectResult(controller.Post(url));

            Assert.AreEqual(400, result.StatusCode);
        }
    }
}
