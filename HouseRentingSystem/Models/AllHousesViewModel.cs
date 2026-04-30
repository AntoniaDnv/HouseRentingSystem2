using HouseRentingSystem.Services.DTOs;

namespace HouseRentingSystem.Models
{
    public class AllHousesViewModel
    {
        public AllHousesQueryModel Query { get; set; }
        public List<HouseViewModel> Houses { get; set; }
    }
}
