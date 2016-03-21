using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PdfDownloaderPO.Classes;

namespace PdfDownloaderPO.Tests
{
    
    [TestClass]
    public class HtmlParserTests
    {
        [TestMethod]
        public void GetMarkupDictionaryTest()
        {
          
            var parser = new HtmlParser();
            var client = new WebClient();
            var result = parser.GetMarkupDictionary(client.DownloadString(new Uri("http://www.planywb.po.opole.pl/")), "a", "href");


        }
    }
}
