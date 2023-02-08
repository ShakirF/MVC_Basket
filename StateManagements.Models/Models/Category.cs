using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateManagements.Models.Models
{
    public class Category
    {
      
    public Category()
    {
        this.Products = new HashSet<Product>();
            this.Foods = new HashSet<Food>();
    }

    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

        public virtual ICollection<Food>? Foods { get; set; }
        public virtual ICollection<Product>? Products { get; set; }

    }
}
