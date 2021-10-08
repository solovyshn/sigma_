using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    class Storage
    {
        Product[] prods;
        public Storage(int n)
        {
            prods = new Product[n];
        }
        public Product this[int index]
        {
            get
            {
                return prods[index];
            }
            set
            {
                prods[index] = value;
            }
        }
        public void changePrice(double perc)
        {
            for (int i = 0; i < prods.Length; i++)
            {
                prods[i].changePrice(perc);
            }
        }
        public void printInfo()
        {
            for (int i = 0; i < prods.Length; i++)
            {
                Console.WriteLine("Information about product:" + (i + 1));
                Console.WriteLine("Name: " + prods[i].Name);
                Console.WriteLine("Price: " + prods[i].Price);
                Console.WriteLine("Weight: " + prods[i].Weight);
                Console.WriteLine();
            }
        }
        public void setConstInfo()
        {
            prods[0] = new Product("Apple", 12.55, 0.426);
            prods[1] = new Meat("Ham", 57.34, 0.351, sort.first, meatType.pork);
            prods[2] = new Dairy_products("Milk", 20.45, 0.9, 10);
        }
        public void getInfo()
        {
            for (int i = 0; i < prods.Length; i++)
            {
                Console.WriteLine("What type of product do you want to add?(1-meat, 2-dairy, 3-else)");
                int choice;
                choice = Convert.ToInt32(Console.ReadLine());
                string n;
                double p, w;
                int num;
                switch (choice)
                {
                    case 3:
                        Console.WriteLine("What is the name of product?");
                        n = Console.ReadLine();
                        Console.WriteLine("How much does product cost?");
                        p = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("What is the weight of product?");
                        w = Convert.ToDouble(Console.ReadLine());
                        prods[i] = new Product(n, p, w);
                        break;
                    case 2:
                        Console.WriteLine("What is the name of product?");
                        n = Console.ReadLine();
                        Console.WriteLine("How much does product cost?");
                        p = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("What is the weight of product?");
                        w = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("what is the shelf life of the product?");
                        num = Convert.ToInt32(Console.ReadLine());
                        prods[i] = new Dairy_products(n, p, w, num);
                        break;
                    case 1:
                        Console.WriteLine("What is the name of product?");
                        n = Console.ReadLine();
                        Console.WriteLine("How much does product cost?");
                        p = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("What is the weight of product?");
                        w = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("What is the sort of meat?(0-high, 1-first, 2-second)");
                        int ch = Convert.ToInt32(Console.ReadLine());
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
                        Console.WriteLine("What is the type of meat?(0-mutton, 1-veal, 2-pork, 3-chicken)");
                        ch = Convert.ToInt32(Console.ReadLine());
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
                        prods[i] = new Meat(n, p, w, c, t);
                        break;
                }
            }
        }
    }
}
