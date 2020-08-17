using System;

namespace Array
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declare Array
            int[] arrayInt = new int[] {1, 2, 3, 4, 5 };

            //Declare Array Double
            double[] arrayDouble = new double[2] { 1000.11, 2000.22 }; 

            //Declare Array String
            string[] arrayString = new string[2];
            arrayString[0] = "item1";
            arrayString[1] = "item2";

            //Declare Array Float
            float[] arrayFloat;
            arrayFloat = new float[] { 0.1f, 0.25f, 0.5f, 0.75f, 1f };

            //Declare Array Char
            char[] arrayChar = new char[] { 'a', 'b', 'c'};
            char[] getArrayChar = arrayChar;

            //Declare Array Object
            Node[] arrayNode = new Node[3];
            arrayNode[0] = new Node(1);
            arrayNode[1] = new Node(2);
            arrayNode[2] = new Node(3);
            arrayNode[0].Left = arrayNode[1];
            arrayNode[0].Right = arrayNode[2];

            //Declare Jagged Array Int
            int[][] jaggedArrayInt = new int[2][]
            {
                new int[] { 1, 2 },
                new int[] { 1, 2, 3, 4 }
            };

            //Declare Jagged Array String
            string[][] jaggedArrayString = new string[][]
            {
                new string[] { "cat", "rat" },
                new string[] { "cat", "rat", "bat" },
                new string[] { "cat", "rat", "bat", "fat" }
            };


            //Display item in array
            for (int i = 0; i < arrayChar.Length; i++)
            {
                Console.Write(arrayChar[i] + ",");
            }
            Console.WriteLine();
            Console.WriteLine();

            foreach (var item in jaggedArrayString)
            {
                foreach (var item2 in item)
                {
                    Console.Write(item2 + ",");
                }
                Console.WriteLine();
            }
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
        }
    }
}
