using System;

// 定义几何形状抽象类
abstract class Geometry
{
    public abstract bool IsValid(); // 判断几何形状是否有效
    public abstract double CalculateArea(); // 计算几何形状的面积
}

// 矩形类
class Rectangle : Geometry
{
    private double length;
    private double width;

    public Rectangle(double length, double width)
    {
        this.length = length;
        this.width = width;
    }

    public override bool IsValid()
    {
        return length > 0 && width > 0;
    }

    public override double CalculateArea()
    {
        return length * width;
    }
}

// 正方形类
class Square : Geometry
{
    private double side;

    public Square(double side)
    {
        this.side = side;
    }

    public override bool IsValid()
    {
        return side > 0;
    }

    public override double CalculateArea()
    {
        return side * side;
    }
}

// 三角形类
class Triangle : Geometry
{
    private double side1;
    private double side2;
    private double side3;

    public Triangle(double side1, double side2, double side3)
    {
        this.side1 = side1;
        this.side2 = side2;
        this.side3 = side3;
    }

    public override bool IsValid()
    {
        return side1 + side2 > side3 && side1 + side3 > side2 && side2 + side3 > side1;
    }

    public override double CalculateArea()
    {
        double s = (side1 + side2 + side3) / 2;
        return Math.Sqrt(s * (s - side1) * (s - side2) * (s - side3));
    }
}

// 简单工厂模式
class SimpleFactory
{
    public static Geometry CreateGeo(string geoName)
    {
        switch (geoName.ToLower())
        {
            case "rectangle":
                return new Rectangle(GenerateRandomDouble(), GenerateRandomDouble());
            case "square":
                return new Square(GenerateRandomDouble());
            case "triangle":
                return new Triangle(GenerateRandomDouble(), GenerateRandomDouble(), GenerateRandomDouble());
            default:
                throw new ArgumentException("无效的几何形状名称。");
        }
    }

    private static Random random = new Random();

    private static double GenerateRandomDouble()
    {
        return random.NextDouble() * 10 + 1; // 生成1到10之间的随机数
    }
}

// 客户端类
class Client
{
    public static void Main(string[] args)
    {
        const int numberOfShapes = 5; // 随机生成的几何形状数量
        double totalArea = 0;

        for (int i = 0; i < numberOfShapes; i++)
        {
            string[] shapeNames = { "rectangle", "square", "triangle" };
            string randomShapeName = shapeNames[new Random().Next(shapeNames.Length)];
            Geometry shape = SimpleFactory.CreateGeo(randomShapeName);

            if (shape.IsValid())
            {
                double area = shape.CalculateArea();
                Console.WriteLine($"{randomShapeName} 的面积为: {area}");
                totalArea += area;
            }
            else
            {
                Console.WriteLine($"{randomShapeName} 是无效的。");
            }
        }

        Console.WriteLine($"所有形状的总面积为: {totalArea}");
    }
}
