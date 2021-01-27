using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_14
{
    class MyStack
    {
        public const int StackSize = 10;
        public const int Empty = -1;

        private static string[] arrStack = new string[StackSize];
        private static int intTop = Empty;

        public static void Push(string el)
        {
            if (intTop == StackSize - 1)
            {
                Array.Resize(ref arrStack, arrStack.Length + StackSize);
            }

            intTop++;
            arrStack[intTop] = el;
        }

        public static bool Pop(out string s)
        {
            s = "";

            if (intTop == Empty)
                return false;

            s = arrStack[intTop];
            intTop--;
            return true;
        }

        public static bool Peek(out string s)
        {
            s = "";

            if (intTop == Empty)
                return false;

            s = arrStack[intTop];
            return true;
        }
    }

    class MyQueue
    {
        public const int QueueSize = 10;
        private static string[] arrQueue = new string[QueueSize];

        private static int intTop = 0;
        private static int intCount = 0;

        public static bool Enqueue(string s)
        {
            if (intCount == QueueSize)
                return false;

            var index = (intTop + intCount) % QueueSize;
            arrQueue[index] = s;
            intCount++;

            return true;
        }

        public static bool Dequeue(out string s)
        {
            s = "";

            if (intCount == 0)
                return false;

            s = arrQueue[intTop];
            intCount--;
            intTop++;

            if (intTop == QueueSize)
                intTop = 0;

            return true;
        }

        public static void MakeEmpty()
        {
            intCount = 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyStack.Push("A");
            MyStack.Push("B");
            MyStack.Push("C");

            string s;
            
            MyStack.Pop(out s);
            Console.WriteLine(s);
            
            MyStack.Pop(out s);
            Console.WriteLine(s);
            
            MyStack.Pop(out s);
            Console.WriteLine(s);

            Console.ReadKey();
        }
    }
}
