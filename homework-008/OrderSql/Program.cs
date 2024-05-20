using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using System.Windows.Forms;
namespace OrderManagementSystem
{
    public partial class MainForm : Form
    {
        private OrderService orderService;
        private BindingSource orderBindingSource;
        private BindingSource orderDetailsBindingSource;

        public MainForm()
        {
            InitializeComponent();
            orderService = new OrderService();
            orderBindingSource = new BindingSource();
            orderDetailsBindingSource = new BindingSource();

            orderBindingSource.DataSource = orderService.GetOrdersSortedByDefault();
            orderDetailsBindingSource.DataSource = orderBindingSource;
            orderDetailsBindingSource.DataMember = "OrderDetails";

            dataGridViewOrders.DataSource = orderBindingSource;
            dataGridViewOrderDetails.DataSource = orderDetailsBindingSource;
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            var orderForm = new OrderForm();
            if (orderForm.ShowDialog() == DialogResult.OK)
            {
                orderService.AddOrder(orderForm.Order);
                orderBindingSource.DataSource = orderService.GetOrdersSortedByDefault();
            }
        }

        private void btnUpdateOrder_Click(object sender, EventArgs e)
        {
            if (orderBindingSource.Current is Order order)
            {
                var orderForm = new OrderForm(order);
                if (orderForm.ShowDialog() == DialogResult.OK)
                {
                    orderService.UpdateOrder(orderForm.Order);
                    orderBindingSource.DataSource = orderService.GetOrdersSortedByDefault();
                }
            }
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            if (orderBindingSource.Current is Order order)
            {
                orderService.RemoveOrder(order.OrderID);
                orderBindingSource.DataSource = orderService.GetOrdersSortedByDefault();
            }
        }

        private void btnQueryOrder_Click(object sender, EventArgs e)
        {
            var queryForm = new QueryForm();
            if (queryForm.ShowDialog() == DialogResult.OK)
            {
                orderBindingSource.DataSource = orderService.QueryOrders(queryForm.Query);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // 初始化数据绑定
            dataGridViewOrders.AutoGenerateColumns = true;
            dataGridViewOrderDetails.AutoGenerateColumns = true;
        }
    }
}
namespace OrderManagementSystem
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewOrders;
        private System.Windows.Forms.DataGridView dataGridViewOrderDetails;
        private System.Windows.Forms.Button btnAddOrder;
        private System.Windows.Forms.Button btnUpdateOrder;
        private System.Windows.Forms.Button btnDeleteOrder;
        private System.Windows.Forms.Button btnQueryOrder;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridViewOrders = new System.Windows.Forms.DataGridView();
            this.dataGridViewOrderDetails = new System.Windows.Forms.DataGridView();
            this.btnAddOrder = new System.Windows.Forms.Button();
            this.btnUpdateOrder = new System.Windows.Forms.Button();
            this.btnDeleteOrder = new System.Windows.Forms.Button();
            this.btnQueryOrder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderDetails)).BeginInit();
            this.SuspendLayout();

            // dataGridViewOrders
            this.dataGridViewOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrders.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewOrders.Name = "dataGridViewOrders";
            this.dataGridViewOrders.Size = new System.Drawing.Size(760, 200);
            this.dataGridViewOrders.TabIndex = 0;

            // dataGridViewOrderDetails
            this.dataGridViewOrderDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrderDetails.Location = new System.Drawing.Point(12, 218);
            this.dataGridViewOrderDetails.Name = "dataGridViewOrderDetails";
            this.dataGridViewOrderDetails.Size = new System.Drawing.Size(760, 200);
            this.dataGridViewOrderDetails.TabIndex = 1;

            // btnAddOrder
            this.btnAddOrder.Location = new System.Drawing.Point(12, 424);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.Size = new System.Drawing.Size(75, 23);
            this.btnAddOrder.TabIndex = 2;
            this.btnAddOrder.Text = "Add Order";
            this.btnAddOrder.UseVisualStyleBackColor = true;
            this.btnAddOrder.Click += new System.EventHandler(this.btnAddOrder_Click);

            // btnUpdateOrder
            this.btnUpdateOrder.Location = new System.Drawing.Point(93, 424);
            this.btnUpdateOrder.Name = "btnUpdateOrder";
            this.btnUpdateOrder.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateOrder.TabIndex = 3;
            this.btnUpdateOrder.Text = "Update Order";
            this.btnUpdateOrder.UseVisualStyleBackColor = true;
            this.btnUpdateOrder.Click += new System.EventHandler(this.btnUpdateOrder_Click);

            // btnDeleteOrder
            this.btnDeleteOrder.Location = new System.Drawing.Point(174, 424);
            this.btnDeleteOrder.Name = "btnDeleteOrder";
            this.btnDeleteOrder.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteOrder.TabIndex = 4;
            this.btnDeleteOrder.Text = "Delete Order";
            this.btnDeleteOrder.UseVisualStyleBackColor = true;
            this.btnDeleteOrder.Click += new System.EventHandler(this.btnDeleteOrder_Click);

            // btnQueryOrder
            this.btnQueryOrder.Location = new System.Drawing.Point(255, 424);
            this.btnQueryOrder.Name = "btnQueryOrder";
            this.btnQueryOrder.Size = new System.Drawing.Size(75, 23);
            this.btnQueryOrder.TabIndex = 5;
            this.btnQueryOrder.Text = "Query Order";
            this.btnQueryOrder.UseVisualStyleBackColor = true;
            this.btnQueryOrder.Click += new System.EventHandler(this.btnQueryOrder_Click);

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.btnQueryOrder);
            this.Controls.Add(this.btnDeleteOrder);
            this.Controls.Add(this.btnUpdateOrder);
            this.Controls.Add(this.btnAddOrder);
            this.Controls.Add(this.dataGridViewOrderDetails);
            this.Controls.Add(this.dataGridViewOrders);
            this.Name = "MainForm";
            this.Text = "Order Management System";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderDetails)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
namespace OrderManagementSystem
{
    public class OrderManagementContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Database=OrderManagement;User=root;Password=password;",
                new MySqlServerVersion(new Version(8, 0, 21)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasKey(o => o.OrderID);
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderDetails)
                .WithOne()
                .HasForeignKey(od => od.OrderID);
        }
    }
}


namespace OrderManagementSystem
{
    public class Order
    {
        public string OrderID { get; set; }
        public string Customer { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
        public decimal TotalAmount => OrderDetails.Sum(od => od.Amount);

        // 无参数构造函数
        public Order()
        {
            OrderDetails = new List<OrderDetails>();
        }

        // 带参数的构造函数
        public Order(string orderId, string customer) : this()
        {
            OrderID = orderId;
            Customer = customer;
        }

        public override bool Equals(object obj)
        {
            return obj is Order order && OrderID == order.OrderID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(OrderID);
        }

        public override string ToString()
        {
            return $"OrderID: {OrderID}, Customer: {Customer}, TotalAmount: {TotalAmount:C}";
        }
    }
}



namespace OrderManagementSystem
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public string OrderID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Amount => Quantity * Price;

        // 无参数构造函数
        public OrderDetails() { }

        // 带参数的构造函数
        public OrderDetails(string productName, int quantity, decimal price)
        {
            ProductName = productName;
            Quantity = quantity;
            Price = price;
        }

        public override bool Equals(object obj)
        {
            return obj is OrderDetails details && ProductName == details.ProductName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ProductName);
        }

        public override string ToString()
        {
            return $"Product: {ProductName}, Quantity: {Quantity}, Price: {Price:C}, Amount: {Amount:C}";
        }
    }
}

namespace OrderManagementSystem
{
    public class OrderService
    {
        private OrderManagementContext context;

        public OrderService()
        {
            context = new OrderManagementContext();
            context.Database.EnsureCreated();
        }

        public void AddOrder(Order order)
        {
            if (context.Orders.Any(o => o.OrderID == order.OrderID))
            {
                throw new Exception("Order already exists.");
            }
            context.Orders.Add(order);
            context.SaveChanges();
        }

        public void RemoveOrder(string orderId)
        {
            var order = context.Orders.Include(o => o.OrderDetails).FirstOrDefault(o => o.OrderID == orderId);
            if (order == null)
            {
                throw new Exception("Order not found.");
            }
            context.Orders.Remove(order);
            context.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            var existingOrder = context.Orders.Include(o => o.OrderDetails).FirstOrDefault(o => o.OrderID == order.OrderID);
            if (existingOrder == null)
            {
                throw new Exception("Order not found.");
            }
            existingOrder.Customer = order.Customer;
            existingOrder.OrderDetails = order.OrderDetails;
            context.SaveChanges();
        }

        public List<Order> QueryOrders(Func<Order, bool> query)
        {
            return context.Orders.Include(o => o.OrderDetails).AsEnumerable().Where(query).OrderBy(o => o.TotalAmount).ToList();
        }

        public List<Order> GetOrdersSortedBy(Func<Order, object> keySelector)
        {
            return context.Orders.Include(o => o.OrderDetails).AsEnumerable().OrderBy(keySelector).ToList();
        }

        public List<Order> GetOrdersSortedByDefault()
        {
            return context.Orders.Include(o => o.OrderDetails).OrderBy(o => o.OrderID).ToList();
        }
    }
}





namespace OrderManagementSystem
{
    public partial class OrderForm : Form
    {
        public Order Order { get; private set; }
        private BindingSource orderDetailsBindingSource;

        public OrderForm() : this(new Order(Guid.NewGuid().ToString(), ""))
        {
        }

        public OrderForm(Order order)
        {
            InitializeComponent();
            Order = order;
            orderDetailsBindingSource = new BindingSource();
            orderDetailsBindingSource.DataSource = Order.OrderDetails;

            txtOrderID.DataBindings.Add("Text", Order, "OrderID");
            txtCustomer.DataBindings.Add("Text", Order, "Customer");
            dataGridViewOrderDetails.DataSource = orderDetailsBindingSource;
        }

        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            var detailForm = new OrderDetailForm();
            if (detailForm.ShowDialog() == DialogResult.OK)
            {
                Order.OrderDetails.Add(detailForm.OrderDetail);
                orderDetailsBindingSource.ResetBindings(false);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}



namespace OrderManagementSystem
{
    partial class OrderForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridView;        
        private System.Windows.Forms.DataGridView dataGridViewOrderDetails;
        private System.Windows.Forms.TextBox txtOrderID;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label lblOrderID;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Button btnAddDetail;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridViewOrderDetails = new System.Windows.Forms.DataGridView();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.lblOrderID = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.btnAddDetail = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderDetails)).BeginInit();
            this.SuspendLayout();

            // dataGridViewOrderDetails
            this.dataGridViewOrderDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrderDetails.Location = new System.Drawing.Point(12, 71);
            this.dataGridViewOrderDetails.Name = "dataGridViewOrderDetails";
            this.dataGridViewOrderDetails.Size = new System.Drawing.Size(360, 150);
            this.dataGridViewOrderDetails.TabIndex = 0;

            // txtOrderID
            this.txtOrderID.Location = new System.Drawing.Point(75, 12);
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.Size = new System.Drawing.Size(100, 20);
            this.txtOrderID.TabIndex = 1;

            // txtCustomer
            this.txtCustomer.Location = new System.Drawing.Point(75, 38);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(100, 20);
            this.txtCustomer.TabIndex = 2;

            // lblOrderID
            this.lblOrderID.AutoSize = true;
            this.lblOrderID.Location = new System.Drawing.Point(12, 15);
            this.lblOrderID.Name = "lblOrderID";
            this.lblOrderID.Size = new System.Drawing.Size(47, 13);
            this.lblOrderID.TabIndex = 3;
            this.lblOrderID.Text = "Order ID";

            // lblCustomer
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(12, 41);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(51, 13);
            this.lblCustomer.TabIndex = 4;
            this.lblCustomer.Text = "Customer";

            // btnAddDetail
            this.btnAddDetail.Location = new System.Drawing.Point(297, 38);
            this.btnAddDetail.Name = "btnAddDetail";
            this.btnAddDetail.Size = new System.Drawing.Size(75, 23);
            this.btnAddDetail.TabIndex = 5;
            this.btnAddDetail.Text = "Add Detail";
            this.btnAddDetail.UseVisualStyleBackColor = true;
            this.btnAddDetail.Click += new System.EventHandler(this.btnAddDetail_Click);

            // btnOK
            this.btnOK.Location = new System.Drawing.Point(216, 227);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(297, 227);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // OrderForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnAddDetail);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.lblOrderID);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.txtOrderID);
            this.Controls.Add(this.dataGridViewOrderDetails);
            this.Name = "OrderForm";
            this.Text = "OrderForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}


namespace OrderManagementSystem
{
    public partial class OrderDetailForm : Form
    {
        public OrderDetails OrderDetail { get; private set; }

        public OrderDetailForm() : this(new OrderDetails("", 0, 0))
        {
        }

        public OrderDetailForm(OrderDetails orderDetail)
        {
            InitializeComponent();
            OrderDetail = orderDetail;

            txtProductName.DataBindings.Add("Text", OrderDetail, "ProductName");
            txtQuantity.DataBindings.Add("Text", OrderDetail, "Quantity");
            txtPrice.DataBindings.Add("Text", OrderDetail, "Price");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
namespace OrderManagementSystem
{
    partial class OrderDetailForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // txtProductName
            this.txtProductName.Location = new System.Drawing.Point(97, 12);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(175, 20);
            this.txtProductName.TabIndex = 0;

            // txtQuantity
            this.txtQuantity.Location = new System.Drawing.Point(97, 38);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(175, 20);
            this.txtQuantity.TabIndex = 1;

            // txtPrice
            this.txtPrice.Location = new System.Drawing.Point(97, 64);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(175, 20);
            this.txtPrice.TabIndex = 2;

            // lblProductName
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(12, 15);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(75, 13);
            this.lblProductName.TabIndex = 3;
            this.lblProductName.Text = "Product Name";

            // lblQuantity
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(12, 41);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(46, 13);
            this.lblQuantity.TabIndex = 4;
            this.lblQuantity.Text = "Quantity";

            // lblPrice
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(12, 67);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(31, 13);
            this.lblPrice.TabIndex = 5;
            this.lblPrice.Text = "Price";

            // btnOK
            this.btnOK.Location = new System.Drawing.Point(116, 100);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(197, 100);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // OrderDetailForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 135);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtProductName);
            this.Name = "OrderDetailForm";
            this.Text = "Order Detail";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}


namespace OrderManagementSystem
{
    public partial class QueryForm : Form
    {
        public Func<Order, bool> Query { get; private set; }

        public QueryForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var customer = txtCustomer.Text;
            var minAmount = nudMinAmount.Value;
            var maxAmount = nudMaxAmount.Value;

            Query = o => (string.IsNullOrEmpty(customer) || o.Customer.Contains(customer)) &&
                         o.TotalAmount >= minAmount &&
                         o.TotalAmount <= maxAmount;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
namespace OrderManagementSystem
{
    partial class QueryForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label lblMinAmount;
        private System.Windows.Forms.NumericUpDown nudMinAmount;
        private System.Windows.Forms.Label lblMaxAmount;
        private System.Windows.Forms.NumericUpDown nudMaxAmount;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblCustomer = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.lblMinAmount = new System.Windows.Forms.Label();
            this.nudMinAmount = new System.Windows.Forms.NumericUpDown();
            this.lblMaxAmount = new System.Windows.Forms.Label();
            this.nudMaxAmount = new System.Windows.Forms.NumericUpDown();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxAmount)).BeginInit();
            this.SuspendLayout();

            // lblCustomer
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(12, 15);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(51, 13);
            this.lblCustomer.TabIndex = 0;
            this.lblCustomer.Text = "Customer";

            // txtCustomer
            this.txtCustomer.Location = new System.Drawing.Point(93, 12);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(179, 20);
            this.txtCustomer.TabIndex = 1;

            // lblMinAmount
            this.lblMinAmount.AutoSize = true;
            this.lblMinAmount.Location = new System.Drawing.Point(12, 41);
            this.lblMinAmount.Name = "lblMinAmount";
            this.lblMinAmount.Size = new System.Drawing.Size(65, 13);
            this.lblMinAmount.TabIndex = 2;
            this.lblMinAmount.Text = "Min Amount";

            // nudMinAmount
            this.nudMinAmount.DecimalPlaces = 2;
            this.nudMinAmount.Location = new System.Drawing.Point(93, 39);
            this.nudMinAmount.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.nudMinAmount.Name = "nudMinAmount";
            this.nudMinAmount.Size = new System.Drawing.Size(179, 20);
            this.nudMinAmount.TabIndex = 3;

            // lblMaxAmount
            this.lblMaxAmount.AutoSize = true;
            this.lblMaxAmount.Location = new System.Drawing.Point(12, 67);
            this.lblMaxAmount.Name = "lblMaxAmount";
            this.lblMaxAmount.Size = new System.Drawing.Size(68, 13);
            this.lblMaxAmount.TabIndex = 4;
            this.lblMaxAmount.Text = "Max Amount";

            // nudMaxAmount
            this.nudMaxAmount.DecimalPlaces = 2;
            this.nudMaxAmount.Location = new System.Drawing.Point(93, 65);
            this.nudMaxAmount.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.nudMaxAmount.Name = "nudMaxAmount";
            this.nudMaxAmount.Size = new System.Drawing.Size(179, 20);
            this.nudMaxAmount.TabIndex = 5;

            // btnOK
            this.btnOK.Location = new System.Drawing.Point(116, 100);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(197, 100);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // QueryForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 135);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.nudMaxAmount);
            this.Controls.Add(this.lblMaxAmount);
            this.Controls.Add(this.nudMinAmount);
            this.Controls.Add(this.lblMinAmount);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.lblCustomer);
            this.Name = "QueryForm";
            this.Text = "Query Order";
            ((System.ComponentModel.ISupportInitialize)(this.nudMinAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}


namespace OrderManagementSystem
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}


