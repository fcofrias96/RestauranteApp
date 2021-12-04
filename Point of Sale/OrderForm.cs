using DataBase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Point_of_Sale
{
    public partial class OrderForm : Form
    {
        
        public OrderForm()
        {
            InitializeComponent(); 
            
        }

        public async Task LoadComboBoxes()
        {
            var task1 = Task.Run(async () => {

                using (Model context = new Model())
                {
                    List<CbDataSource> list = new List<CbDataSource>();
                    await context.FirstCourses.ForEachAsync(i => {
                        list.Add(new CbDataSource { NAME = i.NAME, VALUE = $"{i.ID};{i.PRICE}" });
                    });
                    comboBoxFirstCourse.Invoke(new MethodInvoker(delegate {

                        comboBoxFirstCourse.DataSource = list;
                        comboBoxFirstCourse.DisplayMember = "NAME";
                        comboBoxFirstCourse.ValueMember = "VALUE";
                        comboBoxFirstCourse.SelectedIndex = -1;
                    }));


                }
            });

            var task2 = Task.Run((async () =>
            {
                using (Model context = new Model())
                {
                    List<CbDataSource> list = new List<CbDataSource>();
                    await context.MainCourses.ForEachAsync(i => {
                        list.Add(new CbDataSource { NAME = i.NAME, VALUE = $"{i.ID};{i.PRICE}" });
                    });
                    comboBoxMainCourse.Invoke(new MethodInvoker(delegate {

                        comboBoxMainCourse.DataSource = list;
                        comboBoxMainCourse.DisplayMember = "NAME";
                        comboBoxMainCourse.ValueMember = "VALUE";
                        comboBoxMainCourse.SelectedIndex = -1;

                    }));
                }

            }));

            var task3 = Task.Run((async () =>
            {
                using (Model context = new Model())
                {
                    List<CbDataSource> list = new List<CbDataSource>();
                    await context.Desserts.ForEachAsync(i => {
                        list.Add(new CbDataSource { NAME = i.NAME, VALUE = $"{i.ID};{i.PRICE}" });
                    });
                    comboBoxDessert.Invoke(new MethodInvoker(delegate {

                        comboBoxDessert.DataSource = list;
                        comboBoxDessert.DisplayMember = "NAME";
                        comboBoxDessert.ValueMember = "VALUE";
                        comboBoxDessert.SelectedIndex = -1;
                    }));
                }

            }));

            var task4 = Task.Run((async () =>
            {
                using (Model context = new Model())
                {

                    List<CbDataSource> list = new List<CbDataSource>();
                    await context.Drinks.ForEachAsync(i => {
                        list.Add(new CbDataSource { NAME = i.NAME, VALUE = $"{i.ID};{i.PRICE}" });
                    });
                    comboBoxFirstCourse.Invoke(new MethodInvoker(delegate {

                        comboBoxDrink.DataSource = list;
                        comboBoxDrink.DisplayMember = "NAME";
                        comboBoxDrink.ValueMember = "VALUE";
                        comboBoxDrink.SelectedIndex = -1;
                    }));
                }


            }));

            await Task.WhenAll(task1, task2, task3, task4);
            
        }
        private async void OrderForm_Load(object sender, EventArgs e)
        {
            await LoadComboBoxes();
            SystemSounds.Exclamation.Play();
        }

        public decimal GetPrice(ComboBox combo)
        {
            string[] data = combo.SelectedValue.ToString().Split(';');
            return Decimal.Parse(data.Last());
        }

        public int GetID(ComboBox combo)
        {
            string[] data = combo.SelectedValue.ToString().Split(';');
            return int.Parse(data.First());
        }

        public decimal GetSubTotal()
        {
            decimal firstCourse = 0, mainCourse = 0, dessert = 0, drink = 0;

            if (comboBoxFirstCourse.SelectedValue != null)
            {
                firstCourse = GetPrice(comboBoxFirstCourse);
            }
            if (comboBoxMainCourse.SelectedValue != null)
            {
                mainCourse = GetPrice(comboBoxMainCourse);
            }
            if (comboBoxDessert.SelectedValue != null)
            {
                dessert = GetPrice(comboBoxDessert); ;
            }
            if (comboBoxDrink.SelectedValue != null)
            {
                drink = GetPrice(comboBoxDrink);
            }

            return firstCourse + mainCourse + dessert + drink;
        }
        public void SetTotal(ComboBox combo)
        {
            decimal total, itbs, subTotal;

            if (combo.SelectedValue != null)
            {
                subTotal = GetSubTotal();
                itbs = Math.Round((subTotal * 28) / 100, 2);
                total = subTotal + itbs;
                labelSubTotal.Text = subTotal.ToString();
                labelItbis.Text = itbs.ToString();
                labelTotal.Text = total.ToString();
            }
        }
        private void comboBoxFirstCourse_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetTotal(comboBoxFirstCourse);
        }

        private void comboBoxMainCourse_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetTotal(comboBoxMainCourse);

        }

        private void comboBoxDessert_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetTotal(comboBoxDessert);

        }

        private void comboBoxDrink_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetTotal(comboBoxDrink);

        }

        private async void button1_Click(object sender, EventArgs e)
        {

            string name = txtClientName.Text;
            bool validate = decimal.Parse(labelTotal.Text) > 1 ? true : false;

            if (!String.IsNullOrEmpty(name))
            {
                if (validate)
                {
                    await Task.Run(async () => {
                        using (Model context = new Model())
                        {
                            Orders data = new Orders();
                            data.CLIENTE_NAME = name;
                            data.STATES = 1;
                            data.CREATE_DATE = DateTime.Now;

                            this.Invoke(new MethodInvoker(delegate {

                                data.ITBIS = decimal.Parse(labelItbis.Text);
                                data.SUB_TOTAL = decimal.Parse(labelSubTotal.Text);
                                data.TOTAL = decimal.Parse(labelTotal.Text);

                                if (comboBoxFirstCourse.SelectedValue != null)
                                {
                                    data.FIRST_COURSE = GetID(comboBoxFirstCourse);
                                }
                                if (comboBoxMainCourse.SelectedValue != null)
                                {
                                    data.MAIN_COURSE = GetID(comboBoxMainCourse);
                                }
                                if (comboBoxDessert.SelectedValue != null)
                                {
                                    data.DESSERTS = GetID(comboBoxDessert);
                                }
                                if (comboBoxDrink.SelectedValue != null)
                                {
                                    data.DRINKS = GetID(comboBoxDrink);
                                }
                            }));
                            
                            context.Orders.Add(data);
                            await context.SaveChangesAsync();
                        }
                    });

                    Clear(true);
                    MessageBox.Show("Order created", "successful");
                    this.Hide();
                    await MenuPointOfSale.LoadDataGrigView();
                
                }
                else
                {
                    MessageBox.Show("The order can't be emtpy");
                }
            }
            else
            {
                MessageBox.Show("Must complet NAME FIELD");
                txtClientName.Focus();
            }
        }
        public void Clear(bool all)
        {
            if (all)
            {
                txtClientName.Clear();
            }
            comboBoxDessert.SelectedIndex = -1;
            comboBoxDrink.SelectedIndex = -1;
            comboBoxFirstCourse.SelectedIndex = -1;
            comboBoxMainCourse.SelectedIndex = -1;
            labelItbis.Text = "0.0";
            labelTotal.Text = "0.0";
            labelSubTotal.Text = "0.0";
        }

   

        private void button2_Click(object sender, EventArgs e)
        {
            Clear(false);
        }
    }
}
