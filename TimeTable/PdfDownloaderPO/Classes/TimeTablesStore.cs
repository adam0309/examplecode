using System.Collections.Generic;
using PdfDownloaderPO.Interfaces;

namespace PdfDownloaderPO.Classes
{
    public class TimeTablesStore : ITimeTablesStore
    {
        private Dictionary<string, string> _timeTables;
        public string GroupName { get; set; }
        public string GroupUri { get; set; }

        public Dictionary<string, string> TimeTables
        {
            get { return _timeTables; }
            set
            {
                /* _timeTables = value; */
               if(_timeTables==null)_timeTables = new Dictionary<string, string>();
                foreach (var val in value)
                {
                    _timeTables.Add(key: val.Key.Contains("html")?val.Key.Replace("html", "pdf") : val.Key, value: val.Value);
                }
            }
        }
    }
}