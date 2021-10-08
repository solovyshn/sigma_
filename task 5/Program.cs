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
            for(int i=0; i<n; i++)
            {
                strings[i] = Console.ReadLine();
            }
            ChangeString changeString = new ChangeString(strings);
            changeString.Change();
            Console.WriteLine("Changed strings:");
            changeString.Print();


            Console.WriteLine("Write the path to your file:");
            FilePath newPath = new FilePath(Console.ReadLine());
            Console.WriteLine("The name of file: " + newPath.FindNameOfFile());
            Console.WriteLine("The name of root folder: " + newPath.FindNameOfRootFolder());
        }
    }
}
