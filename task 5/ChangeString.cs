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
            
            int n = 0;
            for (int i=0; i<forChange.Length; i++)
            {
                char[] sAsChars = forChange[i].ToCharArray();
                for(int j=0; j<sAsChars.Length; j++)
                {
                    if(sAsChars[j]=='#')
                        n++;
                }
            }
            int cpy = n;
            for(int i=0; i<forChange.Length; i++) {
                char[] sAsChars = forChange[i].ToCharArray();
                for (int j = 0; j < sAsChars.Length; j++)
                {
                    if (sAsChars[j] == '#') {
                        if (cpy > n / 2)
                        {
                            sAsChars[j] = '<';
                            cpy--;
                        }
                        else if (cpy != 0)
                        {
                            sAsChars[j] = '>';
                        }
                    } 
                }
                forChange[i] = new string(sAsChars);
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
