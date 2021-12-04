using DataBase;
using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Order_Monitor
{
    public partial class OrderMonitor : Form
    {
        int index = -1, id;
        string status;
        static IHubProxy _hub;

        public OrderMonitor()
        {
            InitializeComponent();
            button1.Enabled = false;
            buttonUpdate.Enabled = false;

            string url = "http://localhost:8080/";
            var connection = new HubConnection(url);
            _hub = connection.CreateHubProxy("TestHub");
            connection.Start().Wait();

            _hub.On("GetData", data =>
            {
                var orderList = JsonConvert.DeserializeObject(data);

                dataGridView1.Invoke(new MethodInvoker(delegate
                {
                    dataGridView1.DataSource = orderList;
                    if (orderList.Count > 0)
                    {
                        dataGridView1.Columns[0].Visible = false;
                        dataGridView1.Columns[2].Visible = false;
                        dataGridView1.Columns[3].Visible = false;
                        dataGridView1.Columns[4].Visible = false;
                        dataGridView1.Columns[5].Visible = false;
                        dataGridView1.ClearSelection();
                    }

                }));

            });
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = int.Parse(dataGridView1.CurrentCell.RowIndex.ToString());
            if (index != -1)
            {
                button1.Enabled = true;

                id = int.Parse(dataGridView1.Rows[index].Cells[0].Value.ToString());
                status = dataGridView1.Rows[index].Cells[6].Value.ToString();

                if (status == "Pending" || status == "In Process")
                {
                    buttonUpdate.Enabled = true;
                }
                else
                {
                    buttonUpdate.Enabled = false;
                }
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            button1.Enabled = false;
            buttonUpdate.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Details form = new Details();
            form.labelNameClient.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            form.labelFirstCourse.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
            form.labelMainCourse.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
            form.labelDessert.Text = dataGridView1.Rows[index].Cells[4].Value.ToString();
            form.labelDrink.Text = dataGridView1.Rows[index].Cells[5].Value.ToString();
            form.labelStatus.Text = dataGridView1.Rows[index].Cells[6].Value.ToString();
            form.Show();

            dataGridView1.ClearSelection();
            index = -1;
            button1.Enabled = false;
        }


        private async void buttonUpdate_Click(object sender, EventArgs e)
        {
            buttonUpdate.Enabled = false;
            using (Model context = new Model())
            {
                Orders order = context.Orders.Single(i => i.ID == id);

                if (status == "Pending")
                {
                    order.STATES = 2;

                }
                else
                {
                    order.STATES = 3;

                }
                await context.SaveChangesAsync();
                await LoadDataGridView();
                MessageBox.Show("Status Order Updated");
            }

        }




        public static async Task LoadDataGridView()
        {
            var orderList = await Task.Run(async () =>
            {

                using (Model context = new Model())
                {
                    return await context.VW_Orders.Where(i => i.Status != "Done").OrderByDescending(i => i.CREATE_DATE).ToListAsync();
                }
            });

            Task task1 = Task.Run(() =>
            {
                string jsonData = JsonConvert.SerializeObject(orderList);

                _hub.Invoke("Transporter", jsonData);
            });

            Task task2 = Task.Run(() =>
            {
                dataGridView1.Invoke(new MethodInvoker(delegate
                {
                    dataGridView1.DataSource = orderList;
                    if (orderList.Count > 0)
                    {
                        dataGridView1.Columns[0].Visible = false;
                        dataGridView1.Columns[2].Visible = false;
                        dataGridView1.Columns[3].Visible = false;
                        dataGridView1.Columns[4].Visible = false;
                        dataGridView1.Columns[5].Visible = false;
                        dataGridView1.ClearSelection();
                    }

                }));
            });

            await Task.WhenAll(task1, task2);
        }
    }
}