using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_5
{
    
    class Program
    {
        static void Main(string[] args) {
            Console.WriteLine("How much strings?");
            int n = Convert.ToInt32(Console.ReadLine());
            string[] strings = new string[n];
            for (int i = 0; i < n; i++)
            {
                strings[i] = Console.ReadLine();
            }
            ChangeString changeString = new ChangeString(strings);
            changeString.Change();
            Console.WriteLine("Changed strings:");
            changeString.Print();

            Console.WriteLine("Enter size of matrix:");
            string size = Console.ReadLine();
            string[] sizes = size.Split(' ');

            Matrix01 matr = new Matrix01(Convert.ToInt32(sizes[0]), Convert.ToInt32(sizes[1]), Convert.ToInt32(sizes[2]));
            Console.WriteLine(matr.Print());
            int[,] sh = matr.FindShadowNxM();
            Console.WriteLine("Shadow {0}x{1}", matr.NSize, matr.MSize);
            for (int i = 0; i < matr.MSize; i++)
            {
                for (int j = 0; j < matr.NSize; j++)
                {
                    Console.Write(sh[j, i] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            sh = matr.FindShadowNxP();
            Console.WriteLine("Shadow {0}x{1}", matr.NSize, matr.PSize);
            for (int i = 0; i < matr.NSize; i++)
            {
                for (int j = 0; j < matr.PSize; j++)
                {
                    Console.Write(sh[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            sh = matr.FindShadowMxP();
            Console.WriteLine("Shadow {0}x{1}", matr.MSize, matr.PSize);
            for (int i = 0; i < matr.MSize; i++)
            {
                for (int j = 0; j < matr.PSize; j++)
                {
                    Console.Write(sh[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("\nWrite the path to your file:");
            FilePath newPath = new FilePath(Console.ReadLine());
            Console.WriteLine("The name of file: " + newPath.FindNameOfFile());
            Console.WriteLine("The name of root folder: " + newPath.FindNameOfRootFolder());
        }
    }
}
