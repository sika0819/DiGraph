using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入顶点数");
            int vertxCount = int.Parse(Console.ReadLine());
            Console.WriteLine("请输入边数");
            int edgeCount = int.Parse(Console.ReadLine());
            EdgeWeightDiGraph g = new EdgeWeightDiGraph(vertxCount);
            
            for (int i = 0; i < edgeCount; i++) {
                Console.Write("输入边顶点1:");
                int v = int.Parse(Console.ReadLine());
                Console.Write("输入边顶点2:");
                int w = int.Parse(Console.ReadLine());
                DirectedEdge e = new DirectedEdge(v, w);
                g.addEdge(e);
            }
            DirectedCycle checkCircle = new DirectedCycle(g);
            if (checkCircle.hasCycle())
            {
                Console.WriteLine(checkCircle.toString());
            }
            else {
                Console.WriteLine("无环");
            }
            Console.WriteLine(g.toString());
            Console.ReadKey();
        }
    }
}
