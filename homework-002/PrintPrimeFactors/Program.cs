using System;

class Program
{
    static bool IsPrime(int number)
    {
        if (number <= 1)
            return false;

        for (int i = 2; i * i <= number; i++)
        {
            if (number % i == 0)
                return false;
        }
        return true;
    }

    static void PrintPrimeFactors(int number)
    {
        Console.WriteLine($"素数因子 for {number}:");
        for (int i = 2; i <= number; i++)
        {
            if (number % i == 0 && IsPrime(i))
            {
                Console.WriteLine(i);
            }
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("请输入一个整数:");
        int userInput;
        if (int.TryParse(Console.ReadLine(), out userInput))
        {
            PrintPrimeFactors(userInput);
        }
        else
        {
            Console.WriteLine("无效输入，请输入一个整数。");
        }
    }
}
