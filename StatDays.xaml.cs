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
        public StatDays()
        {
            InitializeComponent();
            DB = new AppContext();
            string currentDate = DateTime.Now.ToString("d");
            int sum = 0;
            List<Order> orders = DB.Orders.ToList();
            foreach (Order item in orders)
            {
                if(item.Data==currentDate) 
                {
                    sum += item.OrderPrice;
                }
                else
                {
                    Stati.Text += currentDate+" "+sum+" руб";
                    sum = item.OrderPrice;
                    currentDate = item.Data;
                }
            }
        }
    }
}
