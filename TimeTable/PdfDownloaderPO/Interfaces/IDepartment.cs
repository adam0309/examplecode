using System.Collections.Generic;

namespace PdfDownloaderPO.Interfaces
{
    public interface IDepartment
    {
        string Abbreviation { get; set; }
        string DepartmentName { get; set; }
        string BaseUri { get; set; }
        string GroupListUri { get; set; }
        string Node { get; set; }
        string Attribute { get; set; }
        List<ITimeTablesStore> TimeTables { get;set; } //<pdfName, groupName>
        void GetTimeTables(IGetTimeTablesHandler handler);
        void GetTimeTablesGroups(IGetTimeTablesHandler handler);
        void DownloadTimeTables(IDownloadTimeTablesHandler handler, string patch);
        void DownloadTimeTable(IDownloadTimeTablesHandler handler, string patch, string pdfName);
    }
}