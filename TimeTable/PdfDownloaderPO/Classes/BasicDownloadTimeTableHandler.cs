using System;
using System.IO;
using System.Net;
using PdfDownloaderPO.Interfaces;

namespace PdfDownloaderPO.Classes
{
    public class BasicDownloadTimeTableHandler :IDownloadTimeTablesHandler
    {
        public void DownloadTimeTable(string downloadUri, string savePatch)
        {
            DownloadFile(downloadUri, savePatch);
        }

        protected void DownloadFile(string downloadUri, string savePatch)
        {
            if (File.Exists(savePatch))
            {
                if (File.GetLastWriteTime(savePatch).Date == DateTime.Today|| File.GetLastWriteTime(savePatch).Date == DateTime.Today.AddDays(-1.0))
                    return;
                File.Delete(savePatch);
            }
            var client = new WebClient();
            try
            {
                client.DownloadFile(downloadUri, savePatch);
            }
            catch(Exception)
            {
                if(File.Exists(savePatch))
                    File.Delete(savePatch);
                throw new Exception("Download file error", new Exception(downloadUri));
            }

        }
    }
}