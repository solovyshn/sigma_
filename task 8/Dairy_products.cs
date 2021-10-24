using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_8
{
    class Dairy_products:Product
    {
        public readonly double expirationDate;
        public Dairy_products(string name, double price, double weight, int n, string data) : base(name, price, weight, n, data)
        {
            expirationDate = n + 3;
        }
        public Dairy_products(string str) : base(str)
        {
            expirationDate = this.Expiration + 3;
        }
        public Dairy_products(string name, double price, double weight, int n, string data, typeOfProduct t) : base(name, price, weight, n, data, t)
        {
            expirationDate = n + 3;
        }
        public override bool Equals(object obj)
        {
            if (this.GetType() != obj.GetType()) return false;
            var other = (Dairy_products)obj;
            return (this.Name == other.Name) && (this.Price == other.Price) && (this.Weight == other.Weight) && (this.Expiration == other.Expiration) && (this.MadeDay == other.MadeDay) && (this.expirationDate == other.expirationDate);

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
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
