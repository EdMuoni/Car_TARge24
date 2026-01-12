using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Car_TARge24.Core.Domain;
using Car_TARge24.Core.Dto;
using Car_TARge24.Data;
using Car_TARge24.Models.Cars;
using Car_TARge24.Core.ServiceInterface;

namespace Car_TARge24.Controllers

{
    public class CarsController: Controller
    {

        private readonly Car_TARge24Context _context;
        private readonly ICarServices _carServices;

    }
}
