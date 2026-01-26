using Car_TARge24.Core.Domain;
using Car_TARge24.Core.Dto;
using Car_TARge24.Core.ServiceInterface;
using Car_TARge24.Data;
using Microsoft.EntityFrameworkCore;

namespace Car_TARge24.ApplicationServices.Services
{
    public class CarServices : ICarServices
    {
        private readonly Car_TARge24Context _context;

        public CarServices(Car_TARge24Context context)
        {
            _context = context;
        }

        public async Task<Cars> Create(CarDto dto)
        {
            Cars cars = new Cars();

            cars.Id = Guid.NewGuid();
            cars.Brand = dto.Brand;
            cars.Model = dto.Model;
            cars.Color = dto.Color;
            cars.EnginePower = dto.EnginePower;
            cars.Year = dto.Year;
            cars.FuelConsumption = dto.FuelConsumption;
            cars.CreatedAt = DateTime.Now;
            cars.UpdatedAt = DateTime.Now;

            await _context.Cars.AddAsync(cars);
            await _context.SaveChangesAsync();

            return cars;
        }

        public async Task<Cars> Update(CarDto dto)
        {
            var cars = await _context.Cars.FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (cars == null) return null;

            cars.Brand = dto.Brand;
            cars.Model = dto.Model;
            cars.Color = dto.Color;
            cars.EnginePower = dto.EnginePower;
            cars.Year = dto.Year;
            cars.FuelConsumption = dto.FuelConsumption;
            cars.CreatedAt = DateTime.Now;
            cars.UpdatedAt = DateTime.Now;

            _context.Cars.Update(cars);
            await _context.SaveChangesAsync();

            return cars;
        }

        public async Task<Cars> DetailAsync(Guid id)
        {
            var result = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<Cars> Delete(Guid id)
        {
            var result = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);
            _context.Cars.Remove(result);

            await _context.SaveChangesAsync();

            return result;
        }
    }
}
