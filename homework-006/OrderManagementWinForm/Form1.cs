using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderManagementWinForm
{
    public partial class Form1 : Form
    {
        private BindingSource ordersBindingSource = new BindingSource();
        //private DataGridView dataGridViewOrders = new DataGridView();
        public Form1()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // 将BindingSource对象绑定到DataGridView的DataSource属性
            dataGridViewOrders.DataSource = ordersBindingSource;

            // 通过DataMember属性将订单对象的属性绑定到DataGridView的列上
            dataGridViewOrders.AutoGenerateColumns = false;
            dataGridViewOrders.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "OrderID",
                HeaderText = "Order ID"
            });
            dataGridViewOrders.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Customer",
                HeaderText = "Customer"
            });
            dataGridViewOrders.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "TotalAmount",
                HeaderText = "Total Amount"
            });
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //private void button1_Click(object sender, EventArgs e)
        //{

        //}
    }
}
