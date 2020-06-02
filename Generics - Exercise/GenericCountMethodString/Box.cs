using System;

namespace GenericCountMethodString
{
    public class Box<T>
    {
        private T item;

        public Box(T item)
        {
            this.item = item;
        }

        public T Value => this.item;

        public override string ToString()
        {
            return $"{this.item.GetType().FullName}: {this.Value}";
        }
    }
}
