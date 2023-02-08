﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateManagements.Models.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        [Column(TypeName = "decimal(12, 2)")]
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }

        public string? MainImage { get; set; }
        public string? OverlayImage { get; set; }
        public string? Kind { get; set; }
        public int? CategoryID { get; set; }
        public Category? Category { get; set; }
    }
}
