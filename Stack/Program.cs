using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;

namespace Stack_DT
{
    class Program
    {
        static void Main(string[] args)
        {
            //Stack LIFO
            //Push Peek Pop Clear
            //Generic (Same type)
            //Non-Generic (Different type)

            //Delcare non-generic Stack
            Stack stack = new Stack();

            //Insert 1, 2, 3 into stack
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            //Return top value of stack
            Console.WriteLine("This is top value of stack: " + stack.Peek());
            Console.WriteLine();

            //Remove top value of stack
            stack.Pop();
            Console.WriteLine("Pop the stack");
            Console.WriteLine("This is top value of stack: " + stack.Peek());
            Console.WriteLine();

            Console.WriteLine("Now stack contains " + stack.Count + " elements");
            Console.WriteLine();

            stack.Push("C#");
            stack.Push("C++");
            Console.WriteLine("Add 2 more items into stack");
            Console.WriteLine("This is top value of stack: " + stack.Peek());
            Console.WriteLine();

            Console.WriteLine("Below are items inside stack");
            foreach (var item in stack)
            {
                Console.Write(item + ",");
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Push a Node into stack");
            stack.Push(new Node(100));
            Console.WriteLine("This is top value of stack: " + ((Node)stack.Peek()).Data);

            //Declare generic stack
            Stack<int> genericStackInt = new Stack<int>();
            genericStackInt.Push(1);
            genericStackInt.Push(2);
            genericStackInt.Push(3);
            Console.WriteLine();

            Console.WriteLine("This is generic Stack and must be stored same type value");
            foreach (var item in genericStackInt)
            {
                Console.Write(item + ",");
            }
            Console.WriteLine();
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
