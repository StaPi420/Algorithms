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
        public bool IsEmpty()
        {
            return head == null;
        }
        public void ResetTemp()
        {
            temp = head;
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
            Node prev = head;
            Node curr = head.Next;
            while (curr != null)
            {
                if (curr.Inf == value)
                {
                    prev.Next = curr.Next;
                    if (curr == tail) tail = prev;
                    curr = prev.Next;
                }
                else
                {
                    prev = curr;
                    curr = curr.Next;
                }
            }
            if (temp != null)
            {
                Node p = head;
                bool found = false;
                while (p != null)
                {
                    if (p == temp) { found = true; break; }
                    p = p.Next;
                }
                if (!found) temp = head;
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
            MyQueue queue = new MyQueue();
            using (StreamReader reader = new StreamReader("C:\\Users\\kuram\\.vscode\\input1.txt"))
            {
                using (StreamWriter writer = new StreamWriter("C:\\Users\\kuram\\.vscode\\output.txt"))
                {
                    for (int i = 0; i < 10; ++i)
                    {
                        int num = int.Parse(reader.ReadLine());
                        writer.Write($"{num} ");
                        queue.Push(num);
                    }
                    writer.WriteLine();
                    queue.RemoveAllMax();
                    queue.Print(writer);
                }
            }
            queue = new MyQueue();
            using (StreamReader reader = new StreamReader("C:\\Users\\kuram\\.vscode\\input2.txt"))
            {
                using (StreamWriter writer = new StreamWriter("C:\\Users\\kuram\\.vscode\\output2.txt"))
                {
                    for (int i = 0; i < 100; ++i)
                    {
                        int num = int.Parse(reader.ReadLine());
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
