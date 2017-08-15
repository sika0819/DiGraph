using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiGraph
{
    public class DirectedCycle
    { // 判断图是否有环  

        private bool[] inStack;
        private List<Stack<int>> cycleList;
        private int[] edgeTo;
        private bool[] isMarked;

        public DirectedCycle(DiGraph g)
        {
            inStack = new bool[g.getVetx()];
            edgeTo = new int[g.getVetx()];
            cycleList =new List<Stack<int>>();
            isMarked = new bool[g.getVetx()];
            for (int i = 0; i < g.getVetx(); i++)
            {
                if (!isMarked[i])
                {
                    dfs(g, i);
                }
            }
        }
        public DirectedCycle(EdgeWeightDiGraph g)
        {
            inStack = new bool[g.getV()];
            edgeTo = new int[g.getV()];
            isMarked = new bool[g.getV()];
            cycleList = new List<Stack<int>>();
            for (int i = 0; i < g.getV(); i++)
            {
                if (!isMarked[i])
                {
                    dfs(g, i);
                }
            }
        }

        private void dfs(EdgeWeightDiGraph g, int begin)
        {
            isMarked[begin] = true;
            inStack[begin] = true;
            foreach (DirectedEdge e in g.getAdj(begin))
            {
                int node = e.getTo();
                //if (hasCycle()) return;

                if (!isMarked[node])
                {
                    edgeTo[node] = begin;
                    dfs(g, node);
                }
                else if (inStack[node])
                { // 如果当前路径Stack中含有node，又再次访问的话，说明有环  
                  // 将环保存下来  
                    Stack<int> cycle = new Stack<int>();
                    for (int i = begin; i != node; i = edgeTo[i])
                    {
                        cycle.Push(i);
                    }
                    cycle.Push(node);
                    cycle.Push(begin);
                    cycleList.Add(cycle);
                }
            }
            inStack[begin] = false;
        }
        private void dfs(DiGraph g, int begin)
        {
            isMarked[begin] = true;
            inStack[begin] = true;
            for (int node=0; node<g.getAdj(begin).Count;node++)
            {
               // if (hasCycle()) return;
                int nodeValue = g.getAdj(begin)[node];
                if (!isMarked[nodeValue])
                {
                    edgeTo[nodeValue] = begin;
                    dfs(g, nodeValue);
                }
                else if (inStack[nodeValue])
                { // 如果当前路径Stack中含有node，又再次访问的话，说明有环  
                  // 将环保存下来  
                    Stack<int> cycle = new Stack<int>();
                    for (int i = begin; i != nodeValue; i = edgeTo[i])
                    {
                        cycle.Push(i);
                    }
                    cycle.Push(nodeValue);
                    cycle.Push(begin);
                    cycleList.Add(cycle);
                }
            }
            inStack[begin] = false;
        }

        public bool hasCycle()
        {
           
            return cycleList!=null;
        }

        public List<Stack<int>> getCycle()
        {
            return cycleList;
        }
        public String toString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("有"+cycleList.Count+"个环，分别为：\n");
            for (int i = 0; i < cycleList.Count; i++)
            {
                for (int j = 0; j < cycleList[i].Count; j++)
                {
                    sb.Append(cycleList[i].ElementAt(j) + "————>");
                }
                sb.Append("\n");
            }
            
            return sb.ToString();
        }
        /// <summary>
        /// 设计思路：查共有节点，从共有节点开始遍历环路。所有环路
        /// </summary>
        /// <param name="g"></param>
        /// <param name="battery"></param>
        public void Generation(EdgeWeightDiGraph g, Vertex battery)
        {//计算电路，为了方便直接给出电池在哪.为了方便暂定电池只有一个
            bool[] isbinglian = new bool[cycleList.Count];
            int falseCount = 0;
            for (int i = 0; i < cycleList.Count; i++)
            {
                if (!cycleList[i].Contains(battery.i))
                    falseCount++;
                if (falseCount == cycleList.Count - 1)
                {
                    Console.Write("断路，不计算");
                    return;
                }
            }
        }
        public float AllResistance;//总电阻
        public float Voltage;//总电压
        public float Eletry;//总电流
    }
}
