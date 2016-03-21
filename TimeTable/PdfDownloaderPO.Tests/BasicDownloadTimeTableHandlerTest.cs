using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PdfDownloaderPO.Classes;

namespace PdfDownloaderPO.Tests
{
    [TestClass]
    public class BasicDownloadTimeTableHandlerTest
    {
        [TestMethod]
        public void DownloadTimeTableTest()
        {
            var handler = new BasicDownloadTimeTableHandler();
            handler.DownloadTimeTable("http://www.planyzajec.po.opole.pl/weaii/g743.pdf",
                Environment.CurrentDirectory + @"g743.pdf");
            Assert.IsTrue(File.Exists(Environment.CurrentDirectory + @"g743.pdf"));
            File.Delete(Environment.CurrentDirectory + @"g743.pdf");

        }
    }
}
