using System;
using System.IO;
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
            //reliable path generation?
            string initialPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            int indexToReplaceFrom = initialPath.IndexOf("\\bin\\");
            initialPath = initialPath.Remove(indexToReplaceFrom);
            rssUrl = initialPath + "\\jsparty.rss";

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
