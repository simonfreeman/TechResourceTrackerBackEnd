using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace TechResourceRssReader
{
    class RssReader
    {
        public string RssUrl { get; set; }



        public string ReadFeed()
        {
            var rssFeed = XDocument.Load(RssUrl);
            return "fals";
        }
    }
}
