using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Menu_Default_WEBAPI.Models
{
    [Table("Category")]
    public class CategoryModel
    {
        
        [Required]
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string CategoryName { get; set; }
        [JsonIgnore]
        public virtual List<FoodModel>? Foods { get; set; }
    }
}
