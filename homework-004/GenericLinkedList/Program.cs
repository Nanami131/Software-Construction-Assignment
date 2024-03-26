using System;

// 定义链表节点
public class ListNode<T>
{
    public T Value { get; set; }
    public ListNode<T> Next { get; set; }

    public ListNode(T value)
    {
        Value = value;
        Next = null;
    }
}

// 定义泛型链表
public class LinkedList<T>
{
    private ListNode<T> head;

    public void Add(T value)
    {
        if (head == null)
        {
            head = new ListNode<T>(value);
        }
        else
        {
            ListNode<T> current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = new ListNode<T>(value);
        }
    }

    public void Print()
    {
        ListNode<T> current = head;
        while (current != null)
        {
            Console.Write(current.Value + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }

    public T Sum()
    {
        T sum = default(T);
        ListNode<T> current = head;
        while (current != null)
        {
            sum += (dynamic)current.Value;
            current = current.Next;
        }
        return sum;
    }

    public T Max()
    {
        if (head == null)
            throw new InvalidOperationException("链表为空。");

        T max = head.Value;
        ListNode<T> current = head.Next;
        while (current != null)
        {
            if ((dynamic)current.Value > (dynamic)max)
            {
                max = current.Value;
            }
            current = current.Next;
        }
        return max;
    }

    public T Min()
    {
        if (head == null)
            throw new InvalidOperationException("链表为空。");

        T min = head.Value;
        ListNode<T> current = head.Next;
        while (current != null)
        {
            if ((dynamic)current.Value < (dynamic)min)
            {
                min = current.Value;
            }
            current = current.Next;
        }
        return min;
    }
}

class Program
{
    static void Main(string[] args)
    {
        LinkedList<int> intList = new LinkedList<int>();
        intList.Add(1);
        intList.Add(2);
        intList.Add(3);
        intList.Add(4);
        intList.Add(5);

        Console.WriteLine("链表中的元素：");
        intList.Print();

        Console.WriteLine("元素的总和： " + intList.Sum());
        Console.WriteLine("最大元素： " + intList.Max());
        Console.WriteLine("最小元素： " + intList.Min());
    }
}
