using System.Xml.Linq;

namespace TechResourceService
{
    public interface IRssReader
    {
        RssFeed Feed { get; }
        string RssUrl { get; }

        void ReadFeed(string rssUrl);
    }
}