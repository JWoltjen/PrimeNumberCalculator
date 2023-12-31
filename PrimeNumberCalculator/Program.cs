﻿using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Enter a number (or 'q' to quit): ");
            string input = Console.ReadLine();
            if (input.ToLower() == "q")
            {
                break;
            }
            long number;
            // The out keyword in C# allows a method to output a value by assigning it to a parameter
            // whatever the output of the method is, store the value in the variable "number"
            if (long.TryParse(input, out number))
            {
                PrintIsPrime(number);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid longeger");
            }
        }
    }

    static void PrintIsPrime(long number)
    {
        if(isPrime(number))
        {
            Console.WriteLine($"{number} is a prime number");
        }
        else
        {
            Console.WriteLine($"{number} is not a prime number");
            PrintFactors(number);
        }
    }

    static void PrintFactors(long number)
    {
        var factors = GetFactors(number);
        var primeFactors = GetPrimeFactors(factors);
        Console.WriteLine($"The number {number} has {factors.Count} unique factors.");
        Console.WriteLine("The prime factors are: " + string.Join(", ", primeFactors));
        Console.WriteLine("The biggest prime factor is: " + (primeFactors.Count > 0 ? primeFactors[primeFactors.Count - 1]: "None"));
    }

    static bool isPrime (long number)
    {
        if (number <= 1) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;
        /*
        * The reason this works is due to the properties of factors. For a number n, if it has a factor greater than its square root, then there must be a corresponding factor that is less than its square root. For example, if n is 36, its square root is 6. The factors of 36 are 1, 2, 3, 4, 6, 9, 12, 18, and 36. Notice that for every factor greater than 6, there is a corresponding factor less than 6.
        */
        var boundary = (long)Math.Floor(Math.Sqrt(number));
       
        for (long i = 3; i <= boundary; i += 2)//set loop at just beyond special base cases. already checked evens can't be prime
        {
            if (number % i == 0)
                return false;
        }
        return true;
    }

    static List<long> GetFactors(long number)
    {
        // initialize the list that will hold all the factors
        var factors = new List<long>();

        // initialize the loop that will look for factors
        for (long i = 2; i <= Math.Sqrt(number); i++)
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
    static List<long> GetPrimeFactors(List<long> factors)
    {
        var primeFactors = new List<long>();

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