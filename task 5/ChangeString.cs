using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_5
{
    class ChangeString
    {
        private string[] forChange;
        public ChangeString(string[] s)
        {
            forChange = new string[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                forChange[i] = s[i];
            }
        }
        public string this[int index]
        {
            get
            {
                return this.forChange[index];
            }
            set
            {
                if (index > 0)
                    this.forChange[index] = value;
                else
                    throw new IndexOutOfRangeException();
            }
        }
        public void Change()
        {
            for (int i = 0; i < forChange.Length; i++)
            {
                string[] s = forChange[i].Split(' ');
                for (int j = 0; j < s.Length; j++)
                {
                    char[] sAsChars = s[j].ToCharArray();
                    if (sAsChars[0] == '#')
                    {
                        sAsChars[0] = '<';
                    }
                    if (sAsChars[sAsChars.Length - 1] == '#')
                    {
                        sAsChars[sAsChars.Length - 1] = '>';
                    }
                    s[j] = new string(sAsChars);
                }
                forChange[i] = "";
                for (int j = 0; j < s.Length; j++)
                {
                    forChange[i] += s[j] + ' ';
                }
            }
        }
        public void Print()
        {
            for (int i = 0; i < forChange.Length; i++)
            {
                Console.WriteLine(forChange[i]);
            }
        }
    }
}
