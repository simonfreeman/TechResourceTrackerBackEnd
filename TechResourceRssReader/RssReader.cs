using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using TechResourceService;

namespace TechResourceRssReader
{
    class RssReader: IRssReader
    {
        public string RssUrl { get; set; }

        public string ReadFeed()
        {
            var rssFeed = XDocument.Load(RssUrl);
            return "fals";
        }

        public RssFeed ParseFeed()
        {
            return new RssFeed() {LastUpdate = DateTime.Now };
        }
    }
}
