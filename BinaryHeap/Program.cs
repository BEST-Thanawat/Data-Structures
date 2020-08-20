using System;
using System.Collections.Generic;
using System.Data;

namespace BinaryHeap
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 
             *           60
             *    40            50
             * 20    10      30
            */

            BinaryHeap bh = new BinaryHeap();
            bh.Insert(50);
            bh.Insert(40);
            bh.Insert(30);
            bh.Insert(20);
            bh.Insert(10);
            bh.Insert(60);
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
            //Get recently added index
            int elementIndex = Values.Count - 1;

            //Get recently added value
            int element = Values[elementIndex];

            //Get recently added parent
            int parentIndex = (elementIndex - 1) / 2;

            //Need to be maintained
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
