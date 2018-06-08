using System;
using NUnit.Framework;
using TechResourceService;
using TechResourceService.RssReader;

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
            reader = new RssReader();
            reader.ReadFeed(rssUrl);
        }
        
        [Test]
        public void Initial_Rss_Url_Is_Stored()
        {
            Assert.AreEqual(rssUrl, reader.RssUrl);
        }

      

       
        //[Test]
        //public void Rss_Parsed_Correctly()
        //{
        //    reader.ReadFeed(rssUrl);
        //}
    }
}
