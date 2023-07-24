using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());
        PrintIsPrime(number);
    }

    static void PrintIsPrime(int number)
    {
        if(isPrime(number))
        {
            Console.WriteLine($"{number} is a prime number");
        }
        else
        {
            Console.WriteLine($"{number} is not a prime number");
        }
    }

    static bool isPrime (int number)
    {
        if (number <= 1) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;

        var boundary = (int)Math.Floor(Math.Sqrt(number));
        /*
         * 
         * The reason this works is due to the properties of factors. For a number n, if it has a factor greater than its square root, then there must be a corresponding factor that is less than its square root. For example, if n is 36, its square root is 6. The factors of 36 are 1, 2, 3, 4, 6, 9, 12, 18, and 36. Notice that for every factor greater than 6, there is a corresponding factor less than 6.
         */
        for (int i = 3; i <= boundary; i += 2)//already checked evens can't be prime
        {
            if (number % i == 0)
                return false;
        }
        return true;
    }
}