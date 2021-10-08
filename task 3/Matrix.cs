using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_3
{
    class Matrix
    {
        private int[,] arr;
        private int size;
        public Matrix()
        {
            size = 3;
            arr = new int[size, size];
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    arr[i, j] = 0;
                }
            }
        }
        public Matrix(int size)
        {
            this.size = size;
            arr = new int[size, size];
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    arr[i, j] = 0;

                }
            }
        }
        public void PrintMatrix()
        {
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    Console.Write(String.Format("{0,4}", arr[i, j]));
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public void FillMatrix()
        {
            int n = 1, i = 0, j = (size - 1) / 2;
            arr[i, j] = n;
            for (n = 2; n <= size * size; n++)
            {
                int k = i;
                int l = j;
                i--;
                j++;
                if (i < 0)
                    i = size - 1;
                if (j >= size)
                    j = 0;
                if (arr[i, j] == 0)
                    arr[i, j] = n;
                else
                {
                    i = k + 1;
                    j = l;
                    arr[i, j] = n;
                }
            }
        }
        public void CheckSquare()
        {
            int MagicConst = size * (size * size + 1) / 2;
            int[] RowSum = new int[size];
            int[] ColSum = new int[size];
            int DiagSum = 0;
            Console.WriteLine($"Magic const = {MagicConst}");
            for (int i = 0; i < size; ++i)
            {
                RowSum[i] = 0;
                ColSum[i] = 0;
                for (int j = 0; j < size; ++j)
                {
                    RowSum[i] += arr[i, j];
                    ColSum[i] += arr[j, i];
                    if (i == j)
                    {
                        DiagSum += arr[i, j];
                    }
                }
                Console.WriteLine($"Sum rows = {RowSum[i]}");
                Console.WriteLine($"Sum collumns = {ColSum[i]}");
            }
        }
    }
}
