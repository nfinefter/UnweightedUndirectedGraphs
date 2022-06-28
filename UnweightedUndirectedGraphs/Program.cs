using System;

namespace UnweightedUndirectedGraphs
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph<int> graph = new Graph<int>();

            Vertex<int> vertex = new Vertex<int>(6);

            graph.AddVertex(vertex);
        }
    }
}
