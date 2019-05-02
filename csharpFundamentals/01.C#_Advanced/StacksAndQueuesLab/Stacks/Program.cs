namespace StacksAndQueue
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var stack = new Stack<int>();

            stack.Push(5);
            stack.Push(2);
            stack.Push(10);


            var queue = new Queue<int>();

            queue.Enqueue(10);
            queue.Enqueue(5);
            queue.Enqueue(2);
            queue.Enqueue(12);
            queue.Enqueue(43);
            queue.Enqueue(3);



        }
    }
}
