using Packets.Interfaces;
using Server.Networking;
using Packets.Commands;

namespace Server.PacketHandler
{
    public class PacketHandler
    {
        public PacketHandler(Client client, IPacket packet)
        {
            switch (packet)
            {
                case PacketIdentification packetIdentification:
                    {
                        new HandleIdentification().AddClientToList(client, packetIdentification);
                        break;
                    }

                case PacketPing packetPing:
                    {
                        break;
                    }
            }
        }
    }
}
