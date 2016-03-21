using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PdfDownloaderPO.Classes;
using PdfDownloaderPO.Interfaces;

namespace PdfDownloaderPO.Tests
{
    [TestClass]
    public class IntegrationTests
    {
        private string _testPatch;

        [TestMethod]
        public void PdfDownloaderIntegrationTest()
        {
            var result = new List<ITimeTablesStore>();
            _testPatch = Environment.CurrentDirectory + "\\Test\\";
            if (!Directory.Exists(_testPatch))
                Directory.CreateDirectory(_testPatch);
            
            foreach (var departmentObject in Constants.Departments.Keys.Select(department => Constants.DepartmentFactory[department].Invoke()))
            {
                departmentObject.GetTimeTablesGroups(new BasicGetTimeTablesHandler());
                departmentObject.GetTimeTables(new BasicGetTimeTablesHandler());
                try
                {
                    departmentObject.DownloadTimeTables(new BasicDownloadTimeTableHandler(), _testPatch);
                }
                catch (Exception e)
                {
                    
                    Debug.Print(e.Message + ": " + e.InnerException.Message);
                }
                result.AddRange(departmentObject.TimeTables);
            }

            var sumOfEntries = result.Sum(timeTablesStore => timeTablesStore.TimeTables.Count);
            Debug.Print($"Sum of entries in TimeTablesStore: {sumOfEntries}");
            Debug.Print($"Sum of files in download folder: {Directory.GetFiles(_testPatch).Count()}");
            Debug.Print($"Size of folder: {GetDirectorySize(_testPatch)/1024/1024}MB");
            DeleteFiles();
        }

        private void DeleteFiles()
        {
            foreach (var file in Directory.GetFiles(_testPatch))
            {
                File.Delete(file);
            }
        }

        public static long GetDirectorySize(string patch)
        {
            var files = Directory.GetFiles(patch, "*.pdf");
            return files.Select(fileName => new FileInfo(fileName)).Select(info => info.Length).Sum();
        }

    }
}
