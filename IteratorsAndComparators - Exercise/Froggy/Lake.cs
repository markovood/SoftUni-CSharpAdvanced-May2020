using System.Collections;
using System.Collections.Generic;

namespace Froggy
{
    public class Lake : IEnumerable<int>
    {
        private int[] stones;

        public Lake(int[] stones)
        {
            this.stones = stones;
        }

        public int Count => this.stones.Length;

        public IEnumerator<int> GetEnumerator()
        {
            // going forward
            for (int i = 0; i < this.stones.Length; i += 2)
            {
                yield return this.stones[i];
            }

            // going backwards
            if (this.stones.Length % 2 == 0)
            {
                for (int i = this.stones.Length - 1; i >= 0; i -= 2)
                {
                    yield return this.stones[i];
                }
            }
            else
            {
                for (int i = this.stones.Length - 2; i >= 0; i -= 2)
                {
                    yield return this.stones[i];
                }
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
