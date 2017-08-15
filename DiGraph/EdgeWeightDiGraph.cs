using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiGraph
{
    public class EdgeWeightDiGraph
    {

        private Vertex[] vertexArray; // 邻接表矩阵  
        private int V; // 点的数目  
        private int E; // 边的数目  

        public EdgeWeightDiGraph(int V)
        {
            this.V = V;
            E = 0;
            vertexArray = new Vertex[V];
            for (int i = 0; i < V; i++)
            {
                Vertex vertex = new Vertex();
                vertex.adj = new List<DirectedEdge>();
                vertex.i = i;
                vertexArray[i] = vertex;
            }
        }

        public void addEdge(DirectedEdge e)
        {
            vertexArray[e.getFrom()].adj.Add(e);
            E++;
        }

        public int getV()
        {
            return V;
        }
        public Vertex getVetrx(int i) {
            return this.vertexArray[i];
        }
        public int getE()
        {
            return E;
        }

        public List<DirectedEdge> getAdj(int v)
        {
            return vertexArray[v].adj;
        }

        public List<DirectedEdge> edges()
        {
            List<DirectedEdge> edges = new List<DirectedEdge>();
            for (int i = 0; i < V; i++)
            {
                foreach (DirectedEdge e in vertexArray[i].adj)
                {
                    edges.Add(e);
                }
            }
            return edges;
        }

        public String toString()
        {
            String s = V + " 个顶点, " + E + " 条边\n";
            for (int i = 0; i < V; i++)
            {
                s += i + ": ";
                foreach (DirectedEdge e in vertexArray[i].adj)
                {
                    s += e.getTo() + " 电流：[" + e.getElectry() + "], ";
                }
                s += "\n";
            }
            return s;
        }

    }
}
