using Packets.Interfaces;
using ProtoBuf;

namespace Packets.Commands
{
    [ProtoContract]
    public class PacketComputerRestart : IPacket
    {
    }

    [ProtoContract]
    public class PacketComputerShutdown : IPacket
    {
    }

    [ProtoContract]
    public class PacketComputerLogoff : IPacket
    {
    }
}