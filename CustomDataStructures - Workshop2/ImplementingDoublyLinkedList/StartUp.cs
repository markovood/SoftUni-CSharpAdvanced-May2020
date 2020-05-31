using System;

namespace ImplementingDoublyLinkedList
{
    public class StartUp
    {
        public static void Main()
        {
            // testing constructor 
            DoublyLinkedList list = new DoublyLinkedList();
            Console.WriteLine(list.Count);// 0
            Console.WriteLine(list.Head == null ? "null" : list.Head.Value.ToString());// null
            Console.WriteLine(list.Head == null ? "null" : list.Head.Previous == null ? "null" : list.Head.Previous.Value.ToString());// null
            Console.WriteLine(list.Head == null ? "null" : list.Head.Next == null ? "null" : list.Head.Next.Value.ToString());// null

            // testing AddFirst(int element)
            list.AddFirst(21);
            list.AddFirst(5);
            list.AddFirst(9);
            list.AddFirst(11);// 11 9 5 21

            // testing AddLast(int element)
            DoublyLinkedList otherList = new DoublyLinkedList();
            otherList.AddLast(21);
            otherList.AddLast(5);
            otherList.AddLast(9);
            otherList.AddLast(11);// 21 5 9 11

            // testing RemoveFirst()
            int removed21 = otherList.RemoveFirst();
            int removed5 = otherList.RemoveFirst();
            int removed9 = otherList.RemoveFirst();
            int removed11 = otherList.RemoveFirst();
            //otherList.RemoveFirst();// throws InvalidOperationException

            // testing RemoveLast()
            removed21 = list.RemoveLast();
            removed5 = list.RemoveLast();
            removed9 = list.RemoveLast();
            removed11 = list.RemoveLast();
            //list.RemoveLast();// throws InvalidOperationException

            // testing ForEach(Action<int>)
            DoublyLinkedList anotherList = new DoublyLinkedList();
            anotherList.AddFirst(5);
            anotherList.AddFirst(10);
            anotherList.AddFirst(15);
            anotherList.AddFirst(20);
            anotherList.AddFirst(25);
            anotherList.ForEach(Console.WriteLine);

            // testing ToArray()
            Console.WriteLine(string.Join(' ', anotherList.ToArray()));
        }
    }
}
