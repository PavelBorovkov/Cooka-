﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Cooka_Контроль
{
    public class Pizza
    {
        public int Id {  get; set; }
        private string pizzaname;
        private int pizzasize, pizzaprice, sell;

        public string PizzaName
        {
            get { return pizzaname; }
            set { pizzaname = value; }
        }
        public int PizzaSize
        {
            get { return pizzasize; }
            set { pizzasize = value; }
        }
        public int PizzaPrice
        {
            get { return pizzaprice; }
            set { pizzaprice = value; }
        }
        public int Sell
        {
            get { return sell; }
            set { sell = value; }
        }
        public Pizza() { }
        public Pizza(string pizzaname, int pizzasize, int pizzaprice, int sell)
        {
            this.pizzaname = pizzaname;
            this.pizzasize = pizzasize;
            this.pizzaprice = pizzaprice;
            this.sell = sell;
        }

        //public override string ToString()
        //{
        //    return pizzaname+" "+pizzasize+"см "+pizzaprice+"руб";
        //}
    }
}
