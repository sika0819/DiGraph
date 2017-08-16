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
        private List<Stack<Vertex>> cycleList;//电流环
        private List<Stack<int>> cycleList2;//普通环
        private int[] edgeTo;
        private bool[] isMarked;

        public DirectedCycle(DiGraph g)
        {
            inStack = new bool[g.getVetx()];
            edgeTo = new int[g.getVetx()];
            cycleList =new List<Stack<Vertex>>();
            cycleList2 = new List<Stack<int>>();
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
            cycleList = new List<Stack<Vertex>>();
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
                    Stack<Vertex> cycle = new Stack<Vertex>();
                    for (int i = begin; i != node; i = edgeTo[i])
                    {
                        cycle.Push(g.getVetrx(i));
                        Console.Write("访问环点：" + i + " ");
                    }
                    cycle.Push(g.getVetrx(node));
                    Console.Write("访问环点：" + node + " ");
                    //   cycle.Push(g.getVetrx(begin));

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
                    //cycle.Push(begin);
                    cycleList2.Add(cycle);
                }
            }
            inStack[begin] = false;
        }

        public bool hasCycle()
        {
            return cycleList!=null;
        }

        public List<Stack<int>> getCycle()
        {//返回普通环
            return cycleList2;
        }
        public String toString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("有"+cycleList.Count+"个环，分别为：\n");
            for (int i = 0; i < cycleList.Count; i++)
            {
                for (int j = 0; j < cycleList[i].Count; j++)
                {
                    sb.Append(cycleList[i].ElementAt(j).i + "————>");
                }
                sb.Append("\n");
            }
            
            return sb.ToString();
        }
        /// <summary>
        /// 设计思路：
        /// 找出所有连接电池的环
        /// </summary>
        /// <param name="g"></param>
        /// <param name="battery"></param>
        public void Generation(EdgeWeightDiGraph g, Vertex battery)
        {//计算电路，为了方便直接给出电池在哪.为了方便暂定电池只有一个
            if (CheckLinked(battery)) {
                Voltage = battery.Voltage;//电池的电压为总电压
                if (cycleList.Count == 1)
                {//串联
                    Console.Write("电路为串联");
                    for (int i = 0; i < cycleList[0].Count-1; i++)
                    {
                        AllResistance += cycleList[0].ElementAt(i).Resistance;
                    }
                    if (AllResistance == 0)
                    {
                        Console.WriteLine("短路了");
                        return;
                    } 
                    Eletry = Voltage / AllResistance;
                    SetEle(g, cycleList[0], Eletry);
                    Console.WriteLine("总电阻为:"+AllResistance);
                }
                else {
                    Console.Write("并联，算法测试中……可能有bug");
                    for (int i = 0; i < cycleList.Count; i++)
                    {
                       
                    }
                }
            }
        }
        public void SetEle(EdgeWeightDiGraph g,Stack<Vertex> cycle,float electry) {//每圈分别设置电压，电流
            for (int c = 0; c < cycle.Count-1; c++)
            {
                for (int i = 0; i < g.getV(); i++) {
                    if (g.getVetrx(i) == cycle.ElementAt(c)) {
                        g.getVetrx(i).Electricity = electry;
                        if (g.getVetrx(i).Resistance != 0)//不是电线或者电池的情况下计算电压。
                        {
                            g.getVetrx(i).Voltage = electry * g.getVetrx(i).Resistance;
                        }
                        Console.WriteLine("发电中，元器件"+i+"电流为:"+electry+"电压为："+ g.getVetrx(i).Voltage);
                        for (int j = 0; j < g.getVetrx(i).adj.Count; j++)
                        {
                            g.getVetrx(i).adj[j].Electricity = electry;
                            
                        }
                    }
            }
            }
        }
        bool CheckLinked(Vertex battery)
        {//检测断路
            if (cycleList.Count > 0) { 
                for (int i = 0; i < cycleList.Count; i++)
                {
                    if (CheckBattery(cycleList[i],battery))
                        return true;
                }
            }
            Console.WriteLine("断路！请链接电池！");
            return false;
        }
        bool CheckBattery(Stack<Vertex> ring,Vertex battery) {
            return ring.Contains(battery);
        }
        
        public float AllResistance;//总电阻
        public float Voltage;//总电压
        public float Eletry;//总电流
    }
}
