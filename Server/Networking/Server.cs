using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace Server.Networking
{
    public class Server
    {
        public Server(int port)
        {
            try
            {
                Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                server.Bind(new IPEndPoint(IPAddress.Any, port));
                server.Listen(20);
                server.BeginAccept(EndAcceptCall, server);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void EndAcceptCall(IAsyncResult ar)
        {
            Socket server = (Socket)ar.AsyncState;
            try
            {
                Socket newBot = server.EndAccept(ar);
                new Client(newBot);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                server.BeginAccept(new AsyncCallback(EndAcceptCall), server);
            }
        }
    }
}
