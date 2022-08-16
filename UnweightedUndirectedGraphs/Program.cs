using System;
using System.Collections.Generic;

namespace UnweightedUndirectedGraphs
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph<string> graph = new Graph<string>();

            //for (int i = 0; i < 10; i++)
            //{
            //    Vertex<int> vertex = new Vertex<int>(i);
            //    Vertex<int> b = new Vertex<int>(i - 1);

            //    graph.AddVertex(vertex);
            //    graph.AddVertex(b);
            //    graph.AddEdge(vertex, b);

            //    items = graph.DepthFirstSearch(vertex, b);
            //}

            Vertex<string> vertex = new Vertex<string>("LAX");

            graph.AddVertex(vertex);

            vertex = new Vertex<string>("AUS");
            graph.AddVertex(vertex);
            vertex = new Vertex<string>("SEA");
            graph.AddVertex(vertex);
            vertex = new Vertex<string>("LOG");
            graph.AddVertex(vertex);
            vertex = new Vertex<string>("JFK");
            graph.AddVertex(vertex);
            vertex = new Vertex<string>("ABA");
            graph.AddVertex(vertex);

            graph.AddEdge("LAX", "AUS");
            graph.AddEdge("AUS", "SEA");
            graph.AddEdge("LOG", "AUS");
            graph.AddEdge("LOG", "JFK");
            graph.AddEdge("SEA", "JFK");
            graph.AddEdge("SEA", "ABA");

            string[] items = graph.BreadthFirstSearch("LAX", "JFK");

            for (int i = 0; i < items.Length; i++)
            {
                Console.WriteLine(items[i]);
            }
            
        }
    }
}
