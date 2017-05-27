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
            var server = new TThreadPoolServer(processor, serverTransport);// Use this for a multithreaded server!!

            //TServer server = new TSimpleServer(processor, serverTransport); // Use this for a simplethreaded server!!


            Console.WriteLine("Inicializando o servidor...");
            Console.WriteLine("Servidor Inicializado :D");

            server.Serve();
            
        }
    }
}
