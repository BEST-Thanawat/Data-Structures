using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Transactions;

namespace Binary_Search_Tree
{
    class Program
    {
        //Example
        //  10
        // 5  15
        //1
        static void Main(string[] args)
        {
            Node root = new Node(10);
            root.Left = new Node(5);
            root.Right = new Node(15);

            BinarySearchTree bst = new BinarySearchTree();
            bst.Root = root;

            bst.Add(1);

            foreach (var item in bst.DFS_PostOrder())
            {
                Console.WriteLine(item + ",");
            }
        }
    }

    public class Node
    {
        public int Value;
        public Node Left;
        public Node Right;

        public Node(int value)
        {
            Value = value;
            Right = null;
            Left = null;
        }
    }

    public class BinarySearchTree
    {
        public Node Root { get; set; }
        public BinarySearchTree()
        {
            Root = null;
        }
        public bool Add(int value)
        {
            Node newNode = new Node(value);

            if (Root == null)
            {
                Root = newNode;
                return true;
            }

            bool traversing = true;
            Node currentNode = Root;
            while (traversing)
            {
                if (newNode.Value < currentNode.Value)
                {
                    if (currentNode.Left != null)
                    {
                        currentNode = currentNode.Left;
                    }
                    else
                    {
                        currentNode.Left = newNode;
                        traversing = false;
                    }
                }
                else if (newNode.Value > currentNode.Value)
                {
                    if (currentNode.Right != null)
                    {
                        currentNode = currentNode.Right;
                    }
                    else
                    {
                        currentNode.Right = newNode;
                        traversing = false;
                    }
                }
                else
                {
                    traversing = false;
                }
            }

            return true;
        }

        //10 5 15 1
        public List<int> BFS()
        {
            if (Root == null) return null;

            List<int> result = new List<int>();
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                if (queue.Peek().Left != null)
                {
                    queue.Enqueue(queue.Peek().Left);
                }

                if (queue.Peek().Right != null)
                {
                    queue.Enqueue(queue.Peek().Right);
                }
                result.Add(queue.Peek().Value);
                queue.Dequeue();
            }
            return result;
        }

        //1 5 10 15
        public List<int> DFS_InOrder()
        {
            if (Root == null) return null;

            List<int> result = new List<int>();
            Stack<Node> stack = new Stack<Node>();
            Node currentNode = Root;

            while (stack.Count > 0 || currentNode != null)
            {
                if (currentNode != null)
                {
                    stack.Push(currentNode);
                    currentNode = currentNode.Left;
                }
                else
                {
                    currentNode = stack.Pop();
                    result.Add(currentNode.Value);

                    currentNode = currentNode.Right;
                }
            }

            return result;
        }

        //10 5 1 15
        public List<int> DFS_PreOrder()
        {
            if (Root == null) return null;

            List<int> result = new List<int>();
            Stack<Node> stack = new Stack<Node>();
            Node currentNode = null;
            stack.Push(Root);

            while(stack.Count > 0)
            {
                currentNode = stack.Pop(); 
                result.Add(currentNode.Value);

                if (currentNode.Right != null)
                {
                    stack.Push(currentNode.Right);
                }
                if (currentNode.Left != null)
                {
                    stack.Push(currentNode.Left);
                }
            }

            return result;
        }

        //1 5 15 10
        public List<int> DFS_PostOrder()
        {
            if (Root == null) return null;

            Stack<Node> visited = new Stack<Node>();
            Stack<Node> stack = new Stack<Node>();
            visited.Push(Root);

            while (visited.Count > 0)
            {
                Node currentNode = visited.Pop();
                stack.Push(currentNode);

                if(currentNode.Left != null)
                {
                    visited.Push(currentNode.Left);
                }

                if (currentNode.Right != null)
                {
                    visited.Push(currentNode.Right);
                }
            }

            return stack.ToList<Node>().Select(x => x.Value).ToList(); ;
        }
    }
}
