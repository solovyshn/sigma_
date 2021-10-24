using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_8
{
    class Storage
    {
        private Product[] prods;
        private int size;
        public int Size
        {
            get => size;
            set
            {
                if (value > 0)
                    this.size = value;
                else
                    throw new ArgumentException("Value<0");
            }
        }
        public Storage()
        {
            Size = 1;
            prods = new Product[Size];
        }
        public Storage(int n)
        {
            Size = n;
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
        public override string ToString()
        {
            string res = "";
            for (int i = 0; i < prods.Length; i++)
            {
                res += "Information about product:" + (i + 1) + "\n" + prods[i].ToString();
            }
            return res;
        }
        public void removeOverdue(string path)
        {
            for (int i = 0; i < Size; i++)
            {
                if (prods[i].CheckFresh() != true)
                {
                    WriteToFile(i, path);
                    DeleteElement(i);
                }
            }
        }
        public void setConstInfo()
        {
            prods[0] = new Product("Apple", 12.55, 0.426, 20, "12.09.2021");
            prods[1] = new Meat("Ham", 57.34, 0.351, 10, "10.09.2021", sort.first, meatType.pork);
            prods[2] = new Dairy_products("Milk", 20.45, 0.9, 7, "1.10.2021");
        }
        public void getInfo()
        {
            for (int i = 0; i < prods.Length; i++)
            {
                Console.WriteLine("What type of product do you want to add?(1-meat, 2-dairy, 3-else)");
                int choice;
                choice = Convert.ToInt32(Console.ReadLine());
                string n, date;
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
                        Console.WriteLine("what is the shelf life of the product?");
                        num = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("When was product made?");
                        date = Console.ReadLine();
                        prods[i] = new Product(n, p, w, num, date);
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
                        Console.WriteLine("When was product made?");
                        date = Console.ReadLine();
                        prods[i] = new Dairy_products(n, p, w, num, date, typeOfProduct.dairy);
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
                        Console.WriteLine("what is the shelf life of the product?");
                        num = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("When was product made?");
                        date = Console.ReadLine();
                        prods[i] = new Meat(n, p, w, num, date, c, t, typeOfProduct.meat);
                        break;
                }
            }
        }
        private void DeleteElement(int pos)
        {
            Product[] copy = new Product[Size - 1];
            for (int i = 0, j = 0; i < Size; i++)
            {
                if (i != pos)
                {
                    copy[j] = prods[i];
                    j++;
                }
            }
            Size--;
            prods = new Product[Size];
            for (int i = 0; i < Size; i++)
            {
                prods[i] = copy[i];
            }
        }
        public void Parse(string s, int pos)
        {
            typeOfProduct t;
            string n = "", date = "";
            double p = 0, w = 0;
            int num = 0;
            string[] str = s.Split(' ');
            if (str[0].Equals("meat"))
            {
                t = typeOfProduct.meat;
            }
            else if (str[0].Equals("dairy"))
            {
                t = typeOfProduct.dairy;
            }
            else
            {
                t = typeOfProduct.other;
            }
            if ((t == typeOfProduct.meat && str.Length != 8) || ((t == typeOfProduct.dairy || t == typeOfProduct.other) && str.Length != 6))
                throw new ArgumentException("Data is not correct");
            try
            {
                n = str[1];
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            if (System.Convert.ToDouble(str[2]) == 0)
                throw new FormatException("Wrong format of data for price");
            else
            {
                try
                {
                    p = System.Convert.ToDouble(str[2]);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            if (System.Convert.ToDouble(str[3]) == 0)
                throw new FormatException("Wrong format of data for weight");
            else
            {
                try
                {
                    w = System.Convert.ToDouble(str[3]);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            if (System.Convert.ToDouble(str[4]) == 0)
                throw new FormatException("Wrong format of data for days");
            else
            {
                try
                {
                    num = System.Convert.ToInt32(str[4]);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            date = str[5];
            if (t == typeOfProduct.meat)
            {
                sort sot; meatType mT;
                if (str[6] == "high")
                {
                    sot = sort.high;
                }
                else if (str[6] == "first")
                {
                    sot = sort.first;
                }
                else
                {
                    sot = sort.second;
                }
                if (str[7] == "mutton")
                {
                    mT = meatType.mutton;
                }
                else if (str[7] == "veal")
                {
                    mT = meatType.veal;
                }
                else if (str[7] == "pork")
                {
                    mT = meatType.pork;
                }
                else
                {
                    mT = meatType.chicken;
                }
                prods[pos] = new Meat(n, p, w, num, date, sot, mT, typeOfProduct.meat);
            }
            else if (t == typeOfProduct.dairy)
                prods[pos] = new Dairy_products(n, p, w, num, date);
            else
                prods[pos] = new Product(n, p, w, num, date);

        }
        private void WriteToFile(int pos, string path)
        {
            using (StreamWriter sr = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                if (!File.Exists(path))
                {
                    Console.WriteLine("File doesn't exist");
                }
                else
                {
                    sr.WriteLine(prods[pos].ToString());
                }
            }
        }
        public Storage(string path)
        {
            ReadFromFile(path);
        }
        public void ReadFromFile(string path)
        {
            using (StreamReader sr = File.OpenText(path))
            {
                if (!File.Exists(path))
                {
                    Console.WriteLine("File doesn't exist");
                }
                else
                {

                    string[] str = new string[100];
                    int c = 0;
                    for (int i = 0; !sr.EndOfStream; i++)
                    {
                        str[i] = sr.ReadLine();
                        c++;
                    }
                    try
                    {
                        this.Size = c;
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    prods = new Product[Size];
                    for (int i = 0; i < this.Size; i++)
                    {
                        try
                        {
                            string[] s = str[i].Split(' ');
                            if (str[0].Equals("meat"))
                            {
                                prods[i] = new Meat(str[i]);
                            }
                            else if (str[0].Equals("dairy"))
                            {
                                prods[i] = new Dairy_products(str[i]);
                            }
                            else
                            {
                                prods[i] = new Product(str[i]);
                            }
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }

                }

            }
        }
        public void AddElement()
        {
            Product[] copy = new Product[Size];
            for (int i = 0; i < Size; i++)
            {
                copy[i] = prods[i];
            }
            Size++;
            prods = new Product[Size];
            for (int i = 0; i < Size - 1; i++)
            {
                prods[i] = copy[i];
            }
        }
        static public string GetEquals(Storage st1, Storage st2)
        {
            string res = "";
            for(int i=0; i<st1.Size; i++)
            {
                for(int j=0; j<st2.Size; j++)
                {
                    if (st1.prods[i].Top == st2.prods[j].Top)
                    {
                        if (st1.prods[i].Equals(st2.prods[j]) == true)
                        {
                            res += st1.prods[i].ToString();
                        }
                    }
                    else
                        continue;
                }
            }
            return res;
        }
        static public string GetDifferent(Storage st1, Storage st2)
        {
            return GetNotEqualFromFirst(st1, st2) + GetNotEqualFromFirst(st2, st1);
        }
        static public string GetNotEqualFromFirst(Storage st1, Storage st2)
        {
            string res = "";
            for (int i = 0; i < st1.Size; i++)
            {
                bool check = false;
                for (int j = 0; j < st2.Size; j++)
                {
                    if (st1.prods[i].Top == st2.prods[j].Top)
                    {
                        if (st1.prods[i].Equals(st2.prods[j]) == true)
                        {
                            check = true;
                        }
                    }
                    else
                        continue;
                }
                if (!check)
                    res += st1.prods[i].ToString();
            }
            return res;
        }
    }
}
