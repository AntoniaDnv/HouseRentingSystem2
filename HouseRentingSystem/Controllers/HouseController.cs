using HouseRentingSystem.Models;
using Microsoft.AspNetCore.Mvc;

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
		public IActionResult AllHouses()
		{
			return View(houses);
		}

		public IActionResult Details(int id)
		{
			return View(houses.FirstOrDefault(h => h.Id == id));
		}

	}
}
