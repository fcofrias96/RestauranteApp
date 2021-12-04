using DataBase;
using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Point_of_Sale
{
    public partial class MenuPointOfSale : Form
    {
        int index = -1, id;
        static IHubProxy _hub;

        public MenuPointOfSale()
        {
            InitializeComponent();
            button1.Enabled = false;
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
        

        private void buttonNewOrder_Click(object sender, EventArgs e)
        {
            OrderForm form = new OrderForm();
            form.Show();
            
        }


        public static async Task LoadDataGrigView()
        {
            var orderList = await Task.Run(async () => {

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
            
            Task task2 =  Task.Run(() =>
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = int.Parse(dataGridView1.CurrentCell.RowIndex.ToString());

            if (index != -1)
            {
                id = int.Parse(dataGridView1.Rows[index].Cells[0].Value.ToString());
                string status = dataGridView1.Rows[index].Cells[6].Value.ToString();

                if (status == "To Deliver")
                {
                    button1.Enabled = true;
                }
                else
                {
                    button1.Enabled = false;
                }
            }
        }

        private async void MenuPointOfSale_Load(object sender, EventArgs e)
        {
            await LoadDataGrigView();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            using(Model context = new Model())
            {

                Orders order = context.Orders.Single(i => i.ID == id);
                order.STATES = 4;
                await context.SaveChangesAsync();
            }

            await LoadDataGrigView();
            MessageBox.Show("Status Order Update");
            button1.Enabled = false;
        }
    }
}
