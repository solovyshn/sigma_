using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_3
{
    class Accounting
    {
        private int[] kW = new int[4];
        public int KW
        {
            get { return kW[3] - kW[0]; }
        }
        public User Account { get; set; }
        public Accounting(string str)
        {
            string[] s = str.Split(' ');
            Account = new User(s[1], Convert.ToInt32(s[0]));
            for (int i = 0; i < 4; i++)
            {
                kW[i] = Convert.ToInt32(s[i + 2]);
            }
        }
        public Accounting()
        {
            this.Account = new User("Shevchenko", 10);
        }
        public Accounting(User account)
        {
            this.Account = account;
        }
        public string PrintInfo(quarts q)
        {
            Console.WriteLine(Account.Info());
            switch (q)
            {
                case quarts.first:
                    return String.Format("{0,8} {1,8} {2,8}\n{3,8} {4,8} {5,8}\n", Enum.GetName(typeof(Months), 0), Enum.GetName(typeof(Months), 1), Enum.GetName(typeof(Months), 2), (kW[1] - kW[0]), (kW[2] - kW[1]), (kW[3] - kW[2]));
                case quarts.second:
                    return String.Format("{0,8} {1,8} {2,8}\n{3,8} {4,8} {5,8}\n", Enum.GetName(typeof(Months), 3), Enum.GetName(typeof(Months), 4), Enum.GetName(typeof(Months), 5), (kW[1] - kW[0]), (kW[2] - kW[1]), (kW[3] - kW[2]));
                case quarts.third:
                    return String.Format("{0,8} {1,8} {2,8}\n{3,8} {4,8} {5,8}\n", Enum.GetName(typeof(Months), 6), Enum.GetName(typeof(Months), 7), Enum.GetName(typeof(Months), 8), (kW[1] - kW[0]), (kW[2] - kW[1]), (kW[3] - kW[2]));
                default:
                    return String.Format("{0,8} {1,8} {2,8}\n{3,8} {4,8} {5,8}\n", Enum.GetName(typeof(Months), 9), Enum.GetName(typeof(Months), 10), Enum.GetName(typeof(Months), 11), (kW[1] - kW[0]), (kW[2] - kW[1]), (kW[3] - kW[2]));
            }
        }
        public bool IsZero()
        {
            int x = 0;
            for (int i = 0; i < 3; i++)
            {
                if (kW[i + 1] - kW[i] == 0)
                    x++;
            }
            if (x == 3)
                return true;
            return false;
        }
    }
}
