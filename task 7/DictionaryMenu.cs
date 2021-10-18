using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_7
{
    class DictionaryMenu
    {
        public Dictionary<string, List<double>> menu = new Dictionary<string, List<double>>();
        public Dictionary<string, double> prices = new Dictionary<string, double>();
        public DictionaryMenu(string path1, string path2)
        {
            ReadMenu(path1);
            ReadPriceTag(path2);
            menu = menu.OrderBy(item => item.Key).ToDictionary(item => item.Key, item => item.Value);
        }

        public void ReadMenu(string path)
        {
            if (!File.Exists(path)){
                throw new FileNotFoundException();
            }
            using(StreamReader sr = File.OpenText(path))
            {
                for(int i=0; !sr.EndOfStream; i++)
                {
                    string str = sr.ReadLine();
                    string[] parts = str.Split(' ');
                    if (parts.Length == 2)
                    {
                        if (!menu.ContainsKey(parts[0]))
                            menu.Add(parts[0], new List<double>() { Convert.ToDouble(parts[1]) });
                        else
                            menu[parts[0]].Add(Convert.ToDouble(parts[1]));
                    }
                }
            }
        }
        public void ReadPriceTag(string path)
        {
            if (!File.Exists(path)){
                throw new FileNotFoundException();
            }
            using (StreamReader sr = File.OpenText(path))
            {
                for(int i=0; !sr.EndOfStream; i++)
                {
                    string str = sr.ReadLine();
                    string[] parts = str.Split(' ');
                    prices.Add(parts[0], Convert.ToDouble(parts[1]));
                }
            }
        }
        public string PrintResult()
        {
            string res = "";
            foreach(var item in menu)
            {
                res += item.Key+" ";
                double sum = 0;
                foreach(var val in item.Value)
                {
                    sum += val;
                }
                res += sum + " " + (sum * prices[item.Key]) + "\n";
            }
            return res;
        }
    }
}
