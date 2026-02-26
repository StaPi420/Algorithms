using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
        public bool IsEmpty()
        {
            return head == null;
        }
        public void Print(TextWriter writer)
        {
            Node p = head;
            while (p != null)
            {
                writer.Write(p.Inf + " ");
                p = p.Next;
            }
            writer.WriteLine();
        }
        public int FindMax()
        {
            if (head == null) throw new InvalidOperationException("List is empty");
            int mx = head.Inf;
            Node p = head.Next;
            while (p != null)
            {
                if (p.Inf > mx) mx = p.Inf;
                p = p.Next;
            }
            return mx;
        }
        public void RemoveAll(int value)
        {
            while (head != null && head.Inf == value)
            {
                head = head.Next;
            }
            if (head == null)
            {
                tail = null;
                temp = null;
                return;
            }
            temp = head;
            while (temp != null)
            {
                if (temp.Next != null && temp.Next.Inf == value)
                {
                    temp.Next = temp.Next.Next;
                }
                else
                {
                    temp = temp.Next;
                }
            }
        }
        public void RemoveAllMax()
        {
            if (head == null) return;
            int mx = FindMax();
            RemoveAll(mx);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            char[] sep = { ' ', ',', '.', '!', '?', '\n', '\t' };
            MyQueue queue = new MyQueue();
            using (StreamReader reader = new StreamReader("C:\\Users\\kuramshinrr\\Desktop\\input1.txt"))
            {
                using (StreamWriter writer = new StreamWriter("C:\\Users\\kuramshinrr\\Desktop\\output.txt"))
                {
                    string[] nums = reader.ReadToEnd().Split(sep, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string s in nums)
                    {
                        int num = int.Parse(s);
                        writer.Write($"{num} ");
                        queue.Push(num);
                    }
                    writer.WriteLine();
                    queue.RemoveAllMax();
                    queue.Print(writer);
                }
            }
            queue = new MyQueue();
            using (StreamReader reader = new StreamReader("C:\\Users\\kuramshinrr\\Desktop\\input2.txt"))
            {
                using (StreamWriter writer = new StreamWriter("C:\\Users\\kuramshinrr\\Desktop\\output2.txt"))
                {
                    string[] nums = reader.ReadToEnd().Split(sep, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string s in nums)
                    {
                        int num = int.Parse(s);
                        writer.Write($"{num} ");
                        queue.Push(num);
                    }
                    writer.WriteLine();
                    queue.RemoveAllMax();
                    queue.Print(writer);
                }
            }
        }
    }
}
