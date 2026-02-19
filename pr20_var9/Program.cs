using System;
using System.Collections.Generic;
using System.IO;
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
        public int DeleteIfEqual(int x)
        {
            if (temp == null && head != null)
            {
                temp = head;
                if (head.Inf == x)
                {
                    temp = head.Next;
                    head = temp;
                }
            }
            else if (temp.Next == tail)
            {
                if (tail.Inf == x)
                {
                    tail = temp;
                }
                else
                {
                    temp = tail;
                }
            }
            else if (temp != null && temp.Next != null)
            {
                if (temp.Next.Inf == x)
                {
                    temp.Next = temp.Next.Next;
                    temp = temp.Next;
                }
                else
                    temp = temp.Next;
            }
            else
            {
                throw new Exception();
            }
            return temp.Inf;
        }
        public bool tempIsNotNull()
        {
            return !(temp.Next is null);
        }
        public bool IsEmpty()
        {
            return head is null;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            char[] sep = { ' ', '.', ',', '!', '\n', '\t', '?', ';', ':' };
            MyQueue queue = new MyQueue();
            MyQueue newQueue = new MyQueue();
            using (StreamReader reader = new StreamReader("C:\\Users\\kuramshinrr\\Desktop\\input1.txt"))
            {
                using (StreamWriter writer = new StreamWriter("C:\\Users\\kuramshinrr\\Desktop\\output1.txt"))
                {
                    int maxElem = 0;
                    string[] input = reader.ReadToEnd().Split(sep, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string s in input)
                    {
                        int num = int.Parse(s);
                        writer.Write($"{num} ");
                        maxElem = Math.Max(num, maxElem);
                        queue.Push(num);
                    }
                    writer.WriteLine();
                    int a = queue.DeleteIfEqual(maxElem);
                    writer.Write(a + " ");
                    while (queue.tempIsNotNull())
                    {
                        a = queue.DeleteIfEqual(maxElem);
                        writer.Write(a + " ");
                    }

                    writer.WriteLine();
                }
            }
            MyQueue queue2 = new MyQueue();
            MyQueue newQueue2 = new MyQueue();
            using (StreamReader reader = new StreamReader("C:\\Users\\kuramshinrr\\Desktop\\input2.txt"))
            {
                using (StreamWriter writer = new StreamWriter("C:\\Users\\kuramshinrr\\Desktop\\output2.txt"))
                {
                    int maxElem = 0;
                    string[] input = reader.ReadToEnd().Split(sep, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string s in input)
                    {
                        int num = int.Parse(s);
                        writer.Write($"{num} ");
                        maxElem = Math.Max(num, maxElem);
                        queue2.Push(num);
                    }
                    writer.WriteLine();
                    int a = queue2.DeleteIfEqual(maxElem);
                    writer.Write(a + " ");
                    while (queue2.tempIsNotNull())
                    {
                        a = queue2.DeleteIfEqual(maxElem);
                        writer.Write(a + " ");
                    }
                }
            }
        }
    }
}
