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
            builder.HasOne(h => h.Category)
                 .WithMany(c => c.Houses)
                 .HasForeignKey(h => h.CategoryId)
                 .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(h => h.Agent)
                .WithMany(a => a.Houses)
                .HasForeignKey(h =>  h.AgentId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasData(SeedHouses());

            builder.HasQueryFilter(h => h.IsDeleted == false);

        }
        private IEnumerable<House> SeedHouses()
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
