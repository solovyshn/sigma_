using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    class Dairy_products:Product {
        public readonly int expirationDate;
        public Dairy_products(string name, double price, double weight, int n) : base(name, price, weight)
        {
            expirationDate = n;
        }
        public override bool Equals(object obj)
        {
            if (this.GetType() != obj.GetType()) return false;
            var other = (Dairy_products)obj;
            return (this.Name == other.Name);
        }
        public override void changePrice(double perc)
        {
            base.changePrice(perc);
            if (expirationDate > 30)
            {
                Price -= Price * 0.03;
            }
            else
            {
                Price -= Price * 0.05;
            }
        }
    }
}
