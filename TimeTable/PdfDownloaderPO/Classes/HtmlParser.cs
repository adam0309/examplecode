using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using PdfDownloaderPO.Interfaces;

namespace PdfDownloaderPO.Classes
{
    public class HtmlParser : IHtmlParser
    {
        public Dictionary<string,string> GetMarkupDictionary(string html, string node, string attribute)
        {
            var nodes = GetHtmlNodes(html, node);
            return BuildDictionary(attribute, nodes);
        }

        protected Dictionary<string, string> BuildDictionary(string attribute, IEnumerable<HtmlNode> nodes)
        {
            var result = new Dictionary<string, string>();
            foreach (var htmlNode in nodes.Where(CheckIfAttributeExists(attribute)).Where(htmlNode => !result.ContainsKey(htmlNode.Attributes[attribute].Value)))
            {
                result.Add(htmlNode.Attributes[attribute].Value, (htmlNode.NextSibling == null || (htmlNode.NextSibling.InnerText == string.Empty)) ? htmlNode.InnerText : htmlNode.NextSibling.InnerText);
            }
            return result;
        }

        protected Func<HtmlNode, bool> CheckIfAttributeExists(string attribute)
        {
            return htmlNode => htmlNode.Attributes[attribute] != null;
        }

        protected IEnumerable<HtmlNode> GetHtmlNodes(string html, string node)
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            return htmlDocument.DocumentNode.SelectNodes($"//{node}");
        }
    }
}