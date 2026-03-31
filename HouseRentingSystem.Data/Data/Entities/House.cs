using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HouseRentingSystem.Data.Data.DataConstants.House;
namespace HouseRentingSystem.Data.Data.Entities
{
    public class House
    {
        [Key]
        public int Id { get; init; }
       
        [MaxLength(TitleMaxLength)]
        [Required]
        public string Title { get; set; } = null!;
       
        [MaxLength(AddressMaxLength)]
        [Required]
        public string Address { get; set; } = null!;
        [MaxLength(DescriptionMaxLength)]
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        
   
        public string ImageUrl { get; set; } = null!;
        [MaxLength(2000)]
        [Required]
        [Column(TypeName = "decimal(12, 3)")]

        public decimal PricePerMonth { get; set; }
        [Required]
        [ForeignKey(nameof(Category))]
        
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Required]
        [ForeignKey(nameof(Agent))]
        public Guid AgentId { get; set; }
        public Agent Agent { get; set; }

        public string? RenterId { get; set; }
        public ApplicationUser? Renter { get; set; }
       


    }
}
