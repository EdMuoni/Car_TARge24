using Car_TARge24.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Car_TARge24.Data
{
    public class Car_TARge24Context : DbContext  
    {
        public Car_TARge24Context(DbContextOptions<Car_TARge24Context> options)
            : base(options)
        {  }

        public DbSet<Cars> Cars { get; set; }
    }
}