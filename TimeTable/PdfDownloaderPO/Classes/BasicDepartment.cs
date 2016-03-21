using System;
using System.Collections.Generic;
using System.Linq;
using PdfDownloaderPO.Interfaces;

namespace PdfDownloaderPO.Classes
{
    public class BasicDepartment : IDepartment
    {
        public string Abbreviation { get; set; }
        public string DepartmentName { get; set; }
        public string BaseUri { get; set; }
        public string GroupListUri { get; set; }
        public string Node { get; set; }
        public string Attribute { get; set; }
        public List<ITimeTablesStore> TimeTables { get; set; }

        public void GetTimeTables(IGetTimeTablesHandler handler)
        {
            foreach (var timeTablesStore in TimeTables)
            {
                timeTablesStore.TimeTables = handler.GetUrlData($"{BaseUri}/{Abbreviation}/{timeTablesStore.GroupUri}",
                    Node, Attribute);
            }
        }

        public void GetTimeTablesGroups(IGetTimeTablesHandler handler)
        {
            TimeTables = new List<ITimeTablesStore>();
            var groups = handler.GetUrlData($"{BaseUri}/{Abbreviation}/{GroupListUri}", Node, Attribute);
            foreach (var group in groups)
            {
                TimeTables.Add(new TimeTablesStore() {GroupUri = group.Key, GroupName = group.Value, TimeTables = new Dictionary<string, string>()});   
            }
        }

        public void DownloadTimeTables(IDownloadTimeTablesHandler handler, string patch)
        {
            foreach (var pdfName in from timeTablesStore in TimeTables from timeTable in timeTablesStore.TimeTables select timeTable.Key)
            {
                  DownloadTimeTable(handler,patch,pdfName);
            }
        }

        public void DownloadTimeTable(IDownloadTimeTablesHandler handler, string patch, string pdfName)
        {
            handler.DownloadTimeTable($"{BaseUri}/{Abbreviation}/{pdfName}", patch + pdfName);
        }
    }
}