using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http.Headers;

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

            //Remove 60
            bh.ExtractMax();

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

        public int ExtractMax()
        {
            if (Values.Count == 0) return -1;

            int max = Values[0];
            int last = Values[Values.Count - 1];
            Values.RemoveAt(Values.Count -1);

            if (Values.Count > 0)
            {
                Values[0] = last;
                SinkDown();
            }

            return max;
        }

        private void SinkDown()
        {
            int index = 0;
            int nodeToSinkDown = Values[index];

            int leftChildIndex, rightChildIndex;
            int leftChildNode = 0, rightChildNode = 0;
            int swapIndex = index;

            while (true)
            {
                bool swap = false;
                leftChildIndex = (2 * index) + 1;
                rightChildIndex = (2 * index) + 2;

                if(leftChildIndex < Values.Count)
                {
                    leftChildNode = Values[leftChildIndex];
                    if(leftChildNode > nodeToSinkDown)
                    {
                        swap = true;
                        swapIndex = leftChildIndex;
                    }
                }

                if(rightChildIndex < Values.Count)
                {
                    rightChildNode = Values[rightChildIndex];
                    if((!swap && rightChildNode > nodeToSinkDown) ||
                        (swap && rightChildNode > leftChildNode))
                    {
                        swap = true;
                        swapIndex = rightChildIndex;
                    }
                }

                if (!swap) return;

                Values[index] = Values[swapIndex];
                Values[swapIndex] = nodeToSinkDown;
                index = swapIndex;
            }
        }
    }
}
