using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiGraph
{
    public class DirectedEdge
    {

        private double elec;//电流
        private float res=0;//电阻
        
        private int from;
        private int to;

        public DirectedEdge(int from, int to)
        {
            this.from = from;
            this.to = to;
        }
        public double Electricity {
            get {
                return elec;
            }set {
                elec = value;
            }
        }
        public int getFrom()
        {
            return from;
        }

        public int getTo()
        {
            return to;
        }

        public double getElectry()
        {
            return elec;
        }

        public int compareTo(DirectedEdge e)
        {
            if (elec > e.getElectry()) return 1;
            if (elec < e.getElectry()) return -1;
            return 0;
        }

        public String toString()
        {
            String s = from + " -> " + to + ", 电流: " + elec;
            return s;
        }

    }
}
