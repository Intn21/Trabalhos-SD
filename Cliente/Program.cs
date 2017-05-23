using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrift;
using Thrift.Protocol;
using Thrift.Server;
using Thrift.Transport;

namespace Cliente3
{
    class Program
    {
        static void Main(string[] args)
        {
            TTransport transport = new TSocket("localhost", 9090);
            TProtocol protocol = new TBinaryProtocol(transport);
            ClienteServidor.ClienteServidor.Client client = new ClienteServidor.ClienteServidor.Client(protocol);
            transport.Open();
            int caseswitch=0;
            
            switch (caseswitch)
            {
                case 0:
                    {
                        Console.WriteLine("1-Insere Vertice");
                        Console.WriteLine("2-Insere Aresta");
                        Console.WriteLine("3-Remove Vertice");
                        Console.WriteLine("4-Remove Aresta");
                        caseswitch = int.Parse(Console.ReadLine());
                        break;
                    }

                case 1:
                    {
                        int nome;
                        int cor;
                        string descricao;
                        double peso;
                        Console.WriteLine("Digite o Nome do Vertice:");
                        nome = int.Parse(Console.ReadLine());
                        break;
                    }
            }
            client.insereVertice(3, 4, "suaMae",70 );
        }
    }
}
