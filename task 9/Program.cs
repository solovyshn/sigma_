using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_9
{
    class Program
    {
        static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
        static void LogInFile(string path, Product product)
        {
            using (StreamWriter file = new StreamWriter(path, true))
            {
                file.WriteLine(DateTime.Now);
                file.WriteLine(product.ToString());
            }
         }
        static void LogWrongInput(string path, string wrongLine, int paramsCounter)
        {
            using (StreamWriter file = new StreamWriter(path, true))
            {
                StringBuilder result = new StringBuilder();
                result.Append("\nWrong input in line:\n" + wrongLine);
                switch (paramsCounter)
                {
                    case 1:
                        result.Append("\nWrong name\n");
                        break;
                    case 2:
                        result.Append("\nWrong price\n");
                        break;
                    default:
                        result.Append("\nWrong weight\n");
                        break;
                }
                file.WriteLine(result.ToString());

            }
        }
        static void CorrectInput(Storage storage, string wrongLine, int paramsCounter)
        {
            Console.WriteLine($"File include wrong data int line\n {wrongLine}\nDo you want to ignore program or add new data?(1-ignore, 2-add)");
            int k = Convert.ToInt32(Console.ReadLine());
            if (k == 2)
            {
                Console.WriteLine("What type of product do you want to add?(1-meat, 2-dairy, 3-else)");
                int choice;
                while (true)
                {
                    if(int.TryParse(Console.ReadLine(), out choice))
                    {
                        break;
                    }
                }
                string n, date;
                double p, w;
                int num;
                Console.WriteLine("What is the name of product?");
                n = Console.ReadLine();
                while (true)
                {
                    Console.WriteLine("How much does product cost?");
                    if (double.TryParse(Console.ReadLine(), out p))
                    {
                        break;
                    }
                }
                while (true)
                {
                    Console.WriteLine("What is the weight of product?");
                    if (double.TryParse(Console.ReadLine(), out w))
                    {
                        break;
                    }
                }
                while (true)
                {
                    Console.WriteLine("what is the shelf life of the product?");
                    if (int.TryParse(Console.ReadLine(), out num))
                    {
                        break;
                    }
                }
                Console.WriteLine("When was product made?");
                date = Console.ReadLine();
                switch (choice)
                {
                    case 3:
                        storage.AddElement(new Product(n, p, w, num, date));
                        break;
                    case 2:
                        storage.AddElement(new Dairy_products(n, p, w, num, date, typeOfProduct.dairy));
                        break;
                    case 1:                       
                        int ch;
                        while (true)
                        {
                            Console.WriteLine("What is the sort of meat?(0-high, 1-first, 2-second)");
                            if (int.TryParse(Console.ReadLine(), out ch))
                            {
                                break;
                            }
                        }
                        sort c;
                        switch (ch)
                        {
                            case 0:
                                c = sort.high;
                                break;
                            case 1:
                                c = sort.first;
                                break;
                            case 2:
                                c = sort.second;
                                break;
                            default:
                                c = sort.high;
                                break;
                        }
                        while (true)
                        {
                            Console.WriteLine("What is the type of meat?(0-mutton, 1-veal, 2-pork, 3-chicken)");
                            if (int.TryParse(Console.ReadLine(), out ch))
                            {
                                break;
                            }
                        }
                        meatType t;
                        switch (ch)
                        {
                            case 0:
                                t = meatType.mutton;
                                break;
                            case 1:
                                t = meatType.veal;
                                break;
                            case 2:
                                t = meatType.pork;
                                break;
                            case 3:
                                t = meatType.chicken;
                                break;
                            default:
                                t = meatType.chicken;
                                break;
                        }
                        storage.AddElement(new Meat(n, p, w, num, date, c, t, typeOfProduct.meat));
                        break;
                }
            }
        }
        static void FindOverdue(string path, Storage storage)
        {
            int c = 0;
            for (int i = 0; i < storage.Size; i++)
            {
                if (storage[i].CheckFresh() != true)
                {
                    c++;
                    using (StreamWriter sr = new StreamWriter(path, true))
                    {
                        if (!File.Exists(path))
                        {
                            Console.WriteLine("File doesn't exist");
                        }
                        else
                        {
                            if (c == 1)
                            {
                                sr.WriteLine(DateTime.Now);
                                sr.WriteLine("Deleted overdue products:\n");
                            }
                            sr.WriteLine(storage[i].ToString());
                        }
                    }
                    storage.Remove(i);
                }
            }
        }
        static void Main(string[] args)
        {

            string path = @"C:\Alaska\studying\university\3 Sem\sigma\sigma_tasks\task 9\Storage1.txt";
            Storage str = new Storage();
            str.OnAdd += ShowMessage;
            str.OnAddLog += LogInFile;
            str.OnWrongInput += LogWrongInput;
            str.OnCorrectInput += CorrectInput;
            str.OnFindOverdueRemoveWriteLog += FindOverdue;
            str.ReadFileFillArray(path);
            str.AddElement(new Product("else Apples 20 0,5 20 7.10.2021"));
            Console.WriteLine("First storage:\n" + str.ToString());

            /*string path1 = @"C:\Alaska\studying\university\3 Sem\sigma\sigma_tasks\task 8\Storage1.txt";
            var storage1 = new Storage(path1);
            Console.WriteLine("First storage:\n" + storage1.ToString());

            string path2 = @"C:\Alaska\studying\university\3 Sem\sigma\sigma_tasks\task 8\Storage2.txt";
            var storage2 = new Storage(path2);
            Console.WriteLine("Second storage:\n" + storage2.ToString());

            Console.WriteLine("Equal items:\n" + Storage.GetEquals(storage1, storage2));

            Console.WriteLine("Different items:\n" + Storage.GetDifferent(storage1, storage2));

            Console.WriteLine("Items, which are in first storage, but aren't in second:\n" + Storage.GetNotEqualFromFirst(storage1, storage2));

            Console.WriteLine("What attribute you know about the product you want to find in first Storage?");
            Console.WriteLine("(Enter: 1-Name, 2-Price, 3-Weight, 4-Type of Product, 5-Expiration, 6-Day of Made)");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Write the attribute:");
            string s = Console.ReadLine();
            int pos = storage1.FindElement(s, FindStaticClass.chooseAtribute(choice));
            Console.WriteLine("Your product:" + storage1[pos].ToString());*/
        }
    }
}
