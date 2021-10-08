using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    class Meat : Product {
        public sort category;
        public meatType type;
        public Meat(Product cpy, sort so, meatType mT) : base(cpy.Name, cpy.Price, cpy.Weight)
        {
            category = so;
            type = mT;
        }
        public Meat(string name, double price, double weight, sort c, meatType t) : base(name, price, weight)
        {
            category = c;
            type = t;
        }
        public override bool Equals(object obj)
        {
            if (this.GetType() != obj.GetType()) return false;
            var other = (Meat)obj;
            return (this.Name == other.Name) && (this.Price == other.Price) && (this.type == other.type) && (this.Weight == other.Weight) && (this.category == other.category);
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
    }
}
