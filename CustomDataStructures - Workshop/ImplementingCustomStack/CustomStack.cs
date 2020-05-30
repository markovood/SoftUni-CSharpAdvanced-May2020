using System;
using System.Linq;
using System.Text;

namespace ImplementingCustomStack
{
    public class CustomStack
    {
        private const int INITIAL_CAPACITY = 4;

        private int[] internalArray;
        private int capacity;
        private int count;

        public CustomStack()
        {
            this.capacity = INITIAL_CAPACITY;
            this.internalArray = new int[this.capacity];
        }

        public int Count => this.count;

        public void Push(int element)
        {
            EnsureCapacity();
            this.internalArray[this.count] = element;
            this.count++;
        }

        public int Pop()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            int poped = this.internalArray[this.count - 1];
            this.internalArray[this.count - 1] = default;
            this.count--;
            OptimizeCapacity();

            return poped;
        }

        public int Peek()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            return this.internalArray[this.count - 1];
        }

        public void ForEach(Action<int> action)
        {
            for (int i = this.count - 1; i >= 0; i--)
            {
                action(this.internalArray[i]);
            }
        }

        public override string ToString()
        {
            StringBuilder strRepr = new StringBuilder();
            for (int i = this.count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    strRepr.Append(this.internalArray[i].ToString());
                }
                else
                {
                    strRepr.Append(this.internalArray[i] + " ");
                }
            }

            return strRepr.ToString();
        }

        private void EnsureCapacity()
        {
            if (this.count == this.capacity)
            {
                Resize();
            }
        }

        private void OptimizeCapacity()
        {
            if (this.count < this.capacity / 2)
            {
                Shrink();
            }
        }

        private void Resize()
        {
            this.capacity *= 2;
            int[] newArr = new int[this.capacity];
            this.internalArray.CopyTo(newArr, 0);

            this.internalArray = newArr;
        }

        private void Shrink()
        {
            this.capacity /= 2;
            int[] newArr = new int[this.capacity];
            this.internalArray.Take(this.count).ToArray().CopyTo(newArr, 0);

            this.internalArray = newArr;
        }
    }
}
