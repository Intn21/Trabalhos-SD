using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClienteServidor;
using Thrift;
using Thrift.Protocol;
using Thrift.Server;
using Thrift.Transport;

namespace servidor3
{
    class Handler : ClienteServidor.ClienteServidor.Iface
    {
        private grafo g = new grafo();
        
        private bool disponibilidade = true;

        public List<aresta> getArestas(vertice V)
        {
            throw new NotImplementedException();
        }

        public List<vertice> getVertices(aresta E)
        {
            throw new NotImplementedException();
        }

        public List<vertice> getVizinhos(vertice v)
        {
            throw new NotImplementedException();
        }

        public bool insereAresta(aresta a)
        {

            throw new NotImplementedException();
        }

        public bool insereVertice(vertice v)
        {
            return false;
        }

        public aresta lerAresta(int v1, int v2)
        {
            throw new NotImplementedException();
        }

        public vertice lerVertice(int nome)
        {
            throw new NotImplementedException();
        }

        public bool modificaAresta(aresta a)
        {
            throw new NotImplementedException();
        }

        public bool modificaVertice(vertice v)
        {
            throw new NotImplementedException();
        }

        public bool removeAresta(aresta a)
        {
            throw new NotImplementedException();
        }

        public bool removeVertice(int nomeVertice)
        {
            throw new NotImplementedException();
        }

        public bool insereVertice(int nome, int cor, string descricao, double peso)
        {

            Console.WriteLine("Inserindo vertice..." + nome);
            if(this.disponibilidade==true)
            {
                this.disponibilidade = false;

                if (this.g.ListaVertices.Any(obj => obj.Nome == nome))
                {
                    Console.WriteLine("Vertice ja inserido");
                    this.disponibilidade = true;
                    return false;
                }
                else { this.g.ListaVertices.Add(new vertice() { Nome = nome, Cor = cor, Descricao = descricao, Peso = peso }); this.disponibilidade = true; return false; }

            }
            else
            {
                Console.WriteLine("Sistema em uso, tente novamente mais tarde....");
                return false;
            }
        }

        public bool insereAresta(int v1, int v2, double peso, bool direcionado, string descricao)
        {
            throw new NotImplementedException();
        }
    }
}
