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
    /// Логика взаимодействия для StatPizzas.xaml
    /// </summary>
    public partial class StatPizzas : Window
    {
        AppContext DB;
        public StatPizzas(AppContext DB)
        {
            InitializeComponent();
            this.DB = DB;
            
            List<Pizza> pizzas = DB.Pizzas.ToList();
            //List<Order> orders = DB.Orders.ToList();

            foreach (Pizza pizza in pizzas)
            {
                Stati.Text += pizza.PizzaName + " " + pizza.PizzaSize+"   "+pizza.Sell+"шт"+"\n";   
            }
            pizzas.Clear();
        }
    }
}
