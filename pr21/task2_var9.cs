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
            public int inf, amountOfDescendant;
            public Node left, right;
            public Node(int valueInf)
            {
                amountOfDescendant = 0;
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
        private void Add(int valueInf, ref Node r)
        {
            if (r == null)
            {
                r = new Node(valueInf);
            }
            else
            {
                if (r.inf > valueInf)
                {
                    Add(valueInf, ref r.left);
                }
                else
                {
                    Add(valueInf, ref r.right);
                }
            }
        }
        public void Push(int valueInf)
        {
            if (head == null)
            {
                head = new Node(valueInf);
            }
            else
            {
                Add(valueInf, ref head);
            }
        }
        private int dfs(ref Node r, StreamWriter writer)
        {
            if (r.left != null)
            {
                r.amountOfDescendant += dfs(ref r.left, writer) + 1;
            }
            if (r.right != null)
            {
                r.amountOfDescendant += dfs(ref r.right, writer) + 1;
            }
            writer.WriteLine($"{r.inf} - {r.amountOfDescendant}");
            return r.amountOfDescendant;
        }
        public void writeAmountOfDescendants(StreamWriter writer)
        {
            dfs(ref head, writer);
        }
        public int FindMin()
        {
            Node r = head;
            while (r.left != null)
            {
                r = r.left;
            }
            return r.inf;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            char[] sep = { ' ', ',', '.', '!', '?', '\n', '\t' };
            BinaryTree tree = new BinaryTree();
            using (StreamReader reader = new StreamReader("C:\\Users\\kuramshinrr\\Desktop\\input1.txt"))
            {
                using (StreamWriter writer = new StreamWriter("C:\\Users\\kuramshinrr\\Desktop\\output.txt"))
                {
                    string[] nums = reader.ReadToEnd().Split(sep, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string s in nums)
                    {
                        int num = int.Parse(s);
                        writer.Write($"{num} ");
                        tree.Push(num);
                    }
                    writer.WriteLine();
                    tree.writeAmountOfDescendants(writer);
                }
            }
            tree = new BinaryTree();
            using (StreamReader reader = new StreamReader("C:\\Users\\kuramshinrr\\Desktop\\input2.txt"))
            {
                using (StreamWriter writer = new StreamWriter("C:\\Users\\kuramshinrr\\Desktop\\output2.txt"))
                {
                    string[] nums = reader.ReadToEnd().Split(sep, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string s in nums)
                    {
                        int num = int.Parse(s);
                        writer.Write($"{num} ");
                        tree.Push(num);
                    }
                    writer.WriteLine();
                    tree.writeAmountOfDescendants(writer);
                }
            }
        }
    }
}
