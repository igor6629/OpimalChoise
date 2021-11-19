using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimalChoice_
{
    class Graph
    {
        private static Graph instance;
        private int n;
        public int[,] A; // матрица весов
        public int[] d; // минимальное расстояние
        private int[] v; // посещенные вершины
        int temp;
        int minindex, min;
        public string result = "";
        public List<List<int>> list = new List<List<int>>();

        public int N
        {
            get { return n; }

            set { n = value; }
        }


        public static Graph getInstance()
        {
            if (instance == null)
                instance = new Graph();
            return instance;
        }

        Graph()
        {

        }

        public void newMatrix()
        {
            A = new int[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (i == j)
                        A[i, j] = 0;
        }

        public void Dijkstra()
        {
            //Инициализация
            d = new int[n];
            v = new int[n];
            list = new List<List<int>>();
            List<int> buf = new List<int>();
            for (int i = 0; i < n; i++)
            {
                buf.Add(0);
                list.Add(buf);
                d[i] = 10000;
                v[i] = 1;
            }
            d[0] = 0;
            // Шаг алгоритма
            Stack<int> stack = new Stack<int>();
            do
            {
                minindex = 10000;
                min = 10000;
                for (int i = 0; i < n; i++)
                {
                    if ((v[i] == 1) && (d[i] < min))
                    {
                        min = d[i];
                        minindex = i;
                    }
                }
                if (minindex != 10000)
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (A[minindex, i] > 0)
                        {
                            temp = min + A[minindex, i];
                            if (temp < d[i])
                            {
                                d[i] = temp;
                            }
                        }
                    }
                    v[minindex] = 0;
                }
            } while (minindex < 10000);

        }

    }
}
