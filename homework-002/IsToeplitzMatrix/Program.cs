using System;

class Program
{
    static bool IsToeplitzMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows - 1; i++)
        {
            // 检查当前行和下一行的所有元素是否相等
            for (int j = 0; j < cols - 1; j++)
            {
                if (matrix[i, j] != matrix[i + 1, j + 1])
                {
                    return false;
                }
            }
        }

        // 如果所有对角线元素相等，返回 true
        return true;
    }

    static void Main(string[] args)
    {
        
        int[,] matrix = {
            {1, 2, 3, 4},
            {5, 1, 2, 3},
            {9, 5, 1, 2}
        };

        // 检查是否为 Toeplitz 矩阵
        if (IsToeplitzMatrix(matrix))
        {
            Console.WriteLine("输入矩阵是 Toeplitz 矩阵。");
        }
        else
        {
            Console.WriteLine("输入矩阵不是 Toeplitz 矩阵。");
        }
    }
}
