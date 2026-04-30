using HouseRentingSystem.Data;
using HouseRentingSystem.Data.Data.Entities;
using HouseRentingSystem.Models;
using HouseRentingSystem.Services.DTOs;
using HouseRentingSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HouseRentingSystem.Controllers
{
    public class HouseController : Controller
    {
        private readonly HouseRentingDbContext context;
        //private readonly IConfiguration config;
        private readonly IHouseService houseService;

        public HouseController(HouseRentingDbContext context,  IHouseService houseService)
        {
            this.context = context;
          //  this.config = config;
            this.houseService = houseService;   
        }

        [HttpGet]
        public async Task<IActionResult> AllHouses([FromQuery] AllHousesQueryModel model)
        {
            
            if(ModelState.IsValid == false && model.CategoryId != null)
            {
                return BadRequest();
            }
            var houses = context.Houses
                .Where(h => h.Description.Contains(model.SearchText));
            if(model.CategoryId != 0)
            {
                houses.Where(h => h.Description.Contains(model.SearchText));
            }
            if(model.SortingType == "Desc")
            {
                houses.OrderByDescending(h => h.Title);
            }
            else
            {
                houses.OrderBy(h => h.Title);   
            }
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

               

            return View(model);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> MyHouses()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var houses = await houseService.GetHouseServices(userId);
            ViewBag.Title = "My Houses";
            var model = new AllHousesViewModel()
            {
                Houses = houses.ToList()
            };

            return View(nameof(AllHouses), model);
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