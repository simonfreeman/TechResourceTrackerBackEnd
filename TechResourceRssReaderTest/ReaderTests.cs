using System;
using NUnit.Framework;
using TechResourceService;
using TechResourceRssReader;
namespace TechResourceRssFeaderTest
{
    [TestFixture]
    public class TechResourceRssFeaderTest
    {
        private string rssUrl;
        private RssReader reader;


        [SetUp]
        protected void Setup()
        {
            rssUrl = "http://www.pwop.com/feed.aspx?show=dotnetrocks&filetype=master";
            reader = new RssReader
            {
                RssUrl = rssUrl
            };
        }
        
        [Test]
        public void Initial_Rss_Url_Is_Stored()
        {
            Assert.AreEqual(rssUrl, reader.RssUrl);
        }

        [Test]
        public void Rss_Url_Is_Changeable()
        {
            var newUrl = "newRssUrl";
            reader.RssUrl = newUrl;
            Assert.AreEqual(reader.RssUrl, newUrl);
        }
    }
}
