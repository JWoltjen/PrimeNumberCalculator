using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());
        var factors = GetFactors(number);
        var primeFactors = GetPrimeFactors(factors);

        PrintIsPrime(number);
        Console.WriteLine($"The number {number} has {factors.Count} unique factors.");
        Console.WriteLine("The prime factors are: " + string.Join(", ", primeFactors));
        Console.WriteLine("The largest prime factor is: " + (primeFactors.Count > 0 ? primeFactors[primeFactors.Count - 1].ToString() : "None"));
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

    static List<int> GetFactors(int number)
    {
        // initialize the list that will hold all the factors
        var factors = new List<int>();

        // initialize the loop that will look for factors
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            // if the number divided by i has 0 remainder, it's a factor
            if(number % i == 0)
            {
                // add it to the List
                factors.Add(i);
                // checking for duplicates 
                if(i != number / i)
                {
                    factors.Add(number / i);
                }
            }
        }
        factors.Sort();
        return factors;
    }
    static List<int> GetPrimeFactors(List<int> factors)
    {
        var primeFactors = new List<int>();

        foreach (var factor in factors)
        {
            if(isPrime(factor))
            {
                primeFactors.Add(factor);
            }
        }
        return primeFactors;
    }
}