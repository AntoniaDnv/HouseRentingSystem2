using HouseRentingSystem.Data;
using HouseRentingSystem.Data.Data.Entities;
using HouseRentingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Controllers
{
	public class HouseController : Controller
	{
		private List<HouseViewModel> houses = new List<HouseViewModel>()
		{
			new HouseViewModel()
			{   Id = 1,
				Name = "Beach house",
				Address = "Miami, Florida",
				ImageUrl = @"https://i.ytimg.com/vi/Y4gLQQrKf1E/hq720.jpg?sqp=-oaymwEhCK4FEIIDSFryq4qpAxMIARUAAAAAGAElAADIQj0AgKJD&rs=AOn4CLDF-Ss8WtuTN_zmjUqGsuJa5rpJIw"
			},
			new HouseViewModel()
			{
				Id=2,
				Name = "Mountain house",
				Address = "Rila Mountain, Bulgaria",
				ImageUrl = @"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR8LkVGvrwA_10W1Jizdesx9DmZeydC1wh5IA&s"
			},
			new HouseViewModel()
			{
				Id=3,
				Name = "Urban House",
				Address = "Lulin, Sofia, Bulgaria",
				ImageUrl = @"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRO3CW-ztFIRbSl2yNpP7LtSBEkZ92ZOaPeDg&s"
			}
		};
        private readonly HouseRentingDbContext context;
        public HouseController(HouseRentingDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> AllHouses()
        {
            var houses = await context.Houses.ToListAsync();
            return View(houses);
        }

        public async Task<IActionResult> HouseById(int id)
        {
            var house = await context.Houses
                .FirstOrDefaultAsync(h => h.Id == id);

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

            var house = new House()
            {
                Title = model.Title,
                Description = model.Description,
                Address = model.Address,
                ImageUrl = model.ImageUrl
            };

            await context.Houses.AddAsync(house);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(AllHouses));
        }

        public IActionResult Details(int id)
		{
			return View(houses.FirstOrDefault(h => h.Id == id));
		}

	}
}
