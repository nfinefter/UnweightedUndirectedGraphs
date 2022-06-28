using System;
using System.Collections.Generic;
using System.Text;

namespace UnweightedUndirectedGraphs
{
    class Vertex<T>
    {
        public T Value { get; set; }
        public List<Vertex<T>> Neighbors { get; set; }
       
        public int NeighborCount => Neighbors.Count;

        public Vertex(T value)
        {
            Neighbors = new List<Vertex<T>>();
            Value = value;
        }
    }
}
