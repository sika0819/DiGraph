using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiGraph
{
    public class DiGraph
    {
        private int Vetx;  // 节点数  
        private int Edge;  // 边的数目  
        private List<int>[] adj; // 邻接表矩阵  
        public DiGraph(int V)
        { // 创建节点个数为V的没有边的有向图  
            Vetx = V;
            Edge = 0;
            adj = new List<int>[V];
            for (int i = 0; i < V; i++)
            {
                adj[i] = new List<int>();
            }
        }

        public void addEdge(int v, int w)
        { // 在有向图中增加边v->w  
            adj[v].Add(w);
            Edge++;
        }

        public List<int> getAdj(int v)
        { // 返回v节点的相邻节点  
            return adj[v];
        }

        public int getVetx()
        { // 返回节点数  
            return Vetx;
        }

        public int getEdge()
        { // 返回边的数目  
            return Edge;
        }

        public String toString()
        { // 打印图  
            StringBuilder s=new StringBuilder();
            s.Append(Vetx + " 个顶点, " + Edge + " 条边\n");
            for (int i = 0; i < Vetx; i++)
            {
                s.Append(i + ": ");
                for (int j=0;j< adj[i].Count;j++)
                {
                    s.Append(adj[i][j] + " ");
                }
                s.Append("\n");
            }
            return s.ToString();
        }

        public DiGraph reverse()
        {
            DiGraph g = new DiGraph(Vetx);
            for (int i = 0; i < Vetx; i++)
            {
                for (int j = 0; j < adj[i].Count; j++)
                {
                    g.addEdge(adj[i][j], i);
                }
            }
            return g;
        }
    }
}
