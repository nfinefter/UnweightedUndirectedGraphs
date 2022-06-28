using System;
using System.Collections.Generic;
using System.Text;

namespace UnweightedUndirectedGraphs
{
    class Graph<T> where T : IComparable<T>
    {
        public List<Vertex<T>> Vertices { get; private set; }

        public int VertexCount => Vertices.Count;

        public Graph()
        {
            
        }
        
        public void AddVertex(Vertex<T> vertex)
        {
            if (vertex == null) return;
            if (vertex.NeighborCount != 0) return;
            if (!Vertices.Contains(vertex)) return;

            Vertices.Add(vertex);
        }

        public bool RemoveVertex(Vertex<T> vertex)
        {
            if (Vertices.Contains(vertex))
            {
                //How to remove edges
                //vertex.Neighbors.RemoveAll();
                Vertices.Remove(vertex);
                return true;
            }
            return false;
        }

        public bool AddEdge(Vertex<T> a, Vertex<T> b)
        {
            if (a != null && b != null && Vertices.Contains(a) && Vertices.Contains(b))
            {
                b.Neighbors.Add(a);
                a.Neighbors.Add(b);
                return true;
            }
            return false;
        }

        public bool RemoveEdge(Vertex<T> a, Vertex<T> b)
        {
            if (a != null && b != null && a.Neighbors.Contains(b) && b.Neighbors.Contains(a))
            {
                
                a.Neighbors.Remove(b);
                b.Neighbors.Remove(a);
                return true;
            }
            return false;
        }
        public Vertex<T> Search(T value)
        {
            int count = -1;

            for (int i = 0; i < Vertices.Count; i++)
            {
                if (value.CompareTo(Vertices[i].value) == 0)
                {
                    count = i;
                    break;
                }
            }
            if (count == -1) return null;
            return Vertices[count];
        }
    }
}
