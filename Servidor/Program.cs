using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrift.Server;
using Thrift.Transport;

namespace servidor3
{
    class Program
    {
        static void Main(string[] args)
        {
            var processor = new ClienteServidor.ClienteServidor.Processor(new Handler());
            var serverTransport = new TServerSocket(9090);
            var server = new TThreadPoolServer(processor, serverTransport);

            //TServer server = new TSimpleServer(processor, serverTransport);

            // Use this for a multithreaded server

            Console.WriteLine("Starting the server...");
            server.Serve();
        }
    }
}
