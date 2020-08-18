using System;
using System.Collections;
using System.Collections.Generic;

namespace Queue_DT
{
    class Program
    {
        static void Main(string[] args)
        {
            //Queue FIFO
            //Enqueue Dequeue Peek Clear
            //Generic (Same type)
            //Non-Generic (Different type)

            //Declare Non-Generic Queue
            Queue queueNonGeneric = new Queue();
            queueNonGeneric.Enqueue(1);
            queueNonGeneric.Enqueue("2");
            queueNonGeneric.Enqueue(3.0f);
            Console.WriteLine("This is non-generic Queue");

            Console.Write("Contains ");
            foreach (var item in queueNonGeneric)
            {
                Console.Write(item + ",");
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Dequeue 1 time");
            queueNonGeneric.Dequeue();
            Console.Write("Right now the queue contains ");
            foreach (var item in queueNonGeneric)
            {
                Console.Write(item + ",");
            }
            Console.WriteLine();
            Console.WriteLine("The first item in the queue is " + queueNonGeneric.Peek());

            Console.WriteLine();
            Console.WriteLine("Declare a generic Queue by Enqueue 3 characters");
            Queue<char> queueGeneric = new Queue<char>();
            queueGeneric.Enqueue('a');
            queueGeneric.Enqueue('b');
            queueGeneric.Enqueue('c');
            Console.Write("Right now the generic queue contains ");
            foreach (var item in queueGeneric)
            {
                Console.Write(item + ",");
            }

            Console.WriteLine();
            Console.WriteLine("Hello World!");
        }
    }
}
