using System;
using System.Collections.Generic;
using System.IO;

namespace Example
{
    public class Graph
    {
        private class Node
        {
            private int[,] array;
            private int[,] coords;
            public string[] cities;

            public int this[int i, int j]
            {
                get { return array[i, j]; }
                set { array[i, j] = value; }
            }
            public Node(int[,] a, int[,] cords, string[] cities)
            {
                array = a;
                coords = cords;
                this.cities = cities;
                nov = new bool[a.GetLength(0)];
            }

            public int Size
            {
                get { return array.GetLength(0); }
            }

            private bool[] nov;

            public double GetDistance(int v, int u)
            {
                return Math.Sqrt((coords[v, 0] - coords[u, 0]) * (coords[v, 0] - coords[u, 0]) + (coords[v, 1] - coords[u, 1]) * (coords[v, 1] - coords[u, 1]));
            }

            public void NovSet()
            {
                for (int i = 0; i < Size; i++)
                {
                    nov[i] = true;
                }
            }

            // Обход в глубину (DFS)
            public void Dfs(int v)
            {
                Console.Write("{0} ", v);
                nov[v] = false;

                for (int u = 0; u < Size; u++)
                {
                    if (array[v, u] != 0 && nov[u])
                    {
                        Dfs(u);
                    }
                }
            }

            // Обход в ширину (BFS)
            public void Bfs(int v)
            {
                Queue<int> q = new Queue<int>();
                q.Enqueue(v);
                nov[v] = false;

                while (q.Count > 0)
                {
                    v = q.Dequeue();
                    Console.Write("{0} ", v);

                    for (int u = 0; u < Size; u++)
                    {
                        if (array[v, u] != 0 && nov[u])
                        {
                            q.Enqueue(u);
                            nov[u] = false;
                        }
                    }
                }
            }

            // Алгоритм Дейкстры
            public long[] Dijkstra(int v, out int[] p)
            {
                nov[v] = false;

                // Матрица весов c
                long[,] c = new long[Size, Size];
                for (int i = 0; i < Size; i++)
                {
                    for (int u = 0; u < Size; u++)
                    {
                        if (array[i, u] == 0 || i == u)
                        {
                            c[i, u] = long.MaxValue;
                        }
                        else
                        {
                            c[i, u] = array[i, u];
                        }
                    }
                }

                long[] d = new long[Size];
                p = new int[Size];

                for (int u = 0; u < Size; u++)
                {
                    if (u != v)
                    {
                        d[u] = c[v, u];
                        p[u] = v;
                    }
                }
                d[v] = 0;

                for (int i = 0; i < Size - 1; i++)
                {
                    long min = long.MaxValue;
                    int w = -1;

                    for (int u = 0; u < Size; u++)
                    {
                        if (nov[u] && min > d[u])
                        {
                            min = d[u];
                            w = u;
                        }
                    }

                    if (w == -1) break;

                    nov[w] = false;

                    for (int u = 0; u < Size; u++)
                    {
                        if (c[w, u] == long.MaxValue) continue;
                        long distance = d[w] + c[w, u];
                        if (nov[u] && d[u] > distance)
                        {
                            d[u] = distance;
                            p[u] = w;
                        }
                    }
                }

                return d;
            }

            // Восстановление пути для Дейкстры
            public void WayDijkstra(int a, int b, int[] p, ref Stack<int> items)
            {
                items.Push(b);
                if (a == p[b])
                {
                    items.Push(a);
                }
                else
                {
                    WayDijkstra(a, p[b], p, ref items);
                }
            }


            public double[] DijkstraWithoutVertex(int start, int forbidden, out int[] p)
            {
                if (start == forbidden)
                    throw new ArgumentException("Стартовая вершина не может быть запрещенной");


                double[] d = new double[Size];
                p = new int[Size];
                bool[] visited = new bool[Size];

                for (int i = 0; i < Size; i++)
                {
                    d[i] = long.MaxValue;
                    p[i] = -1;
                    visited[i] = false;
                }

                d[start] = 0;

                for (int i = 0; i < Size; i++)
                {
                    double min = double.MaxValue;
                    int v = -1;

                    for (int j = 0; j < Size; j++)
                    {
                        if (!visited[j] &&
                            j != forbidden &&
                            d[j] < min)
                        {
                            min = d[j];
                            v = j;
                        }
                    }

                    if (v == -1)
                        break;

                    visited[v] = true;

                    for (int u = 0; u < Size; u++)
                    {
                        if (u == forbidden)
                            continue;

                        if (GetDistance(v, u) != double.MaxValue && array[v, u] != 0)
                        {
                            double distance = d[v] + GetDistance(v, u);

                            if (distance < d[u])
                            {
                                d[u] = distance;
                                p[u] = v;
                            }
                        }
                    }
                }

                return d;
            }
        }

        private Node graph;

        public Graph(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Имя файла не может быть пустым");

            using (StreamReader file = new StreamReader(name))
            {
                string firstLine = file.ReadLine();
                if (firstLine == null)
                    throw new InvalidDataException("Файл пуст");

                int n = int.Parse(firstLine);
                int[,] a = new int[n, n];
                int[,] cords = new int[n, 2];
                string[] cities = new string[n];

                for (int i = 0; i < n; ++i)
                {
                    string line = file.ReadLine();
                    string[] mas = line.Split(new[] { ' ', ',', '.', ';' }, StringSplitOptions.RemoveEmptyEntries);
                    cities[i] = mas[0];
                    cords[i, 0] = int.Parse(mas[1]);
                    cords[i, 1] = int.Parse(mas[2]);

                }

                for (int i = 0; i < n; i++)
                {
                    string line = file.ReadLine();
                    if (line == null)
                        throw new InvalidDataException("Недостаточно строк в файле");


                    string[] mas = line.Split(new[] { ' ', ',', '.', ';' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < n; j++)
                    {
                        a[i, j] = int.Parse(mas[j]);
                    }
                }
                graph = new Node(a, cords, cities);
            }
        }
        

        public void DijkstraWithoutVertex(int start, int end, int forbidden)
        {
            if (start < 0 || start >= graph.Size)
                throw new ArgumentOutOfRangeException(nameof(start));

            if (end < 0 || end >= graph.Size)
                throw new ArgumentOutOfRangeException(nameof(end));

            if (forbidden < 0 || forbidden >= graph.Size)
                throw new ArgumentOutOfRangeException(nameof(forbidden));

            int[] p;

            double[] d = graph.DijkstraWithoutVertex(
                start,
                forbidden,
                out p
            );

            if (d[end] == double.MaxValue)
            {
                Console.WriteLine(
                    "Путь из {0} в {1}, не проходящий через {2}, не существует",
                    graph.cities[start],
                    graph.cities[end],
                    graph.cities[forbidden]
                );

                return;
            }

            Console.WriteLine(
                "Кратчайший путь из {0} в {1}, не проходящий через {2}:",
                    graph.cities[start],
                    graph.cities[end],
                    graph.cities[forbidden]
            );


            Stack<int> items = new Stack<int>();

            graph.WayDijkstra(start, end, p, ref items);

            while (items.Count > 0)
            {
                Console.Write("{0} ", graph.cities[items.Pop()]);
            }

            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph("C:\\Users\\contest\\source\\repos\\ConsoleApp6\\graph.txt");
            graph.DijkstraWithoutVertex(0, 3, 1);

        }
    }
}
