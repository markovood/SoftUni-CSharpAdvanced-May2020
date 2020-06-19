using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        public static void Main()
        {
            // testing generic DoublyLinkedList<T> 
            DoublyLinkedList<int> listInt = new DoublyLinkedList<int>();
            Console.WriteLine(listInt.Count);// 0
            Console.WriteLine(listInt.Head == null ? "null" : listInt.Head.Value.ToString());// null
            Console.WriteLine(listInt.Head == null ? "null" : listInt.Head.Previous == null ? "null" : listInt.Head.Previous.Value.ToString());// null
            Console.WriteLine(listInt.Head == null ? "null" : listInt.Head.Next == null ? "null" : listInt.Head.Next.Value.ToString());// null

            // testing AddFirst(int element)
            listInt.AddFirst(21);
            listInt.AddFirst(5);// 5 21

            // testing AddLast(int element)
            listInt.AddLast(5);
            listInt.AddLast(21);// 5 21 5 21

            // testing RemoveFirst()
            Console.WriteLine(listInt.RemoveFirst());// 5

            // testing RemoveLast()
            Console.WriteLine(listInt.RemoveLast());// 21

            // testing ForEach(Action<int>)
            listInt.ForEach(Console.WriteLine);

            // testing ToArray()
            Console.WriteLine(string.Join(' ', listInt.ToArray()));// 21 5


            // testing generic DoublyLinkedList<T> 
            DoublyLinkedList<string> listStr = new DoublyLinkedList<string>();
            Console.WriteLine(listStr.Count);// 0
            Console.WriteLine(listStr.Head == null ? "null" : listStr.Head.Value.ToString());// null
            Console.WriteLine(listStr.Head == null ? "null" : listStr.Head.Previous == null ? "null" : listStr.Head.Previous.Value);// null
            Console.WriteLine(listStr.Head == null ? "null" : listStr.Head.Next == null ? "null" : listStr.Head.Next.Value);// null

            // testing AddFirst(int element)
            listStr.AddFirst("Pesho");
            listStr.AddFirst("Gosho");// Gosho Pesho

            // testing AddLast(int element)
            listStr.AddLast("Peter");
            listStr.AddLast("George");// Gosho Pesho Peter George

            // testing RemoveFirst()
            Console.WriteLine(listStr.RemoveFirst());// Gosho

            // testing RemoveLast()
            Console.WriteLine(listStr.RemoveLast());// George

            // testing ForEach(Action<int>)
            listStr.ForEach(Console.WriteLine);

            // testing ToArray()
            Console.WriteLine(string.Join(' ', listStr.ToArray()));// Pesho Peter
        }
    }
}
