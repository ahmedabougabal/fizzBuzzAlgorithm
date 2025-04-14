using System;
using fizzBuzzAlgo;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a string (between 7 and 100 characters):");
        string? input = Console.ReadLine();
        
        if (input == null)
        {
            Console.WriteLine("Error: Input cannot be null");
            return;
        }

        try
        {
            FizzBuzzDetector detector = new FizzBuzzDetector();
            FizzBuzzResult result = detector.GetOverlappings(input);
            
            Console.WriteLine("\nOutput string:");
            Console.WriteLine(result.OutputString);
            Console.WriteLine("\nCount: " + result.Count);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}