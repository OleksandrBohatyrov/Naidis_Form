using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naidis_Form
{
    public class Triangle
    {
        public double a;
        public double b;
        public double c;
        public double h;
        public double m;

        public Triangle(double A, double B, double C, double H, double M)
        {
            a = A;
            b = B;
            c = C;
            h = H;
            m = M;
        }



        public string outputA()
        {
            return Convert.ToString(a);
        }
        public string outputB()
        {
            return Convert.ToString(b);
        }
        public string outputC()
        {
            return Convert.ToString(c);
        }
        public double Perimeter()
        {
            double p = 0;
            p = a + b + c;
            return p;
        }
        public double OutputH()
        {

            double s = Surface();
            double h = 2 * s / a;
            return h;

            ///double p2 = 0;
            //p2 = (a + b + c)/2;
     
            //double h = 0;
            //h = (2 / a) * (Math.Sqrt(p2*(p2-a) * (p2-b) * (p2-c)));
            //return h;
        }

        public double OutputMC()
        {
            double m = 0;
            
            m = (1 / 2) * Math.Sqrt(2 * Math.Pow(a, 2))+(2 * Math.Pow(b, 2))-Math.Pow(c,2);
            return m;
        }
        public double OutputMA()
        {
            double m = 0;

            m = (1 / 2) * Math.Sqrt(2 * Math.Pow(c, 2)) + (2 * Math.Pow(b, 2)) - Math.Pow(a, 2);
            return m;
        }
        public double OutputMB()
        {
            double m = 0;

            m = (1 / 2) * Math.Sqrt(2 * Math.Pow(a, 2)) + (2 * Math.Pow(c, 2)) - Math.Pow(b, 2);
            return m;
        }



        public double Surface()
        {
            double s = 0;
            double p = 0;
            p = (a + b + c) / 2;
            s = Math.Sqrt((p * (p - a) * (p - b) * (p - c)));
            return s;
        }

        public double GetSetA
        {
            get { return a; }
            set { a = value; }

        }

        public double GetSetB
        {
            get { return b; }
            set { b = value; }
        }
        public double GetSetC
        {
            get { return c; }
            set { c = value; }
        }

        public bool ExistTriangle
        {
            get
            {

                if ((a < b + c) && (b < a + c) && (c < a + b)) 
                return true;
                else return false;
            }
        }

    }
}
