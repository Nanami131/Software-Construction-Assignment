public class Program
{
    static void Main(string[] args)
    {
        OrderService orderService = new OrderService(); // 实例化订单服务

        // 创建订单1
        Order order1 = new Order("001", "Alice");
        order1.OrderDetails.Add(new OrderDetails("Apple", 2, 3.5m));
        order1.OrderDetails.Add(new OrderDetails("Banana", 3, 2m));

        // 创建订单2
        Order order2 = new Order("002", "Bob");
        order2.OrderDetails.Add(new OrderDetails("Orange", 1, 4m));
        order2.OrderDetails.Add(new OrderDetails("Apple", 5, 3.5m));

        // 添加订单
        orderService.AddOrder(order1);
        orderService.AddOrder(order2);

        // 查询订单，按客户名称查询
        var queryResult = orderService.QueryOrders(o => o.Customer == "Alice");
        foreach (var order in queryResult)
        {
            Console.WriteLine(order);
        }

        // 删除订单，测试删除不存在的订单
        try
        {
            orderService.RemoveOrder("003");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message); // 打印异常信息
        }

        // 修改订单，测试修改订单
        try
        {
            order2.Customer = "Charlie";
            orderService.UpdateOrder(order2);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message); // 打印异常信息
        }
        // 显示所有订单，按订单编号排序
        var sortedOrders = orderService.GetOrdersSortedByDefault();
        foreach (var order in sortedOrders)
        {
            Console.WriteLine(order);
        }
        Console.WriteLine("程序会抛出异常是因为我在删除功能里测试了异常的情况，并非BUG");
        //Console.Read();
    }
}
