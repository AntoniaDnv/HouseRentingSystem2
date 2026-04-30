using HouseRentingSystem.Data.Data.Entities;

namespace HouseRentingSystem.Models
{
    public class AllHousesQueryModel
    {
        public int? CategoryId { get; set; }

        public string SearchText { get; set; }

        public string SortingType { get; set; }


    }
}
