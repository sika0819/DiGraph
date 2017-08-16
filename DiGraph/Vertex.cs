using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiGraph
{
    public class Vertex
    {
        public int i;//顶点序号啦啦啦
        private float r;//电阻
        private float e;//电流
        public float Resistance {
            get {
                return r;
            }set {
                r = value;
            }
        }//电阻
        public float Electricity {
            get {
                return e;
            }set {
                e = value;
            }
        }//电流
        public float Voltage;
        public List<DirectedEdge> adj;//邻接表
        public Vertex() {
            adj = new List<DirectedEdge>();
            i = 0;
            r = 0;
            e = 0;
        }
        public string toString() {
            return "电流:" + e + " 电阻:" + r + " 电压:" + Voltage;
        }
    }
}
