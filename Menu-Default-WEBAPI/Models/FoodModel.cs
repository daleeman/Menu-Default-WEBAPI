using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Menu_Default_WEBAPI.Models
{
    [Table("Food")]
    public class FoodModel
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid CategoryId { get; set; }
        [Required]
        public string FoodTitle { get; set; }
        [Required]
        public string FoodDescription { get; set; }
        [Required]
        public int Price { get; set; }
        [JsonIgnore]
        [ForeignKey("CategoryId")]
        public virtual CategoryModel? Categorys{ get; set; }
    }
}
