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
        private bool disponibilidade =true;
        private System.Threading.Mutex MUTEX = new System.Threading.Mutex();


        public List<vertice> getVertices(aresta E)
        {
            List<vertice> retorno = new List<vertice>();
            foreach (vertice v in this.g.ListaVertices)
            {
                if (v.Nome == E.V1 || v.Nome == E.V2)
                {
                    retorno.Add(v);
                }
            }
            return retorno;
        }

        public aresta lerAresta(int v1, int v2)
        {
            foreach (aresta a in this.g.ListaAresta)
            {
                if ((a.V1 == v1 && a.V2 == v2) || (a.V1 == v2 && a.V2 == v1))
                {
                    return a;
                }
            }
            Console.WriteLine("ARESTA NAO ECONTRADA");
            return null;
        }

        public vertice lerVertice(int nome)
        {
            vertice ver = new vertice();
            if (this.g.ListaVertices.Any(obj => obj.Nome == nome))
            {
                foreach (vertice v in this.g.ListaVertices)
                {
                    if (v.Nome == nome)
                        ver = v;
                }
                return ver;
            }
            else
            {
                Console.WriteLine("Vertice nao existe");
                return null;
            }
        }

        public bool TravaServidor(vertice v)
        {
            if (this.disponibilidade == false)
                this.disponibilidade = true;
            else { this.disponibilidade = false; }
            return false;
        }

        public bool removeVertice(int nomeVertice)
        {
            if (this.disponibilidade == true)
            {
                vertice ver = new vertice();
                this.disponibilidade = false;
                foreach (vertice v in g.ListaVertices)
                {
                    if (v.Nome == nomeVertice)
                        ver = v;
                }
                g.ListaVertices.Remove(ver);
                this.disponibilidade = true;
                return false;

            }
            else { return false; }
        }

        public bool insereVertice(int nome, int cor, string descricao, double peso)
        {

            while (this.disponibilidade == false)
            {
                Console.WriteLine("aguardando....");
                System.Threading.Thread.Sleep(2000);
            }
            Console.WriteLine("Inserindo vertice..." + nome);
              if (this.disponibilidade == true)
              {
                  this.disponibilidade = false;
           
                  if (this.g.ListaVertices.Any(obj => obj.Nome == nome))
                  {
                      Console.WriteLine("Vertice ja inserido");
                      this.disponibilidade = true;
                      return false;                   }
                  else
                  { this.g.ListaVertices.Add(new vertice() { Nome = nome, Cor = cor, Descricao = descricao, Peso = peso }); this.disponibilidade = true; return true; }

                }
                else
                {
                    //Console.WriteLine("Sistema em uso, tente novamente mais tarde....");
                    return false;
                }
        }

        public bool insereAresta(int v1, int v2, double peso, bool direcionado, string descricao)
        {
            if (this.g.ListaAresta.Any(obj => obj.V1 == v1 && obj.V2 == v2) || this.g.ListaAresta.Any(obj => obj.V1 == v2 && obj.V2 == v1))
            {
                Console.WriteLine("Aresta ja Inserida");
                return false;
            }
            else { this.g.ListaAresta.Add(new aresta() { V1 = v1, V2 = v2, Peso = peso, Direcionado = direcionado, Descricao = descricao }); }
            Console.WriteLine("Aresta " + v1 + "/" + v2 + " inserida");
            return true;
        }


        public bool modificaVertice(int nome, int cor, string descricao, double peso)
        {
            vertice ver = new vertice();
            if (this.g.ListaVertices.Any(obj => obj.Nome == nome))
            {
                foreach (vertice v in this.g.ListaVertices)
                {
                    if (v.Nome == nome)
                        ver = v;
                }
                ver.Cor = cor;
                ver.Descricao = descricao;
                ver.Peso = peso;
                return true;
            }
            else { Console.WriteLine("O vertice " + nome + " nao Existe"); return false; }
        }


        public List<vertice> getVizinhos(int nome)
        {
            vertice ver = new vertice();
            List<vertice> retorno = new List<vertice>();
            List<int> verticesVizinhos = new List<int>();

            foreach (aresta a in this.g.ListaAresta)
            {
                if (a.V1 == nome)
                {
                    verticesVizinhos.Add(a.V2);
                }
                else if (a.V2 == nome)
                {
                    verticesVizinhos.Add(a.V1);
                }
            }

            foreach (int i in verticesVizinhos)
            {
                foreach (vertice v in this.g.ListaVertices)
                {
                    if (v.Nome == i)
                        retorno.Add(v);
                }
            }
            return retorno;
        }

        public bool removeAresta(int v1, int v2)
        {
            aresta aresta = new aresta();
            if (this.g.ListaAresta.Any(obj => obj.V1 == v1 && obj.V2 == v2) || this.g.ListaAresta.Any(obj => obj.V1 == v2 && obj.V2 == v1))
            {
                foreach (aresta a in this.g.ListaAresta)
                {
                    if ((a.V1 == v1 && a.V2 == v2) || (a.V1 == v2 && a.V2 == v1))
                    {
                        aresta = a;
                    }
                }
                this.g.ListaAresta.Remove(aresta);
                Console.WriteLine("Aresta " + v1 + "/" + v2 + " removida");
                return true;
            }
            else { Console.WriteLine("Aresta " + v1 + "/" + v2 + " nao existe"); return false; }
        }

        public bool modificaAresta(int v1, int v2, double peso, bool direcionado, string descricao)
        {
            aresta aresta = new aresta();
            if (this.g.ListaAresta.Any(obj => obj.V1 == v1 && obj.V2 == v2) || this.g.ListaAresta.Any(obj => obj.V1 == v2 && obj.V2 == v1))
            {
                foreach (aresta a in this.g.ListaAresta)
                {
                    if ((a.V1 == v1 && a.V2 == v2) || (a.V1 == v2 && a.V2 == v1))
                    {
                        aresta = a;
                    }
                }
                aresta.Peso = peso;
                aresta.Direcionado = direcionado;
                aresta.Descricao = descricao;
                return true;
            }
            else { Console.WriteLine("A aresta " + v1 + v2 + " nao Existe"); return false; }
        }

        public List<aresta> getArestas(int vertice)
        {
            List<aresta> retorno = new List<aresta>();
            foreach (aresta a in this.g.ListaAresta)
            {
                if (a.V1 == vertice || a.V2 == vertice)
                {
                    retorno.Add(a);
                }
            }
            return retorno;
        }
    }
}
