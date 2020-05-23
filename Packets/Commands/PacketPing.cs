using Packets.Interfaces;
using ProtoBuf;

namespace Packets.Commands
{
    [ProtoContract]
    public class PacketPing : IPacket
    {
    }
}
