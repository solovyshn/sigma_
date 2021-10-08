using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    class Buy
    {
        public Product P1;
        private int count;
        private double sumPrice;
        private double sumWeight;
        public int Count
        {
            get => this.count;
            set
            {
                if (value > 0)
                {
                    this.count = value;
                }
                else
                    throw new ArgumentException("Value<0");
            }
        }
        public double SumPrice
        {
            get => this.sumPrice;
        }
        public double SumWeight
        {
            get => this.sumWeight;
        }
        public Buy(Product P, int n = 1)
        {
            P1 = P;
            count = n;
            sumPrice = P1.Price * count;
            sumWeight = P1.Weight * count;
        }
    }
}
