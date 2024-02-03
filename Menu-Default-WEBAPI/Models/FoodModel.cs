using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Menu_Default_WEBAPI.Models
{
    public class FoodModel
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "CategoryId is Required.")]
        [ForeignKey("CategoryId")]
        public Guid CategoryId { get; set; }
        [Required]
        public string FoodTitle { get; set; }
        [Required]
        public string FoodDescription { get; set; }
        public int Price { get; set; }
    }
}
