using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using TechResourceService;

namespace TechResourceRssReader
{
    public class RssReader
    {
        public string FeedError;

        private string _RssUrl;
        public string RssUrl {
            get
            {
                return _RssUrl;
            }
            set
            {
            }
        }

        public string ReadFeed()
        {
            var rssFeed = XDocument.Load(RssUrl);
            return "fals";
        }

        private RssFeed _RssFeed;
        public RssFeed RssFeed { get; }

        private Boolean ValidUrl
        {
            get
            {
                return true;
                //todo
            }
        }
        

    }
}
