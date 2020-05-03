using AccessData.Services;
using DataAccess.Exceptions;
using DataObject.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessTests.Services
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void WhenSettingURL_PassingValidURL_ShouldReturnShortURL()
        {
            Url LongUrl = new Url("http://google.com");

            var id = LongUrl.Id;
            var methodCall = UrlServices.GenerateShortUrl(LongUrl);
            var expected = $"https://localhost:{44377}/Shortener/{id}";

            Assert.AreEqual(expected, methodCall);
        }

        [TestMethod]
        public void WhenSettingURL_PassingEmptyURL_ShouldReturnException()
        {
            Url longUrl = new Url("");

            Assert.ThrowsException<DataAccessException>(() => UrlServices.GenerateShortUrl(longUrl));
        }

        [TestMethod]
        public void WhenSettingURL_PassingEmptyURL2_ShouldReturnException()
        {
            Url longUrl = new Url(" ");

            Assert.ThrowsException<DataAccessException>(() => UrlServices.GenerateShortUrl(longUrl));
        }

        [TestMethod]
        public void WhenSettingURL_PassingInvalidURL_ShouldReturnException()
        {
            Url longUrl = new Url("teeeeeest");

            Assert.ThrowsException<DataAccessException>(() => UrlServices.GenerateShortUrl(longUrl));
        }

        [TestMethod]
        public void WhenSettingURL_PassingValidURLWithIDAlreadyExists_ShouldReturnShortURL()
        {
            Url firstLongUrl = new Url("http://google.com");
            Url secondLongUrl = new Url("http://udemy.com");

            secondLongUrl.SetId(firstLongUrl.Id);
            UrlServices.GenerateShortUrl(secondLongUrl);

            var id = secondLongUrl.Id;
            var methodCall = UrlServices.GenerateShortUrl(secondLongUrl);
            var expected = $"https://localhost:{44377}/Shortener/{secondLongUrl.Id}";

            Assert.AreEqual(expected, methodCall);
        }

        [TestMethod]
        public void WhenSettingShortURL_ShouldReturnsLongURL()
        {
            Url url = new Url("http://google.com");
            UrlServices.GenerateShortUrl(url);
            url.SetId(4512);

            var expected = url.LongUrl;
            var methodCall = UrlServices.GenerateLongUrl(4512);

            Assert.AreEqual(expected, methodCall);
        }

        [TestMethod]
        public void WhenSettingShortURL_PassingShortURLDoesntExist_ShouldReturnsLongURL()
        {
            Assert.ThrowsException<DataAccessException>(() => UrlServices.GenerateLongUrl(135));
        }
    }
}
