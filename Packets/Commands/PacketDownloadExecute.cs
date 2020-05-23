using Packets.Interfaces;
using ProtoBuf;

namespace Packets.Commands
{
    [ProtoContract]
    public class PacketDownloadExecute : IPacket
    {
        [ProtoMember(1)]
        public byte[] fileBytes;
        [ProtoMember(2)]
        public string fileExtension;
    }
}
