namespace CustomLinkedList
{
    internal class ListNode<T>
    {
        public ListNode(T value, ListNode<T> previous, ListNode<T> next)
        {
            this.Value = value;
            this.Previous = previous;
            this.Next = next;
        }

        public T Value { get; set; }
        public ListNode<T> Previous { get; set; }
        public ListNode<T> Next { get; set; }

        public override string ToString()
        {
            return $"{this.Value}";
        }
    }
}
