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

            TTransport transport1 = new TSocket("localhost", 9090);
            TProtocol protocol1 = new TBinaryProtocol(transport1);
            ClienteServidor.ClienteServidor.Client client1 = new ClienteServidor.ClienteServidor.Client(protocol1);
            transport1.Open();
            int caseswitch=0;

            /*          switch (caseswitch)
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
                      }*/

            if (client.insereVertice(4, 4, "ola", 70) == true)
                Console.WriteLine("vertice 4 inserido com sucesso :D");
          //  client.modificaVertice(new ClienteServidor.vertice() {Nome= 40,Cor = 4, Descricao= "ola", Peso= 70 });

            if (client1.insereVertice(3, 6, "oi", 70) == true)
                Console.WriteLine("vertice 3 inserido com sucesso");

            Console.ReadKey();

            if (client1.insereVertice(3, 6, "oi", 70) == true)
                Console.WriteLine("vertice 3 inserido com sucesso");

            Console.ReadKey();

            if (client.removeVertice(3)==true)
                Console.WriteLine("vertice" + 3 + "removido");

            Console.ReadKey();

            if (client1.insereVertice(3, 6, "oi", 70) == true)
                Console.WriteLine("vertice 3 inserido com sucesso");

            Console.ReadKey();
        }
    }
}
