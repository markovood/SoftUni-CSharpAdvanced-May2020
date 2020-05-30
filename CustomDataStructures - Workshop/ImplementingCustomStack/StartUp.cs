using System;

namespace ImplementingCustomStack
{
    public class StartUp
    {
        public static void Main()
        {
            // testing constructor
            CustomStack stack = new CustomStack();
            Console.WriteLine(stack.Count);

            // testing Push(int element)
            stack.Push(5);
            stack.Push(15);
            stack.Push(25);
            stack.Push(35);
            stack.Push(45);// resizing
            Console.WriteLine(stack);

            // testing Pop()
            int poped45 = stack.Pop();
            int poped35 = stack.Pop();// optimizing capacity
            Console.WriteLine(stack);
            stack.Pop();
            stack.Pop();
            stack.Pop();
            //stack.Pop();// throws InvalidOperationException

            // testing Peek()
            //stack.Peek();// throws InvalidOperationException
            stack.Push(150);
            stack.Push(15);
            stack.Push(1);
            int peeked = stack.Peek();
            Console.WriteLine(peeked);// 1
            Console.WriteLine(stack);// 1 15 150

            // testing ForEach
            stack.ForEach(Console.WriteLine);// 1
                                             // 15
                                             // 150
        }
    }
}
