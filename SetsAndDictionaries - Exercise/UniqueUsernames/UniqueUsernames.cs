using System;
using System.Collections.Generic;

namespace UniqueUsernames
{
    public class UniqueUsernames
    {
        public static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            HashSet<string> uniqueUsernames = new HashSet<string>();
            for (int i = 0; i < N; i++)
            {
                uniqueUsernames.Add(Console.ReadLine());
            }

            foreach (var user in uniqueUsernames)
            {
                Console.WriteLine(user);
            }
        }
    }
}
