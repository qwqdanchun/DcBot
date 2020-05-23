using Packets.Interfaces;
using ProtoBuf;

namespace Packets.Commands
{
    [ProtoContract]
    public class PacketIdentification : IPacket
    {
        [ProtoMember(1)]
        public string Username { get; set; }

        [ProtoMember(2)]
        public string OperatingSystem { get; set; }

        [ProtoMember(3)]
        public string Version { get; set; }
    }
}
