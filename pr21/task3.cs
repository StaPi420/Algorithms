using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class AVLTree
{
    public class Node
    {
        public int Key;
        public Node Left, Right;
        public int height;

        public Node(int key)
        {
            Key = key;
            height = 1;
        }

        public int Height{
            get
            { 
                return height;
            }
            set
            {
                height = value;
            }
    
        }
        public int BalanceFactor
        {
            get
            {
                return (this != null) ? 
                this.getLeftHeight() - this.getRightHeight() : 
                0;
            }
        }
        public int getRightHeight()
        {
            return (this.Right != null) ? this.Right.Height : 0;
        }
        public int getLeftHeight()
        {
            return (this.Left != null) ? this.Left.Height : 0;
        }
    }

    public Node Root;

    void UpdateHeight(Node n)
    {
        n.Height = Math.Max(n.getLeftHeight(), n.getRightHeight()) + 1;
    }

    Node RotateRight(Node y)
    {
        Node x = y.Left;
        Node T2 = x.Right;

        x.Right = y;
        y.Left = T2;

        UpdateHeight(y);
        UpdateHeight(x);

        return x;
    }

    Node RotateLeft(Node x)
    {
        Node y = x.Right;
        Node T2 = y.Left;

        y.Left = x;
        x.Right = T2;

        UpdateHeight(x);
        UpdateHeight(y);

        return y;
    }

    Node Balance(Node node)
    {
        UpdateHeight(node);
        int bf = node.BalanceFactor;

        if (bf > 1)
        {
            if (node.Left != null && node.Left.BalanceFactor < 0)
                node.Left = RotateLeft(node.Left);
            return RotateRight(node);
        }
        if (bf < -1)
        {
            if (node.Right != null && node.Right.BalanceFactor > 0)
                node.Right = RotateRight(node.Right);
            return RotateLeft(node);
        }

        return node;
    }

    public Node Insert(Node node, int key)
    {
        // Console.WriteLine("Вставляем: " + key);
        if (node == null) return new Node(key);

        if (key < node.Key)
            node.Left = Insert(node.Left, key);
        else if (key > node.Key)
            node.Right = Insert(node.Right, key);
        else
            return node;

        return Balance(node);
    }

    Node GetMin(Node node)
    {
        while (node.Left != null)
            node = node.Left;
        return node;
    }

    public Node Remove(Node node, int key)
    {
        if (node == null) return null;

        if (key < node.Key)
            node.Left = Remove(node.Left, key);
        else if (key > node.Key)
            node.Right = Remove(node.Right, key);
        else
        {
            if (node.Left == null || node.Right == null)
            {
                node = node.Left ?? node.Right;
            }
            else
            {
                Node min = GetMin(node.Right);
                node.Key = min.Key;
                node.Right = Remove(node.Right, min.Key);
            }

            if (node == null) return null;

            return Balance(node);
        }

        return Balance(node);
    }

    public bool IsPerfectlyBalanced(Node node)
    {
        if (node == null) return true;

        int diff = Math.Abs(node.getLeftHeight() - node.getRightHeight());
        if (diff > 0) return false;

        return IsPerfectlyBalanced(node.Left) &&
               IsPerfectlyBalanced(node.Right);
    }

    public Node Clone(Node node)
    {
        if (node == null) return null;

        Node newNode = new Node(node.Key);
        newNode.Left = Clone(node.Left);
        newNode.Right = Clone(node.Right);
        newNode.Height = node.Height;
        return newNode;
    }

    public void Collect(Node node, List<int> list)
    {
        if (node == null) return;
        list.Add(node.Key);
        Collect(node.Left, list);
        Collect(node.Right, list);
    }
}

class Program
{
    static void Main()
    {
        var numbers = File.ReadAllText("C:\\Users\\kuram\\.vscode\\csproj\\ConsoleApp2\\input.txt")
                          .Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                          .Select(int.Parse)
                          .ToList();

        AVLTree tree = new AVLTree();

        foreach (var num in numbers)
            tree.Root = tree.Insert(tree.Root, num);

        List<int> nodes = new List<int>();
        tree.Collect(tree.Root, nodes);

        foreach (var value in nodes)
        {
            AVLTree tempTree = new AVLTree();
            tempTree.Root = tree.Clone(tree.Root);

            tempTree.Root = tempTree.Remove(tempTree.Root, value);

            if (tempTree.IsPerfectlyBalanced(tempTree.Root))
            {
                Console.WriteLine("Можно удалить узел: " + value);
                return;
            }
        }

        Console.WriteLine("Нет такого узла");
    }
}
