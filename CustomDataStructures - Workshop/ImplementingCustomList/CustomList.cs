using System;
using System.Linq;

namespace ImplementingCustomList
{
    public class CustomList
    {
        private const int INITIAL_CAPACITY = 2;

        private int capacity;
        private int[] internalArr;
        private int count;

        /// <summary>
        /// Creates new instance of CustomList with default initial capacity = 2 and dynamically resizable capacity, capable to store int values only.
        /// </summary>
        public CustomList()
        {
            this.capacity = INITIAL_CAPACITY;
            this.internalArr = new int[this.capacity];
        }

        /// <summary>
        /// The number of elements in the collection
        /// </summary>
        public int Count => this.count;

        /// <summary>
        /// Provides access to collection's elements by specifying an index
        /// </summary>
        /// <param name="index">0 based index not greater than or equal to collection's count of elements</param>
        /// <returns>The element at the specified index</returns>"
        /// <exception cref="IndexOutOfRangeException">Thrown when parameter index is less than 0 or greater than or equal to collection's count of elements</exception>
        public int this[int index]
        {
            get
            {
                if (IsInvalid(index))
                {
                    throw new IndexOutOfRangeException();
                }

                return this.internalArr[index];
            }

            set
            {
                if (IsInvalid(index))
                {
                    throw new IndexOutOfRangeException();
                }

                this.internalArr[index] = value;
            }
        }

        /// <summary>
        /// Adds to the end of the collection the element that was passed.
        /// </summary>
        /// <param name="element">The int value to add to the collection.</param>
        public void Add(int element)
        {
            EnsureCapacity();
            this.internalArr[this.Count] = element;
            this.count++;
        }

        /// <summary>
        /// Removes the element at the specified index if index is valid.
        /// </summary>
        /// <param name="index">The 0 based index greater than 0 and less than collection's count of elements.</param>
        /// <returns>The element that was removed.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when index is less than 0 and greater than collection's count of elements.</exception>
        public int RemoveAt(int index)
        {
            if (IsInvalid(index))
            {
                throw new ArgumentOutOfRangeException();
            }

            int valueToRemove = this.internalArr[index];
            this.count--;
            ShiftLeft(index);
            OptimizeCapacity();

            return valueToRemove;
        }

        /// <summary>
        /// Confirms whether the element exists in the collection or not.
        /// </summary>
        /// <param name="element">The for which is to confirm presence.</param>
        /// <returns>True, if element exists. False if element is not present.</returns>
        public bool Contains(int element)
        {
            if (this.internalArr.Any(e => e == element))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Swaps the elements at the passed indexes if they are valid.
        /// </summary>
        /// <param name="firstIndex">The index of the element to be swapped.</param>
        /// <param name="secondIndex">The index of the other element which it to be swapped with the first one.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when any of the indexes passed is invalid.</exception>
        public void Swap(int firstIndex, int secondIndex)
        {
            if (IsInvalid(firstIndex) || IsInvalid(secondIndex))
            {
                throw new ArgumentOutOfRangeException();
            }

            int temp = this.internalArr[firstIndex];
            this.internalArr[firstIndex] = this.internalArr[secondIndex];
            this.internalArr[secondIndex] = temp;
        }

        /// <summary>
        /// Inserts given element at the given index if index is valid.
        /// </summary>
        /// <param name="index">The 0 based index of the element in the collection.</param>
        /// <param name="value">The element to be inserted.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when index is less than 0 or greater than the count of the elements.</exception>
        public void InsertAt(int index, int value)
        {
            if (IsInvalid(index))
            {
                throw new ArgumentOutOfRangeException();
            }

            EnsureCapacity();
            ShiftRight(index);
            this.internalArr[index] = value;
            this.count++;
        }

        /// <summary>
        /// Reverses the order of the elements in the collection.
        /// </summary>
        public void Reverse()
        {
            int[] reversed = new int[this.count];
            for (int i = this.Count - 1, j = 0; i >= 0; i--, j++)
            {
                reversed[j] = this.internalArr[i];
            }

            this.internalArr = reversed;
        }

        /// <summary>
        /// Represents the current elements order as a string.
        /// </summary>
        /// <returns>A string that has all elements separated by a single white space character.</returns>
        public override string ToString()
        {
            int[] elements = new int[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                elements[i] = this.internalArr[i];
            }

            return string.Join(' ', elements);
        }

        private void EnsureCapacity()
        {
            if (this.Count == this.capacity)
            {
                Resize();
            }
        }

        private void OptimizeCapacity()
        {
            if (this.Count < this.capacity / 2)
            {
                Shrink();
            }
        }

        private void Resize()
        {
            this.capacity *= 2;
            int[] newArr = new int[this.capacity];
            this.internalArr.CopyTo(newArr, 0);

            this.internalArr = newArr;
        }

        private void Shrink()
        {
            this.capacity /= 2;
            int[] newArr = new int[this.capacity];
            this.internalArr.Take(this.Count).ToArray().CopyTo(newArr, 0);

            this.internalArr = newArr;
        }

        private void ShiftLeft(int startIndex)
        {
            for (int i = startIndex; i < this.Count; i++)
            {
                this.internalArr[i] = this.internalArr[i + 1];
            }

            this.internalArr[this.Count] = default;
        }

        private void ShiftRight(int startIndex)
        {
            int cellValue = this.internalArr[startIndex];
            this.internalArr[startIndex] = default;
            for (int i = startIndex + 1; i <= this.Count; i++)
            {
                int temp = this.internalArr[i];
                this.internalArr[i] = cellValue;
                cellValue = temp;
            }
        }

        private bool IsInvalid(int index)
        {
            if (index < 0 || index >= this.Count)
                return true;

            return false;
        }
    }
}
