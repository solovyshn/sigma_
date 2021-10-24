using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_8
{
    static class BracketsClass
    {

        public static string FindBrackets(string path)
        {
            string[] lines = new string[100];
            int size = 0;
            ReadFile(path, ref lines, ref size);
            bool FoundMax = false;
            int c = 0, max = 0, index = 0, lineFirst = 0, maxLineFirst = 0, lineLast = 0, maxLineLast = 0, indexFirstBrack = 0, maxIndexFirst = 0, indexLastBrack = 0, maxIndexLast = 0;
            for(int i=0; i<size; i++)
            {
                for(int j=0; j<lines[i].Length; j++)
                {
                    if (lines[i][j] == '(')
                    {
                        c++;
                        if (lineFirst == 0 && FoundMax == false)
                        {
                            lineFirst = i;
                            indexFirstBrack = j;
                        }
                    }
                    else if (lines[i][j] == ')')
                    {
                        if (max < c)
                        {
                            max = c;
                            index = i;
                            maxLineFirst = lineFirst;
                            maxIndexFirst = indexFirstBrack;
                            FoundMax = true;
                        }
                        if (FoundMax && c == 1)
                        {
                            maxLineLast = i;
                            maxIndexLast = j;
                            FoundMax = false;
                        }
                        c--;
                        lineFirst = 0;
                    }
                }
                /*if (c > 0)
                {
                    lineFirst++;
                }*/
            }
            return FindSentence(lines, size, index, maxLineFirst, maxIndexFirst, maxLineLast, maxIndexLast);
        }
        static void ReadFile(string path, ref string[] arr, ref int n)
        {
            using (StreamReader sr = File.OpenText(path))
            {
                if (!File.Exists(path))
                {
                    Console.WriteLine("File doesn't exist");
                }
                else
                {
                    for (int i = 0; !sr.EndOfStream; i++)
                    {
                        arr[i] = sr.ReadLine();
                        n++;
                    }

                }
            }
        }
        static string FindSentence(string[] str, int n, int c, int lineF, int first, int lineL, int last)
        {
            int k1 = 0, l1 = 0, k2 = 0, l2 = 0;
            string res = "";
            if (lineL-lineF == 0) {
                for(int i=first; i>=0; i--)
                {
                    if (str[c][i] == '.')
                    {
                        k1 = i;
                        break;
                    }
                }
                for(int i=k1+2; str[c][i-1]!='.'; i++)
                {
                    res += str[c][i];
                }
            }
            else
            {
                for(int i=lineF; i>=0; i--)
                {
                    bool ch = true;
                    for(int j=first; j>=0; j--)
                    {
                        if (str[i][j] == '.')
                        {
                            k1 = i;
                            l1 = j + 1;
                            ch = false;
                            break;
                        }
                    }
                    if (!ch)
                        break;
                }
                for(int i=lineL; i<n; i++)
                {
                    bool ch = true;
                    for(int j=last; j<str[i].Length; j++)
                    {
                        if (str[i][j] == '.')
                        {
                            k2 = i;
                            l2 = j + 1;
                            ch = false;
                            break;
                        }
                    }
                    if (!ch)
                        break;
                }
                if (k2 - k1 == 1)
                {
                    for (int i = l1; i < str[k1].Length; i++)
                    {
                        res += str[k1][i];
                    }
                    for (int i = 0; i < l2; i++)
                    {
                        res += str[k2][i];
                    }
                }
                else if (k2 - k1 >1)
                {
                    for (int i = l1; i < str[k1].Length; i++)
                    {
                        res += str[k1][i];
                    }
                    res += str[k1 + (k2 - k1 - 1)];
                    for (int i = 0; i < l2; i++)
                    {
                        res += str[k2][i];
                    }
                }
            }


            return res;
        }
    }
}
