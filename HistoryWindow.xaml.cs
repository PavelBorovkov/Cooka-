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

namespace Cooka_Контроль
{
    /// <summary>
    /// Логика взаимодействия для HistoryWindow.xaml
    /// </summary>
    public partial class HistoryWindow : Window
    {
        AppContext DB;
        
        public HistoryWindow(AppContext DB)
        {
            

            this.DB = DB;
            InitializeComponent();

            List<Order> orders = DB.Orders.ToList();
            foreach (Order item in orders)
            {
                HistoryBox.Text += item.Data+"\n" + "Заказ: " + item.OrderNumber + "\n Стоимость: " + item.OrderPrice + "\n";
                HistoryBox.Text +=item.Products + "\n";
            }
        }

        private void ClearHistory_Click(object sender, RoutedEventArgs e)
        {

            List<Pizza> pizzas = DB.Pizzas.ToList();
            foreach (Pizza item in pizzas)
            {
                Pizza p = DB.Pizzas.FirstOrDefault(x => x.Id == item.Id);
                if (p != null && p.Sell!=0)
                {
                    p.Sell = 0;
                    DB.SaveChanges();
                }

            }
            DB.Orders.RemoveRange(DB.Orders.ToList());
            DB.SaveChanges();
            HistoryBox.Text = "";
        }
    }
}
