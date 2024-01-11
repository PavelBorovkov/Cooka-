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
    /// Логика взаимодействия для StatDays.xaml
    /// </summary>
    public partial class StatDays : Window
    {
        AppContext DB;
        public StatDays(AppContext DB)
        {
            InitializeComponent();
            this.DB = DB;
            string currentDate = DateTime.Now.ToString("d");
            int sum = 0;
            List<Order> orders = DB.Orders.ToList();

            foreach (Order item in orders)
            {
                if (orders.Count == item.OrderNumber && item.Data == currentDate)
                {
                    sum += item.OrderPrice;
                    Stati.Text += currentDate + " " + sum + " руб\n";
                }
                if (item.Data == currentDate)
                {
                    sum += item.OrderPrice;
                }
                
                else
                {
                    Stati.Text += currentDate + " " + sum + " руб\n";
                    sum = item.OrderPrice;
                    currentDate = item.Data;
                }
            }
        }
    }
}
