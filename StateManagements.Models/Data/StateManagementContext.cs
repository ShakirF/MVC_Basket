using Microsoft.EntityFrameworkCore;
using StateManagements.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateManagements.Models.Data
{
    public class StateManagementContext : DbContext
    {
        public StateManagementContext(DbContextOptions<StateManagementContext> options ) : base(options)
        {

        }
       public DbSet<Category> Categories { get; set; }
       public DbSet<Product> Products { get; set; }
        public DbSet<Food> Foods { get; set; }
    }
}
