using System.Collections;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private readonly List<Book> books;

        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
        }

        public List<Book> Books
        {
            get
            {
                this.books.Sort(new BookComparator());
                return this.books;
            }
        }

        public IEnumerator<Book> GetEnumerator()
        {
            //for (int i = 0; i < this.books.Count; i++)
            //{
            //    yield return this.books[i];
            //}

            return new LibraryIterator(this.Books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private class LibraryIterator : IEnumerator<Book>
        {
            private List<Book> books;

            private int currentIndex = -1;

            public LibraryIterator(IEnumerable<Book> books)
            {
                this.books = new List<Book>(books);
            }

            public Book Current => this.books[this.currentIndex];

            object IEnumerator.Current => this.Current;

            public void Dispose()
            {
                this.books = null;
            }

            public bool MoveNext()
            {
                currentIndex++;
                if (currentIndex < this.books.Count)
                {
                    return true;
                }

                return false;
            }

            public void Reset()
            {
                this.currentIndex = -1;
            }
        }
    }
}