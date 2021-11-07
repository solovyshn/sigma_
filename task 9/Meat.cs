using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_9
{
    class Meat:Product
    {
        public sort category;
        public meatType type;
        public meatType Type
        {
            get => this.type;
            set {
                this.type = value;
            }
        }
        public sort Category
        {
            get => this.category;
            set
            {
                this.category = value;
            }
        }
        public Meat(Product cpy, sort so, meatType mT) : base(cpy.Name, cpy.Price, cpy.Weight, cpy.Expiration, cpy.MadeDay)
        {
            Category = so;
            Type = mT;
        }
        public Meat(string name, double price, double weight, int n, string data, sort c, meatType t) : base(name, price, weight, n, data)
        {
            Category = c;
            Type = t;
        }
        public Meat(string str) : base(str)
        {
            string[] s = str.Split(' ');
            if (str[6].Equals("high"))
            {
                Category = sort.high;
            }
            else if (str[6].Equals("first"))
            {
                Category = sort.first;
            }
            else
            {
                Category = sort.second;
            }
            if (str[7].Equals("mutton"))
            {
                Type = meatType.mutton;
            }
            else if (str[7].Equals("veal"))
            {
                Type = meatType.veal;
            }
            else if (str[7].Equals("pork"))
            {
                Type = meatType.pork;
            }
            else
            {
                Type = meatType.chicken;
            }
        }
        public Meat(string name, double price, double weight, int n, string data, sort c, meatType t, typeOfProduct ty) : base(name, price, weight, n, data, ty)
        {
            Category = c;
            Type = t;
        }
        public override bool Equals(object obj)
        {
            if (this.GetType() != obj.GetType()) return false;
            var other = (Meat)obj;
            return (this.Name == other.Name) && (this.Price == other.Price) && (this.type == other.type) && (this.Weight == other.Weight) && (this.category == other.category) && (this.Expiration == other.Expiration) && (this.MadeDay == other.MadeDay);
        }
        public override void changePrice(double perc)
        {
            base.changePrice(perc);
            switch (category)
            {
                case sort.high:
                    Price -= Price * 0.1;
                    break;
                case sort.first:
                    Price -= Price * 0.05;
                    break;
                case sort.second:
                    Price -= Price * 0.02;
                    break;
            }
        }
        public override string ToString()
        {
            string res = base.ToString();
            res+=String.Format("Sort of meat:{0,8}\tType of meat:{1,8}\n",Category, Type);
            return res;
        }
    }
}
