﻿using System;
using System.Collections.Generic;

namespace RecordUniqueNames
{
    public class RecordUniqueNames
    {
        public static void Main()
        {
            int namesCount = int.Parse(Console.ReadLine());

            HashSet<string> uniqueNames = new HashSet<string>();
            for (int i = 0; i < namesCount; i++)
            {
                string name = Console.ReadLine();
                uniqueNames.Add(name);
            }

            foreach (var name in uniqueNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}