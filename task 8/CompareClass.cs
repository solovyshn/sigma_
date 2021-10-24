using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_8
{
    static class CompareClass
    {
        static public int CompareByWeight(Object x, Object y) {
            Product xCopy = (Product)x;
            Product yCopy = (Product)y;
            if (xCopy.Weight.CompareTo(yCopy.Weight) > 0) 
                return 0; 
            else
                return 1;
        }
        static public int CompareByName(object x, object y) {
            Product xCopy = (Product)x;
            Product yCopy = (Product)y;
            /*if (string.Compare(xCopy.Name, yCopy.Name) != 0)
                return 0;
            else
                return 1;*/
            if (xCopy.Name.CompareTo(yCopy.Name) < 0)
                return 0;
            else
                return 1;
        }
        static public int CompareByPrice(object x, object y) {
            Product xCopy = (Product)x;
            Product yCopy = (Product)y;
            if (xCopy.Price.CompareTo(yCopy.Price) > 0)
                return 0;
            else
                return 1;
        }
    }
}
