using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_9
{
    static class FindStaticClass
    {
        static public FindElement chooseAtribute(int ch)
        {
            switch (ch)
            {
                case 1:
                    return FindStaticClass.FindElementByName;
                case 2:
                    return FindStaticClass.FindElementByPrice;
                case 3:
                    return FindStaticClass.FindElementByWeight;
                case 4:
                    return FindStaticClass.FindElementByTypeOfProduct;
                case 5:
                    return FindStaticClass.FindElementByExpiration;
                case 6:
                    return FindStaticClass.FindElementByMadeDay;
                default:
                    throw new ArgumentException("Wrong choice");
            }
        }
        static public int FindElementByName(string n, Storage Str)
        {
            int pos = Str.Size;
            for (int i = 0; i < Str.Size; i++)
            {
                if (Str[i].Name == n)
                {
                    pos = i;
                    break;
                }
            }
            if (pos < Str.Size)
            {
                return pos;
            }
            else
            {
                return -1;
            }
        }
        static public int FindElementByPrice(string p, Storage Str)
        {
            int pos = Str.Size;
            for (int i = 0; i < Str.Size; i++)
            {
                if (Str[i].Price == Convert.ToDouble(p))
                {
                    pos = i;
                    break;
                }
            }
            if (pos < Str.Size)
            {
                return pos;
            }
            else
            {
                return -1;
            }
        }
        static public int FindElementByWeight(string w, Storage Str)
        {
            int pos = Str.Size;
            for (int i = 0; i < Str.Size; i++)
            {
                if (Str[i].Weight == Convert.ToDouble(w))
                {
                    pos = i;
                    break;
                }
            }
            if (pos < Str.Size)
            {
                return pos;
            }
            else
            {
                return -1;
            }
        }
        static public int FindElementByTypeOfProduct(string top, Storage Str)
        {
            int pos = Str.Size;
            typeOfProduct t;
            if (top.Equals("meat"))
            {
                t = typeOfProduct.meat;
            }
            else if (top.Equals("dairy"))
            {
                t = typeOfProduct.dairy;
            }
            else
            {
                t = typeOfProduct.other;
            }
            for (int i = 0; i < Str.Size; i++)
            {
                if (Str[i].Top == t)
                {
                    pos = i;
                    break;
                }
            }
            if (pos < Str.Size)
            {
                return pos;
            }
            else
            {
                return -1;
            }
        }
        static public int FindElementByExpiration(string ex, Storage Str)
        {
            int pos = Str.Size;
            for (int i = 0; i < Str.Size; i++)
            {
                if (Str[i].Expiration == Convert.ToDouble(ex))
                {
                    pos = i;
                    break;
                }
            }
            if (pos < Str.Size)
            {
                return pos;
            }
            else
            {
                return -1;
            }
        }
        static public int FindElementByMadeDay(string md, Storage Str)
        {
            int pos = Str.Size;
            for (int i = 0; i < Str.Size; i++)
            {
                if (Str[i].MadeDay == md)
                {
                    pos = i;
                    break;
                }
            }
            if (pos < Str.Size)
            {
                return pos;
            }
            else
            {
                return -1;
            }
        }
    }
}
