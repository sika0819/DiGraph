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
            Console.WriteLine("先试试串联");
            Console.WriteLine("请输入顶点数");
            int vertxCount = int.Parse(Console.ReadLine());
            Console.WriteLine("请输入边数");
            int edgeCount = int.Parse(Console.ReadLine());
            EdgeWeightDiGraph g = new EdgeWeightDiGraph(vertxCount);
            for (int v = 0; v < vertxCount; v++) {
                if (v != 0)
                {
                    g.getVetrx(v).Resistance = 5;//电阻暂定为5
                }
            }
            for (int i = 0; i < edgeCount; i++) {
                Console.Write("输入边顶点1:");
                int v = int.Parse(Console.ReadLine());
                Console.Write("输入边顶点2:");
                int w = int.Parse(Console.ReadLine());
                DirectedEdge e = new DirectedEdge(v, w);
                g.addEdge(e);
            }
            g.getVetrx(0).Voltage=20;//设为电池，电压为20V
            DirectedCycle checkCircle = new DirectedCycle(g);
            checkCircle.Generation(g, g.getVetrx(0));
            if (checkCircle.hasCycle())
            {
                Console.WriteLine(checkCircle.toString());
            }
            else {
                Console.WriteLine("无环,断路");
            }
            Console.WriteLine(g.toString());
            Console.ReadKey();
        }
    }
}
