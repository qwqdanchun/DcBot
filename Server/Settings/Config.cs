using Server.Networking;
using System.Collections.Generic;

namespace Server.Settings
{
    public static class Config
    {
        public static int Port = 8858;
        public static List<Client> OnlineClients;
        public static object LockOnlineClients;
        public static object LockListViewClients;

        public static void Initialize()
        {
            OnlineClients = new List<Client>();
            LockOnlineClients = new object();
            LockListViewClients = new object();
        }
    }
}
