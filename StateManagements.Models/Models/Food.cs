using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateManagements.Models.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Price { get; set; }
        public string? Src { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
