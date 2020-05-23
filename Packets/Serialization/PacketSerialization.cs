using Packets.Interfaces;
using ProtoBuf;
using System.IO;

namespace Packets.Serialization
{
    public class PacketSerialization
    {
        public byte[] Serialize(IPacket packet)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Serializer.Serialize(ms, packet);
                return ms.ToArray();
            }
        }

        public IPacket Desirialize(MemoryStream ms)
        {
            ms.Position = 0;
            return Serializer.Deserialize<IPacket>(ms);
        }
    }
}
