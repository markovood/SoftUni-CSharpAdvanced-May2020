namespace ImplementingDoublyLinkedList
{
    using System;

    // Could be used as a replacement of a call stack or to implement undo and redo functionality.Main
    // difference with other types of lists is that elements are not stored sequentially in the memory but randomly
    public class DoublyLinkedList
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DoublyLinkedList"/> class, that supports integer values only.
        /// </summary>
        public DoublyLinkedList()
        {
            this.Count = 0;
            this.Head = null;
            this.Tail = null;
        }

        /// <summary>
        /// Gets the current count of elements in the collection.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Gets the first node of the collection.
        /// </summary>
        internal ListNode Head { get; private set; }

        /// <summary>
        /// Gets the last node of the collection.
        /// </summary>
        internal ListNode Tail { get; private set; }

        /// <summary>
        /// Adds an element at the beginning of the collection.
        /// </summary>
        /// <param name="element">The integer value to enter.</param>
        public void AddFirst(int element)
        {
            if (this.Count == 0)
            {
                this.Head = new ListNode(element, null, null);
                this.Tail = this.Head;
                this.Count++;
            }
            else if (this.Count == 1)
            {
                var oldHead = this.Head;

                this.Tail = oldHead;
                this.Head = new ListNode(element, null, this.Tail);
                this.Tail.Previous = this.Head;
                this.Count++;
            }
            else
            {
                var innerElement = this.Head;
                this.Head = new ListNode(element, null, innerElement);
                innerElement.Previous = this.Head;
                this.Count++;
            }
        }

        /// <summary>
        /// Adds an element at the end of the collection.
        /// </summary>
        /// <param name="element">The integer value to enter.</param>
        public void AddLast(int element)
        {
            if (this.Count == 0)
            {
                this.AddFirst(element);
            }
            else if (this.Count == 1)
            {
                var oldTail = this.Tail;

                this.Head = oldTail;
                this.Tail = new ListNode(element, oldTail, null);
                this.Head.Next = this.Tail;
                this.Count++;
            }
            else
            {
                var innerElement = this.Tail;
                this.Tail = new ListNode(element, innerElement, null);
                innerElement.Next = this.Tail;
                this.Count++;
            }
        }

        /// <summary>
        /// Removes the element at the beginning of the collection.
        /// </summary>
        /// <returns>The removed element.</returns>
        public int RemoveFirst()
        {
            this.ValidateCount();

            int removed = this.Head.Value;
            if (this.Count == 1)
            {
                this.Head = null;
                this.Tail = null;
                this.Count--;
            }
            else if (this.Count == 2)
            {
                this.Head = this.Tail;
                this.Head.Previous = null;
                this.Count--;
            }
            else
            {
                var newHead = this.Head.Next;
                this.Head = newHead;
                this.Head.Previous = null;
                this.Count--;
            }

            return removed;
        }

        /// <summary>
        /// Removes the element at the end of the collection.
        /// </summary>
        /// <returns>The removed element.</returns>
        public int RemoveLast()
        {
            this.ValidateCount();

            int removed = this.Tail.Value;
            if (this.Count == 1)
            {
                removed = this.RemoveFirst();
            }
            else if (this.Count == 2)
            {
                this.Tail = this.Head;
                this.Tail.Next = null;
                this.Count--;
            }
            else
            {
                var newTail = this.Tail.Previous;
                this.Tail = newTail;
                this.Tail.Next = null;
                this.Count--;
            }

            return removed;
        }

        /// <summary>
        /// Goes through the collection and executes a given action on every element.
        /// </summary>
        /// <param name="action">The action delegate to be performed.</param>
        public void ForEach(Action<int> action)
        {
            var element = this.Head;
            while (element != null)
            {
                action(element.Value);
                element = element.Next;
            }
        }

        /// <summary>
        /// Collection is transformed to an array.
        /// </summary>
        /// <returns>An array containing all element's values.</returns>
        public int[] ToArray()
        {
            int[] listAsArr = new int[this.Count];
            var element = this.Head;
            for (int i = 0; i < this.Count; i++)
            {
                listAsArr[i] = element.Value;
                element = element.Next;
            }

            return listAsArr;
        }

        private void ValidateCount()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List is empty!");
            }
        }
    }
}
