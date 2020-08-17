using System;
using System.Collections.Generic;

namespace Linked_List
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declare Linked List
            //Add 1, 2, 3, 4, 5
            LinkedList<int> linkedListInt = new LinkedList<int>();
            linkedListInt.AddLast(1);
            linkedListInt.AddLast(5);
            linkedListInt.AddAfter(linkedListInt.First, 2);
            linkedListInt.AddAfter(linkedListInt.Find(2), 3);
            linkedListInt.AddBefore(linkedListInt.Last, 4);

            //Remove 3
            linkedListInt.Remove(3);

            //Remove first and last
            linkedListInt.RemoveFirst();
            linkedListInt.RemoveLast();

            foreach (var item in linkedListInt)
            {
                Console.Write(item + ",");
            }
            Console.WriteLine();

            if (linkedListInt.Contains(2))
            {
                Console.Write("Element found !!!");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Declare Linked List Object
            LinkedList<Node> linkedListNode = new LinkedList<Node>();
            LinkedListNode<Node> nodeToAdd1 = new LinkedListNode<Node>(new Node(1));
            linkedListNode.AddLast(nodeToAdd1);
            Node node2 = new Node(2);
            linkedListNode.AddLast(node2);
            linkedListNode.Find(node2).Value.Left = new Node(3);
            LinkedListNode<Node> result = linkedListNode.Find(node2);
            Console.WriteLine("Found element " + result.Value.Data + " in LinkedList");
            Console.WriteLine();

            Console.WriteLine("Hello World!");
        }
    }

    public class Node
    {
        public int Data;
        public Node Left;
        public Node Right;
        public Node(int data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }
}
