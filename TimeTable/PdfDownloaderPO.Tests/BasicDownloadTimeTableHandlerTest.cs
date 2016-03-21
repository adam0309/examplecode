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
            handler.DownloadTimeTable("http://www.planyzajec.po.opole.pl/weaii/g743.html",
                Environment.CurrentDirectory + @"\Test\g743.html");
            Assert.IsTrue(File.Exists(Environment.CurrentDirectory + @"\Test\g743.html"));
            File.Delete(Environment.CurrentDirectory + @"\Test\g743.html");

        }
    }
}
