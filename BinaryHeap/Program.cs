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
            BinaryMaxHeap bhMax = new BinaryMaxHeap();
            bhMax.Insert(50);
            bhMax.Insert(40);
            bhMax.Insert(30);
            bhMax.Insert(20);
            bhMax.Insert(10);
            bhMax.Insert(60);
            //Remove 60
            bhMax.ExtractMax();


            BinaryMinHeap bhMin = new BinaryMinHeap();
            bhMin.Insert(50);
            bhMin.Insert(40);
            bhMin.Insert(30);
            bhMin.Insert(20);
            bhMin.Insert(10);
            bhMin.Insert(60);
            //Remove 60
            bhMin.ExtractMin();

            Console.WriteLine("Hello World!");
        }
    }

    public class BinaryMaxHeap
    {
        public List<int> Values { get; private set; }
        public BinaryMaxHeap()
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

    public class BinaryMinHeap
    {
        public List<int> Values { get; private set; }
        public BinaryMinHeap()
        {
            Values = new List<int>();
        }

        public bool Insert(int value)
        {
            if(Values.Count == 0)
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
            while (parentIndex >= 0 && element < Values[parentIndex])
            {
                Values[elementIndex] = Values[parentIndex];
                Values[parentIndex] = element;

                elementIndex = parentIndex;
                parentIndex = (elementIndex - 1) / 2;
            }

            return true;
        }

        public int ExtractMin()
        {
            if (Values.Count == 0) return -1;

            int min = Values[0];
            int last = Values[Values.Count - 1];
            Values.RemoveAt(Values.Count - 1);

            if(Values.Count > 0)
            {
                Values[0] = last;
                SinkDown();
            }

            return min;
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
                    if (leftChildNode < nodeToSinkDown)
                    {
                        swap = true;
                        swapIndex = leftChildIndex;
                    }
                }

                if(rightChildIndex < Values.Count)
                {
                    rightChildNode = Values[rightChildIndex];
                    if ((!swap && rightChildNode < nodeToSinkDown) ||
                        (swap && rightChildNode < leftChildNode))
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
