using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations;

namespace SPC
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        public string? Name { get; set; }

        public List<ProductModel> Products { get; set; } = new List<ProductModel>();
    }
}