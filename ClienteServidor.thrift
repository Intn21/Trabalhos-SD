namespace * ClienteServidor


struct vertice
{
	1: i32 nome,
	2: i32 cor,
	3: string descricao,
	4: double peso
}

struct aresta
{
	1: i32 v1,
	2: i32 v2,
	3: double peso,
	4: bool direcionado,
	5: string descricao
}

struct grafo
{
	1: list<vertice> ListaVertices,
	2: list<aresta> ListaAresta,
}

service ClienteServidor
{
	bool insereVertice(1: i32 nome, 2: i32 cor, 3: string descricao, 4: double peso),
	bool removeVertice(1: i32 nomeVertice),
	bool modificaVertice(1: i32 nome, 2: i32 cor, 3: string descricao, 4: double peso),
	vertice lerVertice(1: i32 nome),
	list<vertice> getVertices(1: aresta E),
	list<vertice> getVizinhos(1: i32 nome),
	
	bool insereAresta(1: i32 v1, 2: i32 v2, 3:double peso, 4: bool direcionado, 5: string descricao),
	bool removeAresta(1: i32 v1, 2: i32 v2),
	bool modificaAresta(1: i32 v1, 2: i32 v2, 3:double peso, 4: bool direcionado, 5: string descricao),
	aresta lerAresta(1: i32 v1, 2: i32 v2),
	list<aresta> getArestas(1: i32 vertice),
	
	
}