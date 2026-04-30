using HouseRentingSystem.Data;
using HouseRentingSystem.Services.DTOs;
using HouseRentingSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Services.Implementations
{
    public class HouseService : IHouseService
    {
        private readonly HouseRentingDbContext context;
        public HouseService()
        {
            context = new HouseRentingDbContext();
        }
        public async Task<IEnumerable<HouseViewModel>> GetHouseServices(string userId)
        {
            var result = await context.Houses
                   .Select(h => new HouseViewModel()
                   {
                       Id = h.Id,
                       Name = h.Title,
                       Address = h.Address,
                       ImageUrl = h.ImageUrl
                   })
                   .ToListAsync();
            return result;
        }

       
    }
}
