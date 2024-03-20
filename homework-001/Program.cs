using System;

class Program
{
    static void Main(string[] args)
    {
        while (true) {
            double num1, num2 = -1, result = 0;
            char op = 'k';
            bool validInput = false;

            Console.WriteLine("欢迎使用简易计算器！");

            do
            {
                // 输入1
                Console.Write("请输入第一个数字：");
                if (!double.TryParse(Console.ReadLine(), out num1))
                {
                    Console.WriteLine("输入无效，请输入一个有效的数字。");
                    continue;
                }

                // 输入op
                Console.Write("请输入运算符（+、-、*、/）：");
                if (!char.TryParse(Console.ReadLine(), out op) || !IsValidOperator(op))
                {
                    Console.WriteLine("输入无效，请输入一个有效的运算符。");
                    continue;
                }

                // 输入2
                Console.Write("请输入第二个数字：");
                if (!double.TryParse(Console.ReadLine(), out num2))
                {
                    Console.WriteLine("输入无效，请输入一个有效的数字。");
                    continue;
                }

                // 代码健壮性
                if (op == '/' && num2 == 0)
                {
                    Console.WriteLine("除数不能为零，请重新输入。");
                    continue;
                }

                switch (op)
                {
                    case '+':
                        result = num1 + num2;
                        break;
                    case '-':
                        result = num1 - num2;
                        break;
                    case '*':
                        result = num1 * num2;
                        break;
                    case '/':
                        result = num1 / num2;
                        break;
                }

                validInput = true;

            } while (!validInput);

            // 输出
            Console.WriteLine($"计算结果：{num1} {op} {num2} = {result}");

            Console.WriteLine("继续！");
        }


    }
        
    //封装
    static bool IsValidOperator(char op)
    {
        return op == '+' || op == '-' || op == '*' || op == '/';
    }
}
