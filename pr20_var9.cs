using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Queue
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
        public Queue()
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
            else
            {
                head = head.Next;
            }
            return ans;
        }
        public int MoveTemp()
        {

        }
        /*public void DeleteMax(int max)
        {
            if 
        }*/
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
