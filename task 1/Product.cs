using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1
{
    class Product
    {
        private string name;
        private double price;
        private double weight;
        public string Name
        {
            get => this.name;
            set
            {
                this.name = value;
            }
        }
        public double Price
        {
            get => this.price;
            set
            {
                if (value > 0)
                {
                    this.price = value;
                }
                else
                    throw new ArgumentException("Value<0");
            }
        }
        public double Weight
        {
            get => weight;
            set
            {
                if (value > 0)
                {
                    this.weight = value;
                }
                else
                    throw new ArgumentException("Value<0");
            }
        }
        public Product(String str = "Product", double p = 0.01, double w = 0.001)
        {
            Name = str;
            Price = p;
            Weight = w;
        }
    }
}
