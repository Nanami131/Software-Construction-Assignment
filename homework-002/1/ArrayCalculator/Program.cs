using System;

public class ArrayCalculator
{
    public int FindMax(int[] array)
    {
        if (array == null || array.Length == 0)
            throw new ArgumentException("非法的数组");

        int max = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > max)
                max = array[i];
        }
        return max;
    }

    public int FindMin(int[] array)
    {
        if (array == null || array.Length == 0)
            throw new ArgumentException("非法的数组");

        int min = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] < min)
                min = array[i];
        }
        return min;
    }

    public double FindAverage(int[] array)
    {
        if (array == null || array.Length == 0)
            throw new ArgumentException("非法的数组");

        double sum = 0;
        foreach (int num in array)
        {
            sum += num;
        }
        return sum / array.Length;
    }

    public int FindSum(int[] array)
    {
        if (array == null || array.Length == 0)
            throw new ArgumentException("非法的数组");

        int sum = 0;
        foreach (int num in array)
        {
            sum += num;
        }
        return sum;
    }

    public static void Main(string[] args)
    {
        //也可以数组设计成允许用户交互的
        int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        ArrayCalculator arrayCalculator = new ArrayCalculator();

        int max = arrayCalculator.FindMax(arr);
        int min = arrayCalculator.FindMin(arr);
        double average = arrayCalculator.FindAverage(arr);
        int sum = arrayCalculator.FindSum(arr);

        Console.WriteLine("Max: " + max);
        Console.WriteLine("Min: " + min);
        Console.WriteLine("Average: " + average);
        Console.WriteLine("Sum: " + sum);
    }
}
