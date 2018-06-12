using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechResourceService
{
    public class RssFeed
    {
        public DateTime LastUpdate;
        public List<RssFeedItem> FeedItems;
        public string Title;
        public string Description;
    }
}
