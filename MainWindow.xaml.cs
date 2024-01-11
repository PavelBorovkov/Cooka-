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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cooka_Контроль
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AppContext DB;
        public MainWindow()
        {
            InitializeComponent();
            DB= new AppContext();

            List<Pizza> pizzas= DB.Pizzas.ToList();
            ListOfPizzas.ItemsSource = pizzas;
        }

        private void SetItem_Click(object sender, RoutedEventArgs e)
        {
            Pizza pizza = new Pizza(SetName.Text,int.Parse(SetSize.Text),int.Parse(SetPrice.Text), 0);
            DB.Pizzas.Add(pizza);
            DB.SaveChanges();
            SetName.Clear();
            SetSize.SelectedIndex = -1;
            SetPrice.Clear();
            ListOfPizzas.ItemsSource = DB.Pizzas.ToList();
        }

        private void DeletItem_Click(object sender, RoutedEventArgs e)
        {
            Button button =(Button)sender;
            Pizza selectedPizza = (Pizza)button.Tag;
            if (selectedPizza != null )
            {
                DB.Pizzas.Remove(selectedPizza);
                DB.SaveChanges();
            }
            ListOfPizzas.ItemsSource = DB.Pizzas.ToList();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            CookaControl cooka = new CookaControl();
            cooka.Show();
            this.Close();
        }
    }
}
