using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    public class BinaryTree
    {
        private class Node
        {
            public int inf;
            public Node left, right;
            public Node(int valueInf)
            {
                inf = valueInf;
                left = null;
                right = null;
            }
        }
        private Node head;
        public BinaryTree()
        {
            head = null;
        }
        public void Add(int valueInf)
        {
            if (head == null)
            {
                Node r = new Node(valueInf);
                head = r;
                return;
            }

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
