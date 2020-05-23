using Client.Settings;
using Packets.Interfaces;
using Packets.Serialization;
using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using Client.PacketHandler;
using System.Diagnostics;

namespace Client.Networking
{
    public class Client
    {
        public Socket ClientSocket;
        private MemoryStream ClientMemory;
        private bool IsPackeReceived;
        private long PacketSize;
        private byte[] ClientBuffer;
        private object LockSend;

        /// <summary>
        /// This is the temp socket
        /// </summary>
        public void InitializeClient()
        {
            try
            {
                ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                ClientSocket.Connect(Config.Host, Config.Port);

                ClientMemory = new MemoryStream();
                IsPackeReceived = false;
                PacketSize = 0;
                ClientBuffer = new byte[4];
                LockSend = new object();

                ClientSocket.BeginReceive(ClientBuffer, 0, ClientBuffer.Length, 0, ReceiveCall, null);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public void Disconnect()
        {
            try
            {
                if (ClientSocket.Connected)
                {
                    ClientSocket.Shutdown(SocketShutdown.Both);
                    ClientSocket.Dispose();
                }
                ClientMemory?.Dispose();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void ReceiveCall(IAsyncResult ar)
        {
            try
            {
                if (!ClientSocket.Connected || !StaticClient.ClientSocket.Connected)
                {
                    Disconnect();
                    return;
                }

                int received = ClientSocket.EndReceive(ar);
                ClientMemory.Write(ClientBuffer, 0, received);
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
                        IPacket packet = new PacketSerialization().Desirialize(ClientMemory);
                        ClientMemory.Dispose();
                        ClientMemory = new MemoryStream();
                        new Thread(() => { new Handler(packet); }).Start();
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
                Disconnect();
                return;
            }
        }

        public void Send(IPacket packet)
        {
            try
            {
                lock (LockSend)
                {
                    if (!ClientSocket.Connected || !StaticClient.ClientSocket.Connected)
                    {
                        Disconnect();
                        return;
                    }
                    else
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            byte[] buffer = new PacketSerialization().Serialize(packet);
                            byte[] bufferSize = BitConverter.GetBytes(buffer.Length);
                            memoryStream.Write(bufferSize, 0, bufferSize.Length);
                            memoryStream.Write(buffer, 0, buffer.Length);
                            ClientSocket.Poll(0, SelectMode.SelectWrite);
                            ClientSocket.Send(memoryStream.ToArray(), 0, memoryStream.ToArray().Length, SocketFlags.None);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Disconnect();
                return;
            }
        }

    }
}
