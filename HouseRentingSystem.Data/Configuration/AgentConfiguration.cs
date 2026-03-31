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
    public class AgentConfiguration : IEntityTypeConfiguration<Agent>
    {
       
        

        public void Configure(EntityTypeBuilder<Agent> builder)
        {
          //  builder.HasData(SeedCategories());
        }
/*
        private IEnumerable<Agent> SeedCategories()
        {
            return new Agent[]
            {
                new Agent
                {
                    Id = 1,
                    PhoneNumber = "09999999",
                    UserId = "ejejejej"
                },
                new Agent
                {
                    Id = 2,
                    PhoneNumber = "888888888",
                    UserId = "hdhhhd"
                }
            };
        }
        */
    }
}
