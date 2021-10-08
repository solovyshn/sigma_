using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_3
{
    enum quarts { first, second, third, fourth };
    enum Months
    {
        January,
        February,
        March,
        April,
        May,
        Lune,
        July,
        August,
        September,
        October,
        November,
        December
    }
    class Program
    {
        static int Main(string[] args)
        {
            string path = @"C:\Alaska\studying\university\3 Sem\sigma\sigma_tasks\task 3\Data.txt";
            if (!File.Exists(path))
            {
                Console.WriteLine("File doesn't exist");
                return 0;
            }
            using (StreamReader sr = File.OpenText(path))
            {
                string s;
                s = sr.ReadLine();
                string[] str = s.Split(' ');
                int size = Convert.ToInt32(str[0]);
                AccountingList listOfBills = new AccountingList(size, sr, str[1]);

                listOfBills.PrintInfo();
                listOfBills[3].PrintInfo(listOfBills.Quart);
                listOfBills.FindLargestDebt();
                listOfBills.Price = 7;
                listOfBills.FindLargestDebt();
                listOfBills.FindZeroDebt();
            }

            Console.WriteLine("------------------------------------------------------------------------------------");
            Console.WriteLine("Matrix:");

            Matrix array = new Matrix(5);
            array.FillMatrix();
            array.PrintMatrix();
            array.CheckSquare();

            return 0;
        }
    }
}
