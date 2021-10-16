<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_5
{
    class Matrix01
    {
        private int[,,] arr;
        private int mSize;
        private int nSize;
        private int pSize;
        public int MSize
        {
            get => this.mSize;
            set
            {
                if (value > 0)
                    this.mSize = value;
                else
                    throw new ArgumentException("Value<0");
            }
        }
        public int NSize
        {
            get => this.nSize;
            set
            {
                if (value > 0)
                    this.nSize = value;
                else
                    throw new ArgumentException("Value<0");
            }
        }
        public int PSize
        {
            get => this.pSize;
            set
            {
                if (value > 0)
                    this.pSize = value;
                else
                    throw new ArgumentException("Value<0");
            }
        }
        public Matrix01(int n = 1, int m = 1, int p = 1)
        {
            NSize = n;
            MSize = m;
            PSize = p;
            arr = new int[NSize, MSize, PSize];
            for (int i = 0; i < NSize; i++)
            {
                for (int j = 0; j < MSize; j++)
                {
                    for (int k = 0; k < PSize; k++)
                    {
                        arr[i, j, k] = 0;
                    }
                }
            }
            FillArr();
        }
        public int[,] FindShadowNxM()
        {
            int[,] shadow = new int[NSize, MSize];
            for (int i = 0; i < NSize; i++)
            {
                for (int j = 0; j < MSize; j++)
                {
                    shadow[i, j] = 0;
                }
            }
            for (int i = 0; i < NSize; i++)
            {
                for (int j = 0; j < MSize; j++)
                {
                    for (int k = 0; k < PSize; k++)
                    {
                        if (arr[i, j, k] == 1)
                        {
                            shadow[i, j] = 1;
                        }
                    }
                }
            }
            return shadow;
        }
        public int[,] FindShadowNxP()
        {
            int[,] shadow = new int[NSize, PSize];
            for (int i = 0; i < NSize; i++)
            {
                for (int j = 0; j < PSize; j++)
                {
                    shadow[i, j] = 0;
                }
            }
            for (int i = 0; i < NSize; i++)
            {
                for (int j = 0; j < MSize; j++)
                {
                    for (int k = 0; k < PSize; k++)
                    {
                        if (arr[i, j, k] == 1)
                        {
                            shadow[i, k] = 1;
                        }
                    }
                }
            }
            return shadow;
        }
        public int[,] FindShadowMxP()
        {
            int[,] shadow = new int[MSize, PSize];
            for (int i = 0; i < MSize; i++)
            {
                for (int j = 0; j < PSize; j++)
                {
                    shadow[i, j] = 0;
                }
            }
            for (int i = 0; i < NSize; i++)
            {
                for (int j = 0; j < MSize; j++)
                {
                    for (int k = 0; k < PSize; k++)
                    {
                        if (arr[i, j, k] == 1)
                        {
                            shadow[j, k] = 1;
                        }
                    }
                }
            }
            return shadow;
        }
        private void FillArr()
        {
            Random rand = new Random();
            for (int i = 0; i < NSize; i++)
            {
                for (int j = 0; j < MSize; j++)
                {
                    for (int k = 0; k < PSize; k++)
                    {
                        arr[i, j, k] = rand.Next() % 2;
                    }
                }
            }
        }
        public string Print()
        {
            string res = "";
            for (int i = 0; i < NSize; i++)
            {
                for (int j = 0; j < MSize; j++)
                {
                    for (int k = 0; k < PSize; k++)
                    {
                        res += arr[i, j, k] + "\t";
                    }
                    res += "\n";
                }
                res += "\n";
            }
            return res;
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_5
{
    class Matrix01
    {
        private int[,,] arr;
        private int mSize;
        private int nSize;
        private int pSize;
        public int MSize
        {
            get => this.mSize;
            set
            {
                if (value > 0)
                    this.mSize = value;
                else
                    throw new ArgumentException("Value<0");
            }
        }
        public int NSize
        {
            get => this.nSize;
            set
            {
                if (value > 0)
                    this.nSize = value;
                else
                    throw new ArgumentException("Value<0");
            }
        }
        public int PSize
        {
            get => this.pSize;
            set
            {
                if (value > 0)
                    this.pSize = value;
                else
                    throw new ArgumentException("Value<0");
            }
        }
        public Matrix01(int n = 1, int m = 1, int p = 1)
        {
            NSize = n;
            MSize = m;
            PSize = p;
            arr = new int[NSize, MSize, PSize];
            for (int i = 0; i < NSize; i++)
            {
                for (int j = 0; j < MSize; j++)
                {
                    for (int k = 0; k < PSize; k++)
                    {
                        arr[i, j, k] = 0;
                    }
                }
            }
            FillArr();
        }
        public int[,] FindShadowNxM()
        {
            int[,] shadow = new int[NSize, MSize];
            for (int i = 0; i < NSize; i++)
            {
                for (int j = 0; j < MSize; j++)
                {
                    shadow[i, j] = 0;
                }
            }
            for (int i = 0; i < NSize; i++)
            {
                for (int j = 0; j < MSize; j++)
                {
                    for (int k = 0; k < PSize; k++)
                    {
                        if (arr[i, j, k] == 1)
                        {
                            shadow[i, j] = 1;
                        }
                    }
                }
            }
            return shadow;
        }
        public int[,] FindShadowNxP()
        {
            int[,] shadow = new int[NSize, PSize];
            for (int i = 0; i < NSize; i++)
            {
                for (int j = 0; j < PSize; j++)
                {
                    shadow[i, j] = 0;
                }
            }
            for (int i = 0; i < NSize; i++)
            {
                for (int j = 0; j < MSize; j++)
                {
                    for (int k = 0; k < PSize; k++)
                    {
                        if (arr[i, j, k] == 1)
                        {
                            shadow[i, k] = 1;
                        }
                    }
                }
            }
            return shadow;
        }
        public int[,] FindShadowMxP()
        {
            int[,] shadow = new int[MSize, PSize];
            for (int i = 0; i < MSize; i++)
            {
                for (int j = 0; j < PSize; j++)
                {
                    shadow[i, j] = 0;
                }
            }
            for (int i = 0; i < NSize; i++)
            {
                for (int j = 0; j < MSize; j++)
                {
                    for (int k = 0; k < PSize; k++)
                    {
                        if (arr[i, j, k] == 1)
                        {
                            shadow[j, k] = 1;
                        }
                    }
                }
            }
            return shadow;
        }
        private void FillArr()
        {
            Random rand = new Random();
            for (int i = 0; i < NSize; i++)
            {
                for (int j = 0; j < MSize; j++)
                {
                    for (int k = 0; k < PSize; k++)
                    {
                        arr[i, j, k] = rand.Next() % 2;
                    }
                }
            }
        }
        public string Print()
        {
            string res = "";
            for (int i = 0; i < NSize; i++)
            {
                for (int j = 0; j < MSize; j++)
                {
                    for (int k = 0; k < PSize; k++)
                    {
                        res += arr[i, j, k] + "\t";
                    }
                    res += "\n";
                }
                res += "\n";
            }
            return res;
        }
    }
}
>>>>>>> 170b157a028889369263d0dff7a386e8b43528cd
