using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Car_TARge24.Core.Domain;
using Car_TARge24.Core.Dto;
using Car_TARge24.Data;
using Car_TARge24.Models.Cars;
using Car_TARge24.Core.ServiceInterface;

namespace Car_TARge24.Controllers

{
    public class CarsController : Controller
    {

        private readonly Car_TARge24Context _context;
        private readonly ICarServices _carServices;

        public CarsController
            (
             Car_TARge24Context context,
             ICarServices carServices
            )
        {
            _context = context;
            _carServices = carServices;
        }

        public IActionResult Index()
        {
            var result = _context.Cars
                .Select(x => new CarViewModel
                {
                    Id = x.Id,
                    Brand = x.Brand,
                    Model = x.Model,
                    EnginePower = x.EnginePower,
                    Year = x.Year,
                });

            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CarCreateUpdateViewModel result = new();

            return View("CreateUpdate", result);
        }

        [HttpPost]

        public async Task<IActionResult> Create(CarCreateUpdateViewModel vm)
        {
            CarDto dto = new()
            {
                Brand = vm.Brand,
                Model = vm.Model,
                Color = vm.Color,
                EnginePower = vm.EnginePower,
                Year = vm.Year,
                FuelConsumption = vm.FuelConsumption,
            };
            await _carServices.Create(dto);
            return RedirectToAction("Index");
        }
}
