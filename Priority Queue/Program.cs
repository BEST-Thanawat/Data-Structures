using System;
using System.Collections.Generic;

namespace Priority_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
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

    }
    
}
