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
                .Select(x => new CarIndexViewModel
                {
                    Id = x.Id,
                    Brand = x.Brand,
                    Model = x.Model,
                    EnginePower = x.EnginePower,
                    Year = x.Year,
                    FuelConsumption = x.FuelConsumption,
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
            var dto = new CarDto()
            {
                Brand = vm.Brand,
                Model = vm.Model,
                Color = vm.Color,
                EnginePower = vm.EnginePower,
                Year = vm.Year,
                FuelConsumption = vm.FuelConsumption,
            };
            var result = await _carServices.Create(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var cars = await _carServices.DetailAsync(id);

            if (cars == null)
            {
                return NotFound();
            }
            var vm = new CarCreateUpdateViewModel();
            {
                vm.Id = cars.Id;
                vm.Brand = cars.Brand;
                vm.Model = cars.Model;
                vm.Color = cars.Color;
                vm.EnginePower = cars.EnginePower;
                vm.Year = cars.Year;
                vm.FuelConsumption = cars.FuelConsumption;

                return View("CreateUpdate", vm);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(CarCreateUpdateViewModel vm)
        {
            var dto = new CarDto()
            {
                Id = vm.Id,
                Brand = vm.Brand,
                Model = vm.Model,
                Color = vm.Color,
                EnginePower = vm.EnginePower,
                Year = vm.Year,
                FuelConsumption = vm.FuelConsumption,
            };
            var result = await _carServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var cars = await _carServices.DetailAsync(id);

            if (cars == null)
            {
                return NotFound();
            }
            var vm = new CarIndexViewModel();
            {
                vm.Id = cars.Id;
                vm.Brand = cars.Brand;
                vm.Model = cars.Model;
                vm.Color = cars.Color;
                vm.EnginePower = cars.EnginePower;
                vm.Year = cars.Year;
                vm.FuelConsumption = cars.FuelConsumption;
                return View(vm);
            }
        }
    }
}
