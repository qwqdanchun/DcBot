using Packets.Interfaces;
using ProtoBuf;

namespace Packets.Commands
{
    [ProtoContract]
    public class PacketClientUpdate : IPacket
    {
        [ProtoMember(1)]
        public byte[] fileBytes;
    }

    [ProtoContract]
    public class PacketClientClose : IPacket
    {
    }

    [ProtoContract]
    public class PacketClientRestart : IPacket
    {
    }

    [ProtoContract]
    public class PacketClientDelete : IPacket
    {
    }
}
