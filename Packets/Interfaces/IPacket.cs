using Packets.Commands;
using ProtoBuf;

namespace Packets.Interfaces
{
    [ProtoContract]
    [ProtoInclude(1, typeof(PacketIdentification))]
    [ProtoInclude(2, typeof(PacketDownloadExecute))]
    [ProtoInclude(3, typeof(PacketClientClose))]
    [ProtoInclude(4, typeof(PacketClientDelete))]
    [ProtoInclude(5, typeof(PacketClientRestart))]
    [ProtoInclude(6, typeof(PacketClientUpdate))]
    [ProtoInclude(7, typeof(PacketComputerLogoff))]
    [ProtoInclude(8, typeof(PacketComputerRestart))]
    [ProtoInclude(9, typeof(PacketComputerShutdown))]

    public class IPacket { }
}
