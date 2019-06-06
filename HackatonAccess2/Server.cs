using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HackatonAccess2
{
    class Server
    {
        private TcpListener listener;
        private TcpClient client;
        private IPEndPoint ep;

        private BinaryReader reader;
        private BinaryWriter writer;

        public Server(int port)
        {
            ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);

            listener = new TcpListener(ep);
            listener.Start();

            client = null;
        }

        //Blocker till the simulator connected
        public void Start()
        {
            new Thread(() =>
            {
              //  Console.WriteLine("Waiting for connections...");
              client = listener.AcceptTcpClient();
              //   Console.WriteLine("Got new connection");
              reader = new BinaryReader(client.GetStream());
                writer = new BinaryWriter(client.GetStream());
            }).Start();
        }

        public void Write(byte[] str)
        {
            if(client != null)
            {
                writer.Write(str);
            }
        }

        public string[] Read()
        {
            String buffer = "";
            char c;
            try
            {
                c = reader.ReadChar();
            }
            catch
            {
                Console.WriteLine("Reading from client failed");
                Disconnect();
                return null;

            }

            while (c != '\n')
            {
                buffer += c;
                try
                {
                    c = reader.ReadChar();
                }
                catch
                {
                    Console.WriteLine("Reading from client failed");
                    Disconnect();
                    return null;
                }

            }

            string[] retStr = buffer.Split(',');
            return retStr;

        }
        //To close the Accept Blocker
        public void Disconnect()
        {
            listener.Stop();

        }
        ~Server()
        {
            listener.Stop();
        }
    }
}
