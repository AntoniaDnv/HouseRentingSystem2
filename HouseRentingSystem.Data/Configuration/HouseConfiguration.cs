using HouseRentingSystem.Data.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Data.Configuration
{
    public class HouseConfiguration : IEntityTypeConfiguration<House>
    {
        public void Configure(EntityTypeBuilder<House> builder)
        {
           // builder.HasData(SeedCategories());
        }
        private IEnumerable<House> SeedCategories()
        {
            return new House[]
            {
                new House
                {
                    Id = 1,
                    Title = "Test",
                    Address = "Test",
                    Description = "Test",
                    ImageUrl = "Test",
                    PricePerMonth = 1000,
                    CategoryId = 1,
                    AgentId = "b449b516-b53b-4659-8216-2d5dfb944db9"
                }
            };
        }
    }
}
