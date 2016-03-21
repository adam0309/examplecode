using System.Collections.Generic;

namespace PdfDownloaderPO.Interfaces
{
    public interface IHtmlParser
    {
        Dictionary<string,string> GetMarkupDictionary(string html, string node, string attribute);
    }
}