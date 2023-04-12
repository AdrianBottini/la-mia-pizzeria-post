using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace la_mia_pizzeria_static.Models
{
    public class PizzeriaContext : DbContext
    {
        public DbSet<Pizza>? Pizzas { get; set; }

        public PizzeriaContext(DbContextOptions<PizzeriaContext> options)
         : base(options)
        {
        }

        public void Seed()
        {
            if (!Pizzas.Any())
            {
                var margherita = new Pizza("Margherita", "Mozzarella e pomodoro", "/img/margherita.jfif", 5.00);
                var diavola = new Pizza("Diavola", "Mozzarella, pomodoro e salame piccante", "/img/diavola.jfif", 6.00);
                var quattroStagioni = new Pizza("Quattro Stagioni", "Mozzarella e pomodoro e un altro po' di roba", "/img/quattro_stagioni.jfif", 7.50);
                var salsicciosa = new Pizza("Salsicciosa", "Mozzarella, patate e salsiccia", "/img/salsicciosa.jfif", 8.00);
                var pizze = new List<Pizza>() { margherita, diavola, quattroStagioni, salsicciosa };
                Pizzas.AddRange(pizze);
                SaveChanges();
            }
        }
    }
}
