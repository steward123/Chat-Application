using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer.Net.IO
{
    class PacketReader : BinaryReader
    {
        private NetworkStream _ns;

        public PacketReader(NetworkStream ns) : base(ns)
        {
            _ns = ns;
        }

        public string ReadMessage()
        {
            byte[] msgbuffer;

            var length = ReadInt32();

            msgbuffer = new byte[length];

            _ns.Read(msgbuffer, 0, length);

            var msg = Encoding.ASCII.GetString(msgbuffer);

            return msg;
        }
    }
}
