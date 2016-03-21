using System.Collections.Generic;

namespace PdfDownloaderPO.Interfaces
{
    public interface IGetTimeTablesHandler
    {
        Dictionary<string, string> GetUrlData(string url, string node, string attribute);
    }
}