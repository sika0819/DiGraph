using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiGraph
{
    public class DirectedDFS
    { // 深搜解决图的可达性和路径，保存拓扑排序  

        private bool[] isMarked; // 是否可达  
        private int[] edgeTo; // 记录路径  
        private List<int> begin; // 开始节点们  
      
    private List<int> reversePost; // 拓扑排序顺序  
      
    public DirectedDFS(DiGraph g)
        { // 所有节点遍历  
            reversePost = new List<int>();
            isMarked = new bool[g.getVetx()];
            edgeTo = new int[g.getVetx()];
            List<int> begins = new List<int>();
            for (int i = 0; i < g.getVetx(); i++)
            {
                begins.Add(i);
            }
            this.begin = begins;
            for (int i = 0; i < g.getVetx(); i++)
            {
                if (!isMarked[i])
                {
                    dfs(g, i);
                }
            }
        }

        public DirectedDFS(DiGraph g, int begin)
        { // 从begin节点开始，进行深搜  
            reversePost = new List<int>();
            isMarked = new bool[g.getVetx()];
            edgeTo = new int[g.getVetx()];
            this.begin = new List<int>();
            this.begin.Add(begin);
            dfs(g, begin);
        }

        public DirectedDFS(DiGraph g, List<int> begins)
        { // 找出一堆begin中所有可达的地方  
            reversePost = new List<int>();
            isMarked = new bool[g.getVetx()];
            edgeTo = new int[g.getVetx()];
            this.begin = begins;
            for (int i = 0; i < begin.Count; i++)
            {
                if (!isMarked[i])
                {
                    dfs(g, begin[i]);
                }
            }
        }

        public void dfs(DiGraph g, int begin)
        { // 深搜将所有节点遍历,标记被访问过的节点  
            isMarked[begin] = true;
            for (int node=0;node< g.getAdj(begin).Count;node++)
            {
                int nodeValue = g.getAdj(begin)[node];
                if (!isMarked[nodeValue])
                {
                    edgeTo[nodeValue] = begin;
                    dfs(g, nodeValue);
                }
            }
            reversePost.Add(begin);
        }

        public bool hasPath(int v)
        {
            return isMarked[v];
        }

        public String pathTo(int v)
        {
            if (!hasPath(v))
            {
                return "";
            }
            Stack<int> stack = new Stack<int>();
            stack.Push(v);
            for (int i = v; !begin.Contains(i); i = edgeTo[i])
            {
                stack.Push(edgeTo[i]);
            }

            return stack.ToString();
        }

        public IEnumerable<int> getReversePost()
        {
            return reversePost;
        }
    }
}
