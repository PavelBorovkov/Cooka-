using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Cooka_Контроль
{
    public class AppContext:DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        
        public AppContext() :base("DefaultConnection") { }
    }
}
