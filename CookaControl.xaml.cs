using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Net.WebRequestMethods;

namespace Cooka_Контроль
{
    /// <summary>
    /// Логика взаимодействия для CookaControl.xaml
    /// </summary>
    public partial class CookaControl : Window
    {
        AppContext DB;
        int summ = 0;

        public CookaControl()
        {
            InitializeComponent();
            DB = new AppContext();

            List<Pizza> pizzas = DB.Pizzas.ToList();
            ListOfPizzas.ItemsSource = pizzas;

            List<Order> orders = DB.Orders.ToList();
            
            foreach (Order item in orders.Where(item => item.Data == DateTime.Now.ToString("d")))
            {
                OrderList.Text +=" "+ "Заказ: " + item.OrderNumber +"\n Стоимость: "+item.OrderPrice+ "\n";
                OrderList.Text += new string(' ', 6) + item.Products+"\n";
            }

            



            //List<Order> orders = DB.Orders.ToList();   
            //ListOfOrders.ItemsSource = orders.Where(item=> item.Data== DateTime.Now.ToString("d"));
        }


        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Pizza AddPizza=(Pizza)button.Tag;
            ListOfOrder.Items.Add(AddPizza);
            summ += AddPizza.PizzaPrice;
            Summ.Text=summ.ToString();
        }

        private void DellItem_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Pizza DellPizza = (Pizza)button.Tag;
            ListOfOrder.Items.Remove(DellPizza);
            summ -= DellPizza.PizzaPrice;
            Summ.Text=summ.ToString();
        }

        private void SetOrder_Click(object sender, RoutedEventArgs e)
        {
            if (ListOfOrder.HasItems ==true)
            {
                int ordernumber;
                string products = "";
                var LastNumber = DB.Orders.OrderByDescending(item => item.OrderNumber).FirstOrDefault();
                if (LastNumber == null)
                {
                    ordernumber = 1;
                }
                else ordernumber = LastNumber.OrderNumber + 1;
                string currentDate = DateTime.Now.ToString("d");



                foreach (Pizza item in ListOfOrder.Items)
                {
                    products += new string(' ', 6) + item.PizzaName + " " + item.PizzaSize + "см " + item.PizzaPrice + "руб\n";
                    //Order order= new Order(currentDate,ordernumber, item.PizzaName, item.PizzaSize, item.PizzaPrice, int.Parse(Summ.Text));
                    //DB.Orders.Add(order);
                    //DB.SaveChanges();
                    //OrderList.Text +=new string(' ',6) + item.PizzaName + " " + item.PizzaSize+"\n";
                }
                OrderList.Text += " Заказ: " + ordernumber + "\n Стоимость: " + int.Parse(Summ.Text) + "\n" + products;

                if (StreetBox.Text != null)
                {
                    string address = StreetBox.Text + " " + HouseBox.Text + ". подьезд: " + FontDoorBox.Text + " кв: " + ApartmentBox.Text;
                    Order order = new Order(currentDate, ordernumber, products, int.Parse(Summ.Text), address);
                    DB.Orders.Add(order);
                    DB.SaveChanges();
                }
                else
                {
                    Order order = new Order(currentDate, ordernumber, products, int.Parse(Summ.Text));
                    DB.Orders.Add(order);
                    DB.SaveChanges();
                }
                Summ.Text = "0";
                summ = 0;

                ListOfOrder.Items.Clear();
                //List<Order> orders = DB.Orders.ToList();
                //ListOfOrders.ItemsSource = orders.Where(item => item.Data == DateTime.Now.ToString("d"));
            }
            else
            {
                OrderList.Text = "";
                List<Order> orders = DB.Orders.ToList();
                foreach (Order item in orders.Where(item => item.Data == DateTime.Now.ToString("d")))
                {
                    OrderList.Text += " " + "Заказ: " + item.OrderNumber + "\n Стоимость: " + item.OrderPrice + "\n";
                    OrderList.Text +=item.Products + "\n";
                }
            }
        }

        private void SourceItem_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow=new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void History_Click(object sender, RoutedEventArgs e)
        {
            HistoryWindow historyWindow= new HistoryWindow();
            historyWindow.Show();
        }

        private void StatiPizzas_Click(object sender, RoutedEventArgs e)
        {
            StatPizzas statPizzas = new StatPizzas();
            statPizzas.Show();
        }

        private void StatiDays_Click(object sender, RoutedEventArgs e)
        {
            StatDays statDays = new StatDays();
            statDays.Show();
        }
    }
}
