using System;

class Program
{
    static void Main(string[] args)
    {
        bool[] isPrime = new bool[101];
        for (int i = 2; i <= 100; i++)
        {
            isPrime[i] = true;
        }

        for (int i = 2; i * i <= 100; i++)
        {
            if (isPrime[i])
            {
                for (int j = i * i; j <= 100; j += i)
                {
                    isPrime[j] = false;
                }
            }
        }

        Console.WriteLine("2~100 之间的素数为:");
        for (int i = 2; i <= 100; i++)
        {
            if (isPrime[i])
            {
                Console.Write(i + " ");
            }
        }
    }
}
