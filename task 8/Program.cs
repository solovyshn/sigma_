using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_8
{
    class Program
    {
        static void Main(string[] args) {
            Console.WriteLine("Task #1:\n");

            string path = @"C:\Alaska\studying\university\3 Sem\sigma\sigma_tasks\task 8\DataForArray.txt";
            SortClass array = new SortClass(path, CompareClass.CompareByWeight);
            Console.WriteLine(array.ToString());
            array.BubbleSortProducts();
            Console.WriteLine(array.ToString());

            array.Comp -= CompareClass.CompareByWeight;
            array.Comp += CompareClass.CompareByName;
            array.BubbleSortProducts();
            Console.WriteLine(array.ToString());

            Console.WriteLine("Task #2:\n");

            string path1 = @"C:\Alaska\studying\university\3 Sem\sigma\sigma_tasks\task 8\Storage1.txt";
            var storage1 = new Storage(path1);
            Console.WriteLine("First storage:\n" + storage1.ToString());

            string path2 = @"C:\Alaska\studying\university\3 Sem\sigma\sigma_tasks\task 8\Storage2.txt";
            var storage2 = new Storage(path2);
            Console.WriteLine("Second storage:\n" + storage2.ToString());

            Console.WriteLine("Equal items:\n" + Storage.GetEquals(storage1, storage2));

            Console.WriteLine("Different items:\n" + Storage.GetDifferent(storage1, storage2));

            Console.WriteLine("Items, which are in first storage, but aren't in second:\n" + Storage.GetNotEqualFromFirst(storage1, storage2));

            Console.WriteLine("Task #3:\n");

            string path3 = @"C:\Alaska\studying\university\3 Sem\sigma\sigma_tasks\task 8\Text.txt";
            Console.WriteLine(BracketsClass.FindBrackets(path3));
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
