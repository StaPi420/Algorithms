using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class MyQueue
    {
        private class Node
        {
            private Node next;
            private int inf;

            public Node(int number)
            {
                inf = number;
            }
            public Node Next
            {
                get { return next; }
                set { next = value; }
            }
            public int Inf
            {
                get { return inf; }
                set { inf = value; }
            }

        }
        private Node head;
        private Node tail;
        private Node temp;
        public MyQueue()
        {
            head = null;
            tail = null;
        }
        public void Push(int inf)
        {
            Node r = new Node(inf);
            if (tail is null)
            {
                head = r;
                tail = r;
            }
            else
            {
                tail.Next = r;
                tail = r;
            }
        }
        public int Pop()
        {
            int ans = head.Inf;
            if (head.Next is null)
            {
                head = null;
                tail = null;
            }
            else if (head.Next != null)
            {
                head = head.Next;
            }
            else
            {
                throw new Exception();
            }
            return ans;
        }
        public int MoveTemp()
        {
            if (temp == null && head != null)
            {
                temp = head;
            }
            else if (temp != null && temp.Next != null)
            {
                temp = temp.Next;
            }
            else
            {
                throw new Exception();
            }
            return temp.Inf;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyQueue queue = new MyQueue();
            MyQueue newQueue = new MyQueue();
            using (StreamReader reader = new StreamReader("C:\\Users\\kuram\\.vscode\\input1.txt"))
            {
                using (StreamWriter writer = new StreamWriter("C:\\Users\\kuram\\.vscode\\output.txt"))
                {
                    int maxElem = 0;
                    for (int i = 0; i < 10; ++i)
                    {
                        int num = int.Parse(reader.ReadLine());
                        writer.Write($"{num} ");
                        maxElem = Math.Max(num, maxElem);
                        queue.Push(num);
                    }
                    writer.WriteLine();
                    for (int i = 0; i < 10; ++i)
                    {
                        int elem = queue.Pop();
                        if (elem != maxElem)
                        {
                            newQueue.Push(elem);
                            writer.Write($"{elem} ");
                        }
                    }
                    writer.WriteLine();
                }
            }
            using (StreamReader reader = new StreamReader("C:\\Users\\kuram\\.vscode\\input2.txt"))
            {
                using (StreamWriter writer = new StreamWriter("C:\\Users\\kuram\\.vscode\\output2.txt"))
                {
                    int maxElem = 0;
                    for (int i = 0; i < 100; ++i)
                    {
                        int num = int.Parse(reader.ReadLine());
                        writer.Write($"{num} ");
                        maxElem = Math.Max(num, maxElem);
                        queue.Push(num);
                    }
                    writer.WriteLine();
                    for (int i = 0; i < 100; ++i)
                    {
                        int elem = queue.Pop();
                        if (elem != maxElem)
                        {
                            newQueue.Push(elem);
                            writer.Write($"{elem} ");
                        }
                    }
                }
            }
        }
    }
}