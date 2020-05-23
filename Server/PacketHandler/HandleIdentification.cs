using Packets.Commands;
using Server.Networking;
using Server.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.PacketHandler
{
   public class HandleIdentification
    {
        public void AddClientToList(Client client, PacketIdentification packetIdentification)
        {
            client.ClientListViewItem = new ListViewItem
            {
                Tag = client,
                Text = client.ClientSocket.RemoteEndPoint.ToString().Split(':')[0],
            };
            client.ClientListViewItem.SubItems.AddRange(new string[] { packetIdentification.Username, packetIdentification.OperatingSystem, packetIdentification.Version });
            lock (Config.LockListViewClients)
            {
                Program.form1.clientsListView.Invoke((MethodInvoker)(() =>
                {
                    Program.form1.clientsListView.Items.Add(client.ClientListViewItem);
                    Program.form1.clientsListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                }));
            }
            lock (Config.LockOnlineClients)
            {
                Config.OnlineClients.Add(client);
            }
        }
    }
}
