using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_3
{
    class AccountingList
    {
        private Accounting[] listOfQuart;
        private quarts quart;
        double? price;
        public double? Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = value;
            }
        }
        public quarts Quart { get; set; }
        public AccountingList(int size, StreamReader sr, string str)
        {
            int k = Convert.ToInt32(str);
            switch (k)
            {
                case 1:
                    quart = quarts.first;
                    break;
                case 2:
                    quart = quarts.second;
                    break;
                case 3:
                    quart = quarts.third;
                    break;
                case 4:
                    quart = quarts.fourth;
                    break;
            }
            listOfQuart = new Accounting[size];
            string s;
            for (int i = 0; i < size; i++)
            {
                s = sr.ReadLine();
                listOfQuart[i] = new Accounting(s);
            }

        }
        public Accounting this[int index]
        {
            get { return listOfQuart[index]; }
            set { listOfQuart[index] = value; }
        }
        public void PrintInfo()
        {
            Console.WriteLine("Information about using electricity on {0} quart", Enum.GetName(typeof(quarts), quart));
            for (int i = 0; i < listOfQuart.Length; i++)
            {
                Console.WriteLine(listOfQuart[i].PrintInfo(quart));
            }
        }
        public void FindLargestDebt()
        {
            string surnameLargest = "s";
            if (listOfQuart[0].Account.Surname != null)
            {
                surnameLargest = listOfQuart[0].Account.Surname;
            }
            int max = listOfQuart[0].KW;
            for (int i = 0; i < listOfQuart.Length; i++)
            {
                if (max < listOfQuart[i].KW)
                {
                    max = listOfQuart[i].KW;
                    if (listOfQuart[i].Account.Surname != null)
                    {
                        surnameLargest = listOfQuart[i].Account.Surname;
                    }
                }
            }
            if (price != null)
            {
                Console.WriteLine("User, that has the largest debt is {0}", surnameLargest);
            }
        }
        public void FindZeroDebt()
        {
            int count = 0;
            for (int i = 0; i < listOfQuart.Length; i++)
            {
                if (listOfQuart[i].IsZero() == true)
                {
                    Console.WriteLine("Number of flat, that hasn't used electricity for this quart: {0}", listOfQuart[i].Account.NumOfFlat);
                    count++;
                    break;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("There is no user that hasn't used electricity for this quart");
            }
        }
    }
}