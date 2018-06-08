using System;
using NUnit.Framework;
using TechResourceService;
using TechResourceService.RssReader;

namespace TechResourceRssReaderTest
{
    class ReaderExceptionTests
    {
        private RssReader reader;

        [SetUp]
        public void Setup()
        {
            reader = new RssReader();
        }

        [Test]
        public void Invalid_Url_Caught()
        {
            TestDelegate throwException = () => reader.ReadFeed("notAUrl");
            Assert.Throws(typeof(FormatException), throwException);
        }

        [Test]
        public void Invalid_Url_Caught_2()
        {
            TestDelegate throwException = () => reader.ReadFeed("https:/notAUrl");
            Assert.Throws(typeof(FormatException), throwException);
        }

        [Test]
        public void No_Such_Web_Location()
        {
            TestDelegate throwException = () => reader.ReadFeed("https://www.prettysurethiswontbeanrssfeedbutyouneverknowsoletsmakeitreallongandthrowingibberishfsdfsdfsdf.com");
            Assert.Throws(typeof(System.Net.WebException), throwException);
        }

        [Test]
        public void Not_Valid_Xml()
        {
            TestDelegate throwException = () => reader.ReadFeed("https://www.google.com");
            Assert.Throws(typeof(System.Xml.XmlException), throwException);
        }
    }
}
