using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_6
{
    class Matrix
    {
        int[,] matr;
        int nSize;
        int mSize;
        public int NSize
        {
            get => nSize;
            set
            {
                if (value > 0)
                {
                    nSize = value;
                }
                else
                    throw new ArgumentException("Value<0");
            }
        }
        public int MSize
        {
            get => mSize;
            set
            {
                if (value > 0)
                    mSize = value;
                else
                    throw new ArgumentException("Value<0");
            }
        }
        public Matrix(int n=1, int m = 1)
        {
            try
            {
                NSize = n;
                MSize = m;
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            matr = new int[NSize, MSize];
            for(int i=0; i<this.NSize; i++)
            {
                for(int j=0; j<this.MSize; j++)
                {
                    matr[i,j] = 0;
                }
            }
        }
        public void Print()
        {
            foreach(int i in matr)
            {

            }
        }
        public IEnumerator GetEnumerator()
        {
            return new Enumerator(matr);
        }
        public class Enumerator : IEnumerable<Matrix>
        {
            private Matrix[,] values;
            private int nS = -1;
            private int mS = -1;
            public Enumerator(Matrix[,] products)
            {
                this.values = products;
            }
            public Matrix Current => values[nS, mS];
            /*int IEnumerator Current => values[nS, mS];*/
            public IEnumerator<Matrix> GetEnumerator()
            {
                for(int i=0; i<nS; i++)
                {
                    for(int j=mS-1; j>=0; j--)
                    {
                        yield return values[i, j];
                    }
                }
            }
            public void Dispose()
            {

            }
           /* IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }*/
        }
    }
}
