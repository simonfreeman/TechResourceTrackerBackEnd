using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Xml;
using TechResourceService;
using System.Text.RegularExpressions;
using System.Net;

namespace TechResourceService.RssReader
{
    public class RssReader : IRssReader
    {

        public RssFeed Feed { get; private set; }
        public string RssUrl { get; private set; }
        private XmlReader reader;

        public void ReadFeed(string rssUrl)
        {
            RssUrl = rssUrl;
            ValidateUrl();
            SetupXmlReader();
            reader.Read();
        }

        private void SetupXmlReader()
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            XmlUrlResolver resolver = new XmlUrlResolver();
            settings.XmlResolver = resolver;
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = true;

            reader = XmlReader.Create(RssUrl,settings);
        }

        public RssFeed RssFeed { get; private set; }
        //i took this pattern from the web, and addded the \= in the end because ?parameter=value was invalidating urls. Think it works
        Regex urlRegEx = new Regex(@"^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\=\-\.\?\,\'\/\\\+&%\$#_]*)?$");

        private void ValidateUrl()
        {
            if (!urlRegEx.Match(RssUrl).Success)
            {
                throw new FormatException("Invalid Url Supplied");
            }
        }



    }
}
