using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SPC
{
    public class ProductModel
    {
        [Key]
        public int ProductId { get; set; }
        public string? Model { get; set; }
        public string? BatchNumber { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
