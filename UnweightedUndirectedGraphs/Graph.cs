using System;
using System.Collections.Generic;
using System.Text;

namespace UnweightedUndirectedGraphs
{
    class Graph<T> 
    {
        public List<Vertex<T>> Vertices { get; private set; }
        
        public int VertexCount => Vertices.Count;

        public Graph()
        {
            Vertices = new List<Vertex<T>>();
        }
        
        public void AddVertex(Vertex<T> vertex)
        {
            if (vertex == null) return;
            if (vertex.NeighborCount != 0) return;
            if (Vertices.Contains(vertex)) return;

            Vertices.Add(vertex);
        }

        public bool RemoveVertex(Vertex<T> vertex)
        {
            if (Vertices.Contains(vertex))
            {
                foreach (Vertex<T> item in vertex.Neighbors)
                {
                    item.Neighbors.Remove(vertex);
                }
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
       
        public bool AddEdge(T a, T b)
        {
            return AddEdge(Search(a), Search(b));
        }

        //public bool AddEdge(T a, T b)
        //{
        //    Vertex<T> VertexA = Search(a);
        //    Vertex<T> VertexB = Search(b);
        //    if (a != null && b != null && Vertices.Contains(VertexA) && Vertices.Contains(VertexB))
        //    {
        //        VertexA.Neighbors.Add(VertexB);
        //        VertexB.Neighbors.Add(VertexA);
        //        return true;
        //    }
        //    return false;
        //}

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
                if (value.Equals(Vertices[i].Value))
                {
                    count = i;
                    break;
                }
            }
            if (count == -1) return null;
            return Vertices[count];
        }

        public List<T> DepthFirstSearch(Vertex<T> start, Vertex<T> end) // T[]
        {
            Stack<Vertex<T>> vertices = new Stack<Vertex<T>>();
            vertices.Push(start);

            Vertex<T> cursor;

            List<T> list = new List<T>();

            Dictionary<Vertex<T>, Vertex<T>> Founders = new Dictionary<Vertex<T>, Vertex<T>>();

            //for (int i = 0; i < vertices.Count; i++)
            while (vertices.Count > 0)
            {
                cursor = vertices.Pop();

                if (cursor == end)
                {
                    return Path(cursor, Founders, start);
                }

                foreach (Vertex<T> Neighbor in cursor.Neighbors)
                {
                    if (!Founders.ContainsKey(Neighbor))
                    {
                        vertices.Push(Neighbor);
                        Founders.Add(Neighbor, cursor);
                    }
                }
            }
            return new List<T>();
        }
        public List<T> DepthFirstSearch(T start, T end)
        {
            return DepthFirstSearch(Search(start), Search(end));
        }

        public List<T> Path(Vertex<T> cursor, Dictionary<Vertex<T>, Vertex<T>> Founders, Vertex<T> start)
        {
            List<T> path = new List<T>();

            while (cursor != start)
            {
                if (Founders.ContainsKey(cursor))
                {
                    path.Add(cursor.Value);

                    cursor = Founders[cursor];
                }
                else
                {
                    break;
                }
            }

            path.Add(start.Value);

            path.Reverse();

            return path;

        }

        //public List<T> DFS(Vertex<T> start, Vertex<T> end)
        //{
        //    List<T> list = new List<T>();
        //    list.Add(start.Value);
        //    list.Add(dfs(start, end));
        //    return list;
        //}
        //private T dfs(Vertex<T> start, Vertex<T> end)
        //{
        //    Vertex<T> vertex = start;
        //    for (int i = 0; i < vertex.NeighborCount; i++)
        //    {
        //        dfs(start.Neighbors[i], end);
        //        return start.Neighbors[i].Value;
        //    }
        //    return start.Value;
        //}
    }
}
