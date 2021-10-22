using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_6
{
    class Polinom
    {
        private double[] coefs;
        private int m;
        public int M
        {
            get => this.m;
            set
            {
                if (value > 0)
                    this.m = value;
                else
                    throw new ArgumentException("Value < 0");
            }
        }
        public double this[int index]
        {
            get { return coefs[index]; }
            set
            {
                if (index >= 0 && index < m)
                    coefs[index] = value;
                else
                {
                    throw new IndexOutOfRangeException("Index is out of range");
                }
            }
        }
        public Polinom(int num = 1)
        {
            M = num;
            coefs = new double[M];
            for (int i = 0; i < M; i++)
            {
                coefs[i] = 0;
            }
        }
        public Polinom(params double[] arr) {
            M = arr.Length;
            this.coefs = new double[M];
            for(int i=0; i<M; i++)
            {
                coefs[i] = arr[i];
            }
        }
        public static Polinom operator +(Polinom P1) => P1;
        public static Polinom operator -(Polinom P1) {
            for(int i=0; i<P1.M; i++) {
                P1[i] *= (-1);
            }
            return P1;
        }
        public static Polinom operator +(Polinom P1, Polinom P2) {
            Polinom res = new Polinom(P1.M > P2.M ? P1.M : P2.M);
            if (P1.M > P2.M) {
                int i = 0;
                for (; i < P2.M; i++) {
                    res[i] = P1[i] + P2[i];
                }
                for (; i < P1.M; i++) {
                    res[i] = P1[i];
                }
            }
            else {
                int i = 0;
                for (; i < P1.M; i++) {
                    res[i] = P1[i] + P2[i];
                }
                for (; i < P2.M; i++) {
                    res[i] = P2[i];
                }
            }
            return res;
        }
        public static Polinom operator -(Polinom P1, Polinom P2) {
            Polinom res = new Polinom(P1.M > P2.M ? P1.M : P2.M);
            if (P1.M > P2.M) {
                int i = 0;
                for (; i < P2.M; i++) {
                    res[i] = P1[i] - P2[i];
                }
                for (; i < P1.M; i++) {
                    res[i] = P1[i];
                }
            }
            else {
                int i = 0;
                for (; i < P1.M; i++) {
                    res[i] = P1[i] - P2[i];
                }
                for (; i < P2.M; i++) {
                    res[i] = (-1) * P2[i];
                }
            }
            return res;
        }
        public static Polinom operator *(Polinom P1, double x) {
            for(int i=0; i<P1.M; i++) {
                P1[i] *= x;
            }
            return P1;
        }
        public static Polinom operator *(Polinom P1, Polinom P2) {
            Polinom res = new Polinom(P1.M + P2.M);
            for (int i = 0; i < P1.M; i++) {
                for (int j = 0; j < P2.M; j++) {
                    res[i + j] += P1[i] * P2[j];
                }
            }
            return res;
        }
        public static implicit operator Polinom(double a)
        {
            return new Polinom(a);
        }
        public void Parse(string s)
        {
            string[] str = s.Split('+');
            coefs = new double[str.Length];
            M = str.Length;
            coefs[0] = System.Convert.ToDouble(str[0]);
            for (int i = 1; i < str.Length; i++)
            {
                string[] c = str[i].Split('x');
                coefs[i] = System.Convert.ToDouble(c[0]);
            }
        }
        public string GetPolynom() {
            string s = "";
            for (int i = 0; i < M; i++) {
                s += coefs[i];
                if (i == 0 && M != 1&&coefs[i+1]>=0) {
                    s += "+";
                }
                else if (i == 1 && M != 2) {
                    s += "x";
                    if (coefs[i + 1] >= 0)
                    {
                        s += "+";
                    }
                }
                else if (i == 1 && M == 2) {
                    s += "x";
                }
                else if (i != M - 1) {
                    s += String.Format("x^{0}", i);
                    if (coefs[i + 1] >= 0)
                        s += "+";
                }
                else if (i == M - 1) {
                    s += String.Format("x^{0}", i);
                }
            }
            return s;
        }
    }
}
