using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_9
{
    enum typeOfProduct { dairy, meat, other };
    enum sort { high, first, second };
    enum meatType { mutton, veal, pork, chicken };
    class Product
    {
        private string name;
        private double price;
        private double weight;
        typeOfProduct top;
        TimeSpan expiration;
        DateTime madeDay;
        public typeOfProduct Top
        {
            get => top;
            set
            {
                this.top = value;
            }
        }
        public string Name
        {
            get { return this.name; }
            set
            {
                if (value is string)
                    this.name = value;
                else
                    throw new ArgumentException("This is not string");
            }
        }
        public double Price
        {
            get { return this.price; }
            set
            {
                if (value > 0)
                    this.price = value;
                else
                    throw new ArgumentException("Value for price < 0");
            }
        }
        public double Weight
        {
            get { return this.weight; }
            set
            {
                if (value >= 0)
                    this.weight = value;
                else
                    throw new ArgumentException("Value for weight < 0");
            }
        }
        public double Expiration
        {
            get { return this.expiration.TotalDays; }
            set
            {
                if (value > 0)
                    this.expiration = TimeSpan.FromDays(value);
                else
                    throw new ArgumentException("Value for days < 0");
            }
        }
        public string MadeDay
        {
            get { return this.madeDay.ToString("d"); }
            set
            {
                if (value is string)
                {
                    string[] str = value.Split('.');
                    if (str.Length != 3)
                    {
                        throw new FormatException("Wrong value for data");
                    }
                    int y = System.Convert.ToInt32(str[2]);
                    int m = System.Convert.ToInt32(str[1]);
                    int d = System.Convert.ToInt32(str[0]);
                    madeDay = new DateTime(y, m, d);
                }
                else
                    throw new ArgumentException("Wrong type of value for data");
            }
        }
        public Product(String str, double p, double w, double n, string data)
        {
            try
            {
                Name = str;
                Price = p;
                Weight = w;
                Expiration = n;
                MadeDay = data;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            top = typeOfProduct.other;
        }
        public Product(String str, double p, double w, double n, string data, typeOfProduct t)
        {
            try
            {
                Name = str;
                Price = p;
                Weight = w;
                Expiration = n;
                MadeDay = data;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            top = t;
        }
        public Product(string s)
        {
            string[] str = s.Split(' ');
            if (str[0].Equals("meat")) {
                top = typeOfProduct.meat;
            }
            else if (str[0].Equals("dairy")) {
                top = typeOfProduct.dairy;
            }
            else {
                top = typeOfProduct.other;
            }
            if ((top == typeOfProduct.meat && str.Length != 8) || ((top == typeOfProduct.dairy || top == typeOfProduct.other) && str.Length != 6))
                throw new ArgumentException("Data is not correct");
            try {
                Name = str[1];
            }
            catch (ArgumentException e) {
                Console.WriteLine(e.Message);
            }
            if (System.Convert.ToDouble(str[2]) == 0)
                throw new FormatException("Wrong format of data for price");
            else {
                try {
                    this.Price = System.Convert.ToDouble(str[2]);
                }
                catch (ArgumentException e) {
                    Console.WriteLine(e.Message);
                }
            }
            if (System.Convert.ToDouble(str[3]) == 0)
                throw new FormatException("Wrong format of data for weight");
            else {
                try {
                    this.Weight = System.Convert.ToDouble(str[3]);
                }
                catch (ArgumentException e) {
                    Console.WriteLine(e.Message);
                }
            }
            if (System.Convert.ToDouble(str[4]) == 0)
                throw new FormatException("Wrong format of data for days");
            else {
                try {
                    this.Expiration = System.Convert.ToDouble(str[4]);
                }
                catch (ArgumentException e) {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e) {
                    Console.WriteLine(e.Message);
                }
            }
            MadeDay = str[5];
        }
        public void Parse(string s)
        {
            string[] str = s.Split(' ');
            if (str[0].Equals("meat"))
            {
                top = typeOfProduct.meat;
            }
            else if (str[0].Equals("dairy"))
            {
                top = typeOfProduct.dairy;
            }
            else
            {
                top = typeOfProduct.other;
            }
            if ((top == typeOfProduct.meat && str.Length != 8) || ((top == typeOfProduct.dairy || top == typeOfProduct.other) && str.Length != 6))
                throw new ArgumentException("Data is not correct");
            try
            {
                Name = str[1];
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
                    this.Price = System.Convert.ToDouble(str[2]);
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
                    this.Weight = System.Convert.ToDouble(str[3]);
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
                    this.Expiration = System.Convert.ToDouble(str[4]);
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
            MadeDay = str[5];
        }
        virtual public void changePrice(double perc)
        {
            price -= price * (perc / 100);
        }
        public bool CheckFresh()
        {
            DateTime real = DateTime.Now;
            DateTime end = madeDay + expiration;
            if (real < end)
                return true;
            return false;
        }
        public override string ToString()
        {
            return String.Format("Type of product:{0,6}\tName:{1,6}\tPrice:{2,5}\tWeight:{3,5}\tExpiration:{4,4}\t\tDate:{5,10}\n", Top, Name, Price, Weight, Expiration, MadeDay);
        }
        static public void Swap(Product p1, Product p2)
        {
            typeOfProduct t = p2.Top;
            p2.Top = p1.Top;
            p1.Top = t;

            string n = p2.Name;
            p2.Name = p1.Name;
            p1.Name = n;

            double p = p2.Price;
            p2.Price = p1.Price;
            p1.Price = p;

            double w = p2.Weight;
            p2.Weight = p1.Weight;
            p1.Weight = w;

            double e = p2.Expiration;
            p2.Expiration = p1.Expiration;
            p1.Expiration = e;

            string md = p2.MadeDay;
            p2.MadeDay = p1.MadeDay;
            p1.MadeDay = md;
        }
        public override bool Equals(object obj)
        {
            if (this.GetType() != obj.GetType()) return false;
            var other = (Product)obj;
            return (this.Name == other.Name) && (this.Price == other.Price) && (this.Weight == other.Weight) && (this.Expiration == other.Expiration) && (this.MadeDay == other.MadeDay);
        }
    }   
}
