using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Menu_Default_WEBAPI.Models
{
    public class CategoryModel
    {
        
        [Required]
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string? CategoryName { get; set; }
        public virtual List<FoodModel>? Foods { get; set; }
    }
}
