using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    sealed class Check {
        static public void getInfoBuy(Buy B1) {
            Console.WriteLine("Information about purchase:");
            Console.WriteLine("Count of products: " + B1.Count);
            Console.WriteLine("Price of products: " + B1.SumPrice);
            Console.WriteLine("Weight of products: " + B1.SumWeight);
            Console.WriteLine();
        }
        static public void getInfoProduct(Product P1) {
            Console.WriteLine("Information about product:");
            Console.WriteLine("Name: " + P1.Name);
            Console.WriteLine("Price: " + P1.Price);
            Console.WriteLine("Weight: " + P1.Weight);
            Console.WriteLine();
        }
    }
}
