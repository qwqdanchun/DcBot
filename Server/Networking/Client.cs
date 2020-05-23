using Packets.Interfaces;
using Packets.Serialization;
using Server.Settings;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;
namespace Server.Networking
{
    public class Client
    {
        public Socket ClientSocket;
        private MemoryStream ClientMemory;
        private bool IsPackeReceived;
        private long PacketSize;
        private byte[] ClientBuffer;
        public ListViewItem ClientListViewItem;

        public Client(Socket socket)
        {
            ClientSocket = socket;
            ClientMemory = new MemoryStream();
            IsPackeReceived = false;
            PacketSize = 0;
            ClientBuffer = new byte[4];

            ClientSocket.BeginReceive(ClientBuffer, 0, ClientBuffer.Length, 0, ReceiveCall, null);
        }

        private async void ReceiveCall(IAsyncResult ar)
        {
            try
            {
                if (!ClientSocket.Connected)
                {
                    Disconnected();
                    return;
                }

                int received = ClientSocket.EndReceive(ar);
                await ClientMemory.WriteAsync(ClientBuffer, 0, received);
                if (!IsPackeReceived)
                {
                    if (ClientMemory.Length == 4)
                    {
                        PacketSize = BitConverter.ToInt32(ClientMemory.ToArray(), 0);
                        ClientMemory.Dispose();
                        ClientMemory = new MemoryStream();
                        if (PacketSize > 0)
                        {
                            ClientBuffer = new byte[PacketSize];
                            IsPackeReceived = true;
                        }
                    }
                }
                else
                {
                    if (ClientMemory.Length == PacketSize)
                    {
                        new PacketHandler.PacketHandler(this, new PacketSerialization().Desirialize(ClientMemory));
                        ClientMemory.Dispose();
                        ClientMemory = new MemoryStream();
                        IsPackeReceived = false;
                        PacketSize = 0;
                        ClientBuffer = new byte[4];
                    }
                }
                ClientSocket.BeginReceive(ClientBuffer, 0, ClientBuffer.Length, 0, ReceiveCall, null);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Disconnected();
                return;
            }
        }

        public async void Send(object packet)
        {
            try
            {
                if (!ClientSocket.Connected)
                {
                    Disconnected();
                    return;
                }
                else
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        byte[] buffer = new PacketSerialization().Serialize((IPacket)packet);
                        byte[] bufferSize = BitConverter.GetBytes(buffer.Length);
                        await memoryStream.WriteAsync(bufferSize, 0, bufferSize.Length);
                        await memoryStream.WriteAsync(buffer, 0, buffer.Length);
                        ClientSocket.Poll(0, SelectMode.SelectWrite);
                        ClientSocket.Send(memoryStream.ToArray(), 0, memoryStream.ToArray().Length, SocketFlags.None);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Disconnected();
                return;
            }
        }

        public void Disconnected()
        {
            try
            {
                if (ClientListViewItem != null)
                {
                    lock (Config.LockOnlineClients)
                    {
                        Config.OnlineClients.Remove(this);
                    }

                    lock (Config.LockListViewClients)
                    {
                        Program.form1.clientsListView.Invoke((MethodInvoker)(() =>
                        {
                            ClientListViewItem.Remove();
                        }));
                    }
                }

                ClientSocket?.Dispose();
                ClientMemory?.Dispose();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
