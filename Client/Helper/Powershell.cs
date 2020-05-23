using System.Diagnostics;

namespace Client.Helper
{
    public class Powershell
    {
        public void Run(string args)
        {
            ProcessStartInfo processStart = new ProcessStartInfo()
            {
                FileName = "powershell.exe",
                Arguments = args,
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                UseShellExecute = false
            };
            Process.Start(processStart);
        }
    }
}