using HouseRentingSystem.Data;
using HouseRentingSystem.Data.Data.Entities;
using HouseRentingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Controllers
{
    public class HouseController : Controller
    {
        private readonly HouseRentingDbContext context;

        public HouseController(HouseRentingDbContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> AllHouses()
        {
            var housesModel = await context.Houses
                .Select(h => new HouseViewModel()
                {
                    Id = h.Id,
                    Name = h.Title,
                    Address = h.Address,
                    ImageUrl = h.ImageUrl
                })
                .ToListAsync();

            return View(housesModel);
        }

        public async Task<IActionResult> HouseById(int id)
        {
            var house = await context.Houses
                .Where(h => h.Id == id)
                .Select(h => new HouseViewModel()
                {
                    Id = h.Id,
                    Name = h.Title,
                    Address = h.Address,
                    ImageUrl = h.ImageUrl
                })
                .FirstOrDefaultAsync();

            if (house == null)
            {
                return NotFound();
            }

            return View(house);
        }

        [HttpGet]
        public IActionResult CreateHouse()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateHouse(CreateHouseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var houseEntity = new House()
            {
                Title = model.Title,
                Description = model.Description,
                Address = model.Address,
                ImageUrl = model.ImageUrl
            };

            await context.Houses.AddAsync(houseEntity);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(AllHouses));
        }
        public async Task<IActionResult> Details(int id)
        {
            var house = context.Houses
            .AsNoTracking()
            .FirstOrDefault(h => h.Id == id);
            var model = new HouseDetailViewModel()
            {
                Id = house.Id,
                Address = house.Address,
                Description = house.Description,
                CreatedBy = house.Agent.UserName,
                ImageUrl = house.ImageUrl,
                Price = house.PricePerMonth,
                Name = house.Title
            };
            return View(model);
        }
    }
}