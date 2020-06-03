using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private const int INITIAL_CAPACITY = 2;

        private T[] innerArr;
        private int count;
        private int capacity;

        public Stack()
        {
            this.capacity = INITIAL_CAPACITY;
            this.innerArr = new T[this.capacity];
        }


        public int Count => this.count;

        public void Push(T element)
        {
            EnsureCapacity();
            this.innerArr[this.count] = element;
            this.count++;
        }

        public T Pop()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            T poped = this.innerArr[this.count - 1];
            this.innerArr[this.count - 1] = default;
            this.count--;
            OptimizeCapacity();

            return poped;
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
            T[] newArr = new T[this.capacity];
            this.innerArr.CopyTo(newArr, 0);

            this.innerArr = newArr;
        }

        private void Shrink()
        {
            this.capacity /= 2;
            T[] newArr = new T[this.capacity];
            this.innerArr.Take(this.count).ToArray().CopyTo(newArr, 0);

            this.innerArr = newArr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.count - 1; i >= 0; i--)
            {
                yield return this.innerArr[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
