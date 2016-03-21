using System.Collections.Generic;
using System.Linq;
using PdfDownloaderPO.Interfaces;

namespace PdfDownloaderPO.Classes
{
    public class WeizDepartment : BasicDepartment, IDepartment
    {

        protected readonly Dictionary<string, string> WeizGroups = new Dictionary<string, string>()
        {
            {"s", "Pracownicy" },
            {"g", "Grupy" },
            {"r", "Pomieszczenia" }
        };
        public new void GetTimeTables(IGetTimeTablesHandler handler)
        {
            var timeTables = handler.GetUrlData($"{BaseUri}/{Abbreviation}/{GroupListUri}", Node, Attribute);
            foreach (var timeTable in timeTables)
            {
                var key = ExtractingPdfFromAttributeValue(timeTable.Key);
                foreach(var timeTableStoreEntry in TimeTables.Where(timeTableStoreEntry => key.Contains(timeTableStoreEntry.GroupUri)))
                {
                    timeTableStoreEntry.TimeTables.Add(key, timeTable.Value);
                    break;
                }
            }
        }

        public new void GetTimeTablesGroups(IGetTimeTablesHandler handler)
        {
            TimeTables = new List<ITimeTablesStore>();
            foreach (var groupName in WeizGroups)
            {
                TimeTables.Add(new TimeTablesStore() {GroupUri = groupName.Key, GroupName = groupName.Value, TimeTables = new Dictionary<string, string>()});
            }
        }

        protected string ExtractingPdfFromAttributeValue(string attributeValue)
        {
            return attributeValue.Substring(attributeValue.IndexOf('\"') + 1, attributeValue.Length - 2);
        }
    }
}