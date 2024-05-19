using System;
using System.Collections.Generic;
using System.Linq;

// 订单类
public class Order
{
    public string OrderID { get; set; }  // 订单编号
    public string Customer { get; set; } // 客户名称
    public List<OrderDetails> OrderDetails { get; set; } // 订单明细
    public decimal TotalAmount => OrderDetails.Sum(od => od.Amount); // 订单总金额

    public Order(string orderId, string customer)
    {
        OrderID = orderId;
        Customer = customer;
        OrderDetails = new List<OrderDetails>();
    }

    // 重写Equals方法，确保订单不重复
    public override bool Equals(object obj)
    {
        return obj is Order order && OrderID == order.OrderID;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(OrderID);
    }

    // 重写ToString方法，显示订单信息
    public override string ToString()
    {
        return $"OrderID: {OrderID}, Customer: {Customer}, TotalAmount: {TotalAmount:C}";
    }
}

// 订单明细类
public class OrderDetails
{
    public string ProductName { get; set; } // 商品名称
    public int Quantity { get; set; } // 商品数量
    public decimal Price { get; set; } // 商品单价
    public decimal Amount => Quantity * Price; // 金额

    public OrderDetails(string productName, int quantity, decimal price)
    {
        ProductName = productName;
        Quantity = quantity;
        Price = price;
    }

    // 重写Equals方法，确保订单明细不重复
    public override bool Equals(object obj)
    {
        return obj is OrderDetails details && ProductName == details.ProductName;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(ProductName);
    }

    // 重写ToString方法，显示订单明细信息
    public override string ToString()
    {
        return $"Product: {ProductName}, Quantity: {Quantity}, Price: {Price:C}, Amount: {Amount:C}";
    }
}
