using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_9
{
    delegate int FindElement(string PrAtr, Storage Str);
    delegate void ModifyInput(Storage storage, string wrongLine, int paramCount);
    delegate void PrintIncorrect(string path, string wrongLine, int paramCounter);
    delegate void PrintMessageHandler(string message);
    delegate void PrintMessageWithLog(string path, Product product);
    delegate void FindOverdue(string path, Storage storage);
    class Storage
    {
        public event PrintMessageHandler OnAdd;
        public event PrintMessageWithLog OnAddLog;
        public event PrintIncorrect OnWrongInput;
        public event ModifyInput OnCorrectInput;
        public event FindOverdue OnFindOverdueRemoveWriteLog;

        private List<Product> prods;
        private int size;
        private FindElement findElement;
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
            prods = new List<Product>();
            findElement = null;

        }
        public Storage(int n)
        {
            Size = n;
            prods = new List<Product>();
        }
        public Storage(string path)
        {
            ReadFileFillArray(path);
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
            for (int i = 0; i < prods.Count; i++)
            {
                prods[i].changePrice(perc);
            }
        }
        public override string ToString()
        {
            OnFindOverdueRemoveWriteLog?.Invoke(@"C:\Alaska\studying\university\3 Sem\sigma\sigma_tasks\task 9\LogFile.txt", this);
            string res = "";
            int i = 0;
            foreach (var item in prods)
            {
                i++;
                res += "Information about product:" + i + "\n" + item.ToString();
            }
            return res;
        }
        public void setConstInfo()
        {
            prods[0] = new Product("Apple", 12.55, 0.426, 20, "12.09.2021");
            prods[1] = new Meat("Ham", 57.34, 0.351, 10, "10.09.2021", sort.first, meatType.pork);
            prods[2] = new Dairy_products("Milk", 20.45, 0.9, 7, "1.10.2021");
        }
        public void getInfo()
        {
            for (int i = 0; i < prods.Count; i++)
            {
                Console.WriteLine("What type of product do you want to add?(1-meat, 2-dairy, 3-else)");
                int choice;
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out choice))
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
                        this.AddElement(new Product(n, p, w, num, date));
                        break;
                    case 2:
                        this.AddElement(new Dairy_products(n, p, w, num, date, typeOfProduct.dairy));
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
                        this.AddElement(new Meat(n, p, w, num, date, c, t, typeOfProduct.meat));
                        break;
                }
            }
        }
        private void DeleteElementByNum(int pos)
        {
            if (pos > -1 && pos < Size)
            {
                prods.Remove(prods[pos]);
                Size--;
            }
            else
            {
                throw new IndexOutOfRangeException("Wrong index");
            }
        }
        private void DeleteElementByAttribute(string n, FindElement fe)
        {
            int pos = FindElement(n, findElement);
            if (pos > -1 && pos < Size)
            {
                prods.Remove(prods[pos]);
                Size--;
            }
            else
            {
                throw new IndexOutOfRangeException("There is no element with name" + n);
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
        public void ReadFileFillArray(string path)
        {
            if(prods!=null)
                prods.Clear();
            using (StreamReader sr = File.OpenText(path))
            {
                if (!File.Exists(path))
                {
                    Console.WriteLine("File doesn't exist");
                }
                else
                {
                    for (int i = 0; !sr.EndOfStream; i++)
                    {
                        string line = sr.ReadLine();
                        string[] s = line.Split(' ');
                        if (!Double.TryParse(s[2], out double price))
                        {
                            OnWrongInput?.Invoke(@"C:\Alaska\studying\university\3 Sem\sigma\sigma_tasks\task 9\LogFile.txt", line, 2);
                            OnCorrectInput?.Invoke(this, line, 2);
                            continue;
                        }

                        if(!Double.TryParse(s[3], out double weight))
                        {
                            OnWrongInput?.Invoke(@"C:\Alaska\studying\university\3 Sem\sigma\sigma_tasks\task 9\LogFile.txt", line, 3);
                            OnCorrectInput?.Invoke(this, line, 3);
                            continue;
                        }
                        if (s[0].Equals("meat"))
                        {
                            prods.Add(new Meat(line));
                        }
                        else if (s[0].Equals("dairy"))
                        {
                            prods.Add(new Dairy_products(line));
                        }
                        else
                        {
                            prods.Add(new Product(line));
                        }

                    }
                    this.Size = prods.Count;


                }

            }

        }
        public void Remove(int pos)
        {
            prods.Remove(prods[pos]);
            Size--;
        }    
        public void AddElement(Product Pr1) 
        {
            prods.Add(Pr1);
            OnAdd?.Invoke("Product was added");
            OnAddLog?.Invoke(@"C:\Alaska\studying\university\3 Sem\sigma\sigma_tasks\task 9\LogFile.txt", this.prods[Size]);
            Size++;
        }
        static public string GetEquals(Storage st1, Storage st2)
        {
            string res = "";
            for (int i = 0; i < st1.Size; i++)
            {
                for (int j = 0; j < st2.Size; j++)
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
        public int FindElement(string el, FindElement find)
        {
            int res;
            findElement = find;
            res = findElement(el, this);
            if (res > -1 && res < Size)
                return res;
            else
                throw new IndexOutOfRangeException("No element with such attribute");
        }

    }
}
