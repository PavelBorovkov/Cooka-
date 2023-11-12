using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooka_Контроль
{
    public class Order
    {
        public int Id { get; set; }
        private string products, data, address;
        private int ordernumber, orderprice;

        public string Products
        {
            get { return products; }
            set { products = value; }
        }
        public string Data
        {
            get { return data; }
            set { data = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public int OrderNumber
        {
            get { return ordernumber; }
            set { ordernumber = value; }
        }
        public int OrderPrice
        {
            get { return orderprice; }
            set { orderprice = value; }
        }
        public Order() { }
        public Order(string data, int ordernumber , string products, int orderprice, string address)
        {
            this.data = data;
            this.ordernumber = ordernumber;
            this.products = products;
            this.orderprice = orderprice;
            this.address = address;
        }
        public Order(string data, int ordernumber, string products, int orderprice)
        {
            this.data = data;
            this.ordernumber = ordernumber;
            this.products = products;
            this.orderprice = orderprice;
        }
    }
}
