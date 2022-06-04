using Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class MotorcycleShopDb:DbContext
    {
        public MotorcycleShopDb()
             : base(@"Data Source=.;Initial Catalog=MotorcycleDb;Integrated Security=SSPI;")
        { }
       

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Motorcycle> Motorcycles { get; set; }
        public DbSet<Sale> Sales { get; set; }
    }
}
