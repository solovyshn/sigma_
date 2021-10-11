using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_6
{
    class PIDList
    {
        PIDData[] list;
        int size;
        public PIDList(int n = 1)
        {
            Size = n;
            list = new PIDData[Size];
        }
        public PIDList(string s)
        {
            this.ReadFile(s);
        }
        public int Size
        {
            get => this.size;
            set
            {
                if (value > 0)
                    this.size = value;
                else
                    throw new ArgumentException("Value<0");
            }
        }
        public string this[int index]
        {
            get
            {
                if (index >= 0 && index < this.Size)
                {
                    return this.list[index].ToString();
                }
                else
                    throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < this.Size)
                {
                    list[index].Parse(value);
                }
            }
        }
        public string PopularDay() {
            string res = "";
            int moda = 0, index=0;
            for(int i=0; i<this.Size; i++) {
                int n = 0;
                for(int j=0; j<this.Size; j++)
                {
                    if (list[i].Day == list[j].Day)
                    {
                        n++;
                        index = i;
                    }
                }
                if (n > moda)
                {
                    moda = n;
                    res = list[index].Day;
                }
            }
            return res;
        }
        public string PopularHour() {
            string res = "";
            int moda = 0;
            for(int i=0; i<this.Size; i++)
            {
                int n = 0;
                string[] str = this.list[i].Time.Split(':');
                string timei = str[0];
                for(int j=0; j<this.Size; j++)
                {
                    string[] strka = this.list[j].Time.Split(':');
                    string timej = strka[0];
                    if (timei == timej&&list[i].Day==list[j].Day)
                    {
                        n++;
                    }
                }
                if (n > moda)
                {
                    moda = n;
                    res = list[i].Day + ' ' + timei + " o'clock";
                }
            }
            return res;
        }
        public string PopularHourinWeek()
        {
            string res = "";
            int moda = 0;
            for (int i = 0; i < this.Size; i++)
            {
                int n = 0;
                string[] str = this.list[i].Time.Split(':');
                string timei = str[0];
                for (int j = 0; j < this.Size; j++)
                {
                    string[] strka = this.list[j].Time.Split(':');
                    string timej = strka[0];
                    if (timei == timej)
                    {
                        n++;
                    }
                }
                if (n > moda)
                {
                    moda = n;
                    res = timei + " o'clock";
                }
            }
            return res;
        }
        public int CountOfVisitings(string pid)
        {
            int count = 0;
            for(int i=0; i<this.Size; i++)
            {
                if (this.list[i].Pid == pid)
                    count++;
            }
            return count;
        }
        public void ReadFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }
            using (StreamReader sr = File.OpenText(path))
            {
                string[] str = new string[100];
                int c = 0;
                for(int i=0; !sr.EndOfStream; i++)
                {
                    str[i] = sr.ReadLine();
                    c++;
                }
                this.Size = c;
                this.list = new PIDData[this.Size];
                for(int i=0; i<this.Size; i++)
                {
                    this.list[i] = new PIDData(str[i]);
                }
            }
        }
        public override string ToString()
        {
            string res = "";
            for(int i=0; i<this.Size; i++)
            {
                res += this.list[i].Pid + ' ' + this.list[i].Time + ' ' + this.list[i].Day + "\n";
            }
            return res;
        }
    }
}
