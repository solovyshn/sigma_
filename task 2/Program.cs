using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    enum sort { high, first, second };
    enum meatType { mutton, veal, pork, chicken };
    class Program
    {
        static void Main(string[] args)
        {
            Product Pr1 = new Product("Chocolate", 12.99, 400);
            Product Pr2 = new Product("Rice", 30.99, 800);

            Buy Bu1 = new Buy(Pr1, 4);
            Buy Bu2 = new Buy(Pr2, 7);

            Check.getInfoProduct(Pr1);
            Check.getInfoProduct(Pr2);

            Check.getInfoBuy(Bu1);
            Check.getInfoBuy(Bu2);

            Console.WriteLine("How much products in storage?");
            int n = Convert.ToInt32(Console.ReadLine());
            Storage data = new Storage(n);
            data.getInfo();
            data.changePrice(10);
            data.printInfo();

            Storage data2 = new Storage(3);
            data2.setConstInfo();
            data2.printInfo();
        }
    }
}
