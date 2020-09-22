using System;
using System.Collections.Generic;

namespace Priority_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            PriorityQueue priorityQueue = new PriorityQueue();
            priorityQueue.Values.Add(new PriorityQueue.Node("ABC", 9));
            priorityQueue.Values.Add(new PriorityQueue.Node("DEF", 1));
            priorityQueue.Values.Add(new PriorityQueue.Node("GHI", 100));
            priorityQueue.Values.Add(new PriorityQueue.Node("JKL", 235));
        }
    }

    public class PriorityQueue
    {
        public List<Node> Values { get; set; }
        public PriorityQueue()
        {
            Values = new List<Node>();
        }

        public class Node
        {
            public string Value { get; set; }
            public int Priority { get; set; }

            public Node(string value, int priority)
            {
                Value = value;
                Priority = priority;
            }
        }

        public bool Enqueue(string value, int priority)
        {
            if (Values.Count == 0)
            {
                Values.Add(new Node(value, priority));
                return true;
            }

            Values.Add(new Node(value, priority));

            return BubbleUp();
        }

        private bool BubbleUp()
        {
            int elementIndex = Values.Count - 1;
            Node nodeToBubbleUp = Values[elementIndex];
            int parentIndex = (elementIndex - 1) / 2;

            while (parentIndex >= 0 && nodeToBubbleUp.Priority > Values[parentIndex].Priority)
            {
                Values[elementIndex] = Values[parentIndex];
                Values[parentIndex] = nodeToBubbleUp;

                elementIndex = parentIndex;
                parentIndex = (elementIndex - 1) / 2;
            }

            return true;
        }
    }
    
}
