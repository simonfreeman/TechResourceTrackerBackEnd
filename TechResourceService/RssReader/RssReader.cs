using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Xml;
using TechResourceService;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;

namespace TechResourceService.RssReader
{
    //maybe TODO, hand this configs or something instead of hardcoding this to podcasts.
    public class RssReader : IRssReader
    {

        public RssFeed Feed { get; private set; } = new RssFeed();
        public string RssUrl { get; private set; }
        private XmlReaderSettings settings;
        public void ReadFeed(string rssUrl)
        {
            RssUrl = rssUrl;
            ValidateUrl();
            SetupXmlReaderSettings();
            using (XmlReader reader = XmlReader.Create(RssUrl, settings))
            {
                reader.MoveToContent();

                //can only read forwards, so switch case hell it is
                while (reader.Read())
                {
                    switch (reader.Name)
                    {
                        case "title":
                            Feed.Title = (String.IsNullOrWhiteSpace(Feed.Title)) ? reader.ReadElementContentAsString() : Feed.Title;
                            break;
                        case "description":
                            Feed.Description = (string.IsNullOrWhiteSpace(Feed.Description)) ? reader.ReadElementContentAsString() : Feed.Description;
                            break;
                        case "itunes:summary":
                            Feed.Description = (String.IsNullOrWhiteSpace(Feed.Description)) ? reader.ReadElementContentAsString() : Feed.Description;
                            break;
                    }
                }
            }
        }

        private void SetupXmlReaderSettings()
        {
            settings = new XmlReaderSettings();
            XmlUrlResolver resolver = new XmlUrlResolver();
            settings.XmlResolver = resolver;
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = true;
        }

        
        private void ValidateUrl()
        {
            Regex urlRegEx = new Regex(@"^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\=\-\.\?\,\'\/\\\+&%\$#_]*)?$");
            //honestly, it only allows local files for testing, but this is the least horrible way and theoretically maybe you want to import 
            //all rss feeds locally before running this because of baseless justification reasons
            if (!urlRegEx.Match(RssUrl).Success && !File.Exists(RssUrl))
            {
                throw new FormatException("Invalid Url Supplied");
            }
        }



    }
}
