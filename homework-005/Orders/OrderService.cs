public class OrderService
{
    private List<Order> orders = new List<Order>(); // 存储订单列表

    // 添加订单
    public void AddOrder(Order order)
    {
        if (orders.Contains(order))
        {
            //Console.WriteLine("Order already exists.");
            throw new Exception("Order already exists."); // 订单已存在异常
        }
        orders.Add(order);
    }

    // 删除订单
    public void RemoveOrder(string orderId)
    {
        var order = orders.FirstOrDefault(o => o.OrderID == orderId);
        if (order == null)
        {
           // Console.WriteLine("Order not found.");
            throw new Exception("Order not found."); // 订单未找到异常
           
        }
            
        orders.Remove(order);
    }

    // 修改订单
    public void UpdateOrder(Order order)
    {
        var existingOrder = orders.FirstOrDefault(o => o.OrderID == order.OrderID);
        if (existingOrder == null)
            throw new Exception("Order not found."); // 订单未找到异常
        existingOrder.Customer = order.Customer;
        existingOrder.OrderDetails = order.OrderDetails;
    }

    // 查询订单（使用LINQ）
    public List<Order> QueryOrders(Func<Order, bool> query)
    {
        return orders.Where(query).OrderBy(o => o.TotalAmount).ToList(); // 按订单金额排序
    }

    // 按自定义方式排序
    public List<Order> GetOrdersSortedBy(Func<Order, object> keySelector)
    {
        return orders.OrderBy(keySelector).ToList();
    }

    // 按订单编号排序
    public List<Order> GetOrdersSortedByDefault()
    {
        return orders.OrderBy(o => o.OrderID).ToList();
    }
}
