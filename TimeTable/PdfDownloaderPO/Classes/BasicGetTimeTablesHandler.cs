using System;
using System.Collections.Generic;
using System.Net;
using PdfDownloaderPO.Interfaces;

namespace PdfDownloaderPO.Classes
{
    public class BasicGetTimeTablesHandler : IGetTimeTablesHandler
    {
        public IHtmlParser Parser;
        public BasicGetTimeTablesHandler()
        {
            Parser = new HtmlParser();   
        }
        public Dictionary<string, string> GetUrlData(string url, string node, string attribute)
        {
            var html = DownloadHtml(url);
            return GetDictionaryFromString(html, node, attribute);
        }

        protected string DownloadHtml(string groupListUri)
        {
            var client = new WebClient();   
            return client.DownloadString(new Uri(groupListUri));
        }

        protected Dictionary<string, string> GetDictionaryFromString(string html, string node, string attribute)
        {
            return Parser.GetMarkupDictionary(html, node, attribute);
        }
    }
}