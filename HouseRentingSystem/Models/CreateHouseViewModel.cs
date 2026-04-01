using System.ComponentModel.DataAnnotations;

namespace HouseRentingSystem.Models
{
    public class CreateHouseViewModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 10)]
        public string Description { get; set; }

        [Required]
        [Range(0, 1000000)]
        public decimal Price { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }
    }
}
