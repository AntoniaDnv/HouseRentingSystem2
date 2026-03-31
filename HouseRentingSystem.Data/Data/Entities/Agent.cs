using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Data.Data.DataConstants.Agent;


namespace HouseRentingSystem.Data.Data.Entities
{
    public class Agent
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; }
        [Required]
        public string UserId { get; set; } = null!;
        public ApplicationUser User { get; set; }
        public IEnumerable<House> ManagedHouses { get; set; } = new List<House>();  
    }
}
