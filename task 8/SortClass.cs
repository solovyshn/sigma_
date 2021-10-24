using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_8
{
    delegate int OperandDelegate(object x, object y);
    class SortClass {
        object[] arr;
        int size;
        int maxSize;
        public OperandDelegate Comp;
        int Size {
            get => this.size;
            set {
                if (value > 0 && value <= this.MaxSize)
                    this.size = value;
                else
                    throw new ArgumentException("Wrong value");
            }
        }
        int MaxSize {
            get => this.maxSize;
            set {
                if (value > 0)
                    this.maxSize = value;
                else 
                    throw new ArgumentException("Wrong value");
            }
        }
        object this[int index] {
            get {
                if (index >= 0 && index < Size)
                    return arr[index];
                else
                    throw new IndexOutOfRangeException("Index is out of range");
            }
            set {
                if (index >= 0 && index < Size)
                    arr[index] = value;
                else
                    throw new IndexOutOfRangeException("Index is out of range");
            }
        }
        public SortClass(int num, OperandDelegate func) {
            try {
                this.MaxSize = num;
                this.Size = num;
            }
            catch(ArgumentException e) {
                Console.WriteLine(e.Message);
            }
            arr = new object[MaxSize];
            FillArray();
            this.Comp = func;
        }
        public SortClass(string path, OperandDelegate func)
        {
            
            this.Comp = func;
            ReadFileAndFillArray(path);
        }
        public void BubbleSortProducts()
        {
            for(int i=0; i<Size; i++)
            {
                for (int j = 0; j + 1 < Size; j++)
                {
                    if (this.Comp(arr[j], arr[j + 1]) != 0)
                        Product.Swap((Product)arr[j], (Product)arr[j + 1]);
                }
            }
        }
        private void ReadFileAndFillArray(string path)
        {
            if (!File.Exists(path)) {
                throw new FileNotFoundException();
            }
            using (StreamReader sr = File.OpenText(path)) {
                string[] str = new string[100];
                int c = 0;
                for (int i = 0; !sr.EndOfStream; i++) {
                    str[i] = sr.ReadLine();
                    c++;
                }
                try {
                    this.MaxSize = c;
                    this.Size = c;
                }
                catch (ArgumentException e) {
                    Console.WriteLine(e.Message);
                }
                arr = new object[MaxSize];
                for (int i = 0; i < this.Size; i++)
                {
                    try
                    {
                        this.arr[i] = new Product(str[i]);
                    }
                    catch(FormatException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }
        private void Swap(int k, int l) {
            object temp = arr[k];
            arr[k] = arr[l];
            arr[l] = temp;
        }
        private void FillArray() {
            Random temp = new Random();
            for (int i=0; i<Size; i++) {
                arr[i] = temp.Next(-100, 100);
            }
        }
        public override string ToString() {
            string res = "";
            for(int i=0; i<Size; i++) {
                res += arr[i].ToString();
            }
            return res;
        }
    }
}
