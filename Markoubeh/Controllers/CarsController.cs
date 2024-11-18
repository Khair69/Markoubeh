﻿using Markoubeh.Models;
using Markoubeh.Services;
using Microsoft.AspNetCore.Mvc;

namespace Markoubeh.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarsService _carsService;

        public CarsController(ICarsService carsService)
        {
            _carsService = carsService;
        }

        public async Task<IActionResult> Index()
        {
            var cars = await _carsService.GetAvailableCarsAsync();

            var model = new CarViewModel()
            {
                cars = cars
            };

            return View(model);
        }

        public IActionResult AddCarForm()
        { 
            return View();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCar(Car newCar)
        {
            if (!ModelState.IsValid) return BadRequest("You Are Missing Info");

            var successful = await _carsService.AddCarAsync(newCar);
            if (!successful) return BadRequest("Could Not Add Car xD");

            return RedirectToAction("AddCarForm");
        }

        public async Task<IActionResult> CarDetails(Guid carID)
        {
            Console.WriteLine(carID);
            var currCar = await _carsService.GetCarByIdAsync(carID);
            Console.WriteLine(currCar.manufacture);

            return View(currCar);
        }
    }
}
