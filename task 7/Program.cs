using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("I", "Boy");
            dictionary.Add("go", "run");
            dictionary.Add("to", "to");
            dictionary.Add("school", "cinema");

            string text = "I go to school. I run to university. She go to school.";

            string[] sentences = text.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> words = new List<string>();
            for (int i = 0; i < sentences.Length; i++)
            {
                words.AddRange(sentences[i].Split());
            }

            foreach (var item in words)
            {
                Console.WriteLine(item);
            }
            for (int i = 0; i < words.Count; i++)
            {
                if (dictionary.ContainsKey(words[i]))
                {
                    words[i] = dictionary[words[i]];
                }
                else if (dictionary.ContainsValue(words[i]))
                {
                    words[i] = GetKeyFromValue(dictionary, words[i]);
                }
                else if (!String.IsNullOrEmpty(words[i]))
                {
                    Console.WriteLine("Dictionary doesn`t include \"{0}\". Do you want to add this word to dictionary?(1 - yes, 2 - no)", words[i]);
                    int ch;
                    ch = Convert.ToInt32(Console.ReadLine());
                    if (ch == 1)
                    {
                        Console.WriteLine("Enter word, which can replace \"" + words[i] + "\"");
                        string word;
                        word = Console.ReadLine();
                        dictionary.Add(words[i], word);
                        words[i] = dictionary[words[i]];
                    }

                }
            }
            Console.WriteLine();
            string result = "";
            for (int i = 0; i < words.Count; i++)
            {
                if (string.IsNullOrEmpty(words[i]))
                {
                    result += ". ";
                }
                else
                {
                    result += words[i];
                    if (i + 1 != words.Count)
                    {
                        if (!string.IsNullOrEmpty(words[i + 1]))
                            result += ' ';
                    }
                    if (i + 1 == words.Count)
                    {
                        result += '.';
                    }
                }
            }
            Console.WriteLine("Result: " + result);
            Console.WriteLine();

            Console.WriteLine("Second task result:");
            string pathMenu = @"C:\Alaska\studying\university\3 Sem\sigma\sigma_tasks\task 7\Menu.txt";
            string pathPrice = @"C:\Alaska\studying\university\3 Sem\sigma\sigma_tasks\task 7\Price tag.txt";


            DictionaryMenu dict = new DictionaryMenu(pathMenu, pathPrice);
            Console.WriteLine(dict.PrintResult());































        }
        public static string GetKeyFromValue(Dictionary<string, string> dict, string value)
        {
            foreach (string keyVar in dict.Keys)
            {
                if (dict[keyVar] == value)
                {
                    return keyVar;
                }
            }
            return null;
        }
    }
}
