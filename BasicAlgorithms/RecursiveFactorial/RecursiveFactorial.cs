using System;

namespace RecursiveFactorial
{
    public class RecursiveFactorial
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            long factorial = Factorial(number);

            Console.WriteLine(factorial);
        }

        private static long Factorial(int number)
        {
            if (number < 0)
            {
                throw new InvalidOperationException("Invalid input");
            }

            if (number == 0)
            {
                return 1;
            }

            int currentNum = number;
            long currentFactorial = Factorial(number - 1);
            long finalResult = currentNum * currentFactorial;

            return finalResult;
        }
    }
}