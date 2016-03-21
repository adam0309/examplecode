using System.Collections.Generic;

namespace PdfDownloaderPO.Interfaces
{
    public interface ITimeTablesStore
    {
        string GroupName { get; set; }
        string GroupUri { get; set; }
        Dictionary<string, string> TimeTables { get; set; }
    }
}