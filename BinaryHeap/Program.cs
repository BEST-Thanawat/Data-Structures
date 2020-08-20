using System;
using System.Collections.Generic;
using System.Data;

namespace BinaryHeap
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class BinaryHeap
    {
        public List<int> Values { get; private set; }
        public BinaryHeap()
        {
            Values = new List<int>();
        }

        public bool Insert(int value)
        {
            if (Values.Count == 0)
            {
                Values.Add(value);
                return true;
            }

            Values.Add(value);
            return BubbleUp();
        }

        private bool BubbleUp()
        {
            int elementIndex = Values.Count - 1;
            int element = Values[elementIndex];
            int parentIndex = (elementIndex - 1) / 2;

            while (parentIndex >= 0 && element > Values[parentIndex])
            {
                Values[elementIndex] = Values[parentIndex];
                Values[parentIndex] = element;

                elementIndex = parentIndex;
                parentIndex = (elementIndex - 1) / 2;
            }

            return true;
        }
    }
}
