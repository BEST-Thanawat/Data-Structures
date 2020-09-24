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
            priorityQueue.Enqueue("ABC", 9);
            priorityQueue.Enqueue("DEF", 1);
            priorityQueue.Enqueue("GHI", 100);
            priorityQueue.Enqueue("JKL", 235);
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

        private Node Dequeue()
        {
            if (Values.Count == 0)
            {
                return null;
            }

            Node max = Values[0];

            Node last = Values[Values.Count - 1];
            Values.RemoveAt(Values.Count - 1);

            if(Values.Count > 0)
            {
                Values[0] = last;
                SinkDown();
            }

            return max;
        }

        private void SinkDown()
        {
            int index = 0;
            Node nodeToSinkDown = Values[index];

            int leftChildIndex, rightChildIndex;
            Node leftChildNode = null;
            Node rightChildNode = null;
            int swapIndex = index;

            while (true)
            {
                bool swap = false;
                leftChildIndex = (2 * index) + 1;
                rightChildIndex = (2 * index) + 2;

                if(leftChildIndex < Values.Count)
                {
                    leftChildNode = Values[leftChildIndex];
                    if (leftChildNode.Priority > nodeToSinkDown.Priority)
                    {
                        swap = true;
                        swapIndex = leftChildIndex;
                    }
                }
            }
        }
    }
    
}
