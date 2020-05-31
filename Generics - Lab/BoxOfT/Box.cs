using System;

namespace BoxOfT
{
    public class Box<T>
    {
        private T[] innerArray;
        private int capacity;
        private int size;

        public Box()
        {
            this.size = 0;
            this.capacity = 4;
            this.innerArray = new T[this.capacity];
        }

        public int Count { get { return this.size; } }

        public void Add(T element)
        {
            if (this.size == this.capacity)
            {
                Grow();
            }

            this.innerArray[this.size] = element;
            this.size++;
        }

        public T Remove()
        {
            if (this.size == 0)
            {
                throw new ArgumentException("The box is empty!");
            }
            else
            {
                this.size--;
                return this.innerArray[this.size];
            }
        }

        private void Grow()
        {
            this.capacity *= 2;
            T[] newArray = new T[this.capacity];
            this.innerArray.CopyTo(newArray, 0);
            this.innerArray = newArray;
        }
    }
}