using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_4
{
    enum typeOfProduct { dairy, meat, other };
    enum sort { high, first, second };
    enum meatType { mutton, veal, pork, chicken };
    class Program
    {
        static void Main(string[] args) {
            string s = "2+1x+3x^2";
            Polynomial pol = new Polynomial();
            pol.Parse(s);
            Console.WriteLine("First Polynom:" + pol.GetPolynom());
            string g = "1+2x+8x^2+5x^3+6x^4";
            Polynomial pol2 = new Polynomial();
            pol2.Parse(g);
            Console.WriteLine("Second Polynom:" + pol2.GetPolynom());
            Polynomial res = new Polynomial(pol2.M);
            res = pol + pol2;
            Console.WriteLine("Sum:" + res.GetPolynom());
            res = pol2 - pol;
            Console.WriteLine("Difference:" + res.GetPolynom());
            res = pol * pol2;
            Console.WriteLine("Multiply:" + res.GetPolynom());
        }
    }
}
