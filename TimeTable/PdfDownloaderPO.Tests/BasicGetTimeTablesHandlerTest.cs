using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PdfDownloaderPO.Classes;

namespace PdfDownloaderPO.Tests
{
    [TestClass]
    public class BasicGetTimeTablesHandlerTest
    {
        [TestMethod]
        public void GetTimeTablesTest()
        {
            var handler = new BasicGetTimeTablesHandler();
            var result = handler.GetUrlData("http://www.planyzajec.po.opole.pl/weaii/gindex.html", "option", "value");
            Debug.Print($"{result.Count()}");
            result = handler.GetUrlData("http://www.planyzajec.po.opole.pl/wwfif/gindex.html", "option", "value");
            Debug.Print($"{result.Count()}");
            result = handler.GetUrlData("http://www.planyzajec.po.opole.pl/wetii/gindex.html", "option", "value");
            Debug.Print($"{result.Count()}");
            result = handler.GetUrlData("http://www.planyzajec.po.opole.pl/wm/gindex.html", "option", "value");
            Debug.Print($"{result.Count()}");
            result = handler.GetUrlData("http://www.planyzajec.po.opole.pl/wm/fullindex.html", "option", "value");
            Debug.Print($"{result.Count()}");
        }
    }
}
