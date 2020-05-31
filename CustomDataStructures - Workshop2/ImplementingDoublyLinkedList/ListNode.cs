namespace ImplementingDoublyLinkedList
{
    internal class ListNode
    {
        public ListNode(int value, ListNode previous, ListNode next)
        {
            this.Value = value;
            this.Previous = previous;
            this.Next = next;
        }

        public int Value { get; set; }
        public ListNode Previous { get; set; }
        public ListNode Next { get; set; }

        public override string ToString()
        {
            return $"{this.Value}";
        }
    }
}
