using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_6
{
    enum Days{Mon=1, Tue, Wed, Thu, Fri, Sat, Sun};
    class Program
    {
        static void Main(string[] args) {
            /*string s = "2+1x+3x^2";
            Polinom pol = new Polinom();
            pol.Parse(s);
            Console.WriteLine("First Polynom:" + pol.GetPolynom());
            string g = "1+2x+8x^2+5x^3+6x^4";
            Polinom pol2 = new Polinom();
            pol2.Parse(g);
            Console.WriteLine("Second Polynom:" + pol2.GetPolynom());
            Polinom res = new Polinom(pol2.M);
            res = -pol;
            Console.WriteLine("Sum:" + res.GetPolynom());
            res = pol + pol2;
            Console.WriteLine("Sum:" + res.GetPolynom());
            res = pol2 - pol;
            Console.WriteLine("Difference:" + res.GetPolynom());
            res = pol * pol2;
            Console.WriteLine("Multiply:" + res.GetPolynom());*/


            string path = @"C:\Alaska\studying\university\3 Sem\sigma\sigma_tasks\task 6\Data.txt";
            PIDList data = new PIDList(path);
            Console.WriteLine(data.ToString());
            Console.WriteLine("Count of visitings of 142.23.457.263: " + data.CountOfVisitings("142.23.457.263"));
            Console.WriteLine("Popular day of visitings: " + data.PopularDay());
            Console.WriteLine("Popular time of day in a week: " + data.PopularHourinWeek());
            Console.WriteLine("Popular time of day: " + data.PopularHour());
        }
    }
}
