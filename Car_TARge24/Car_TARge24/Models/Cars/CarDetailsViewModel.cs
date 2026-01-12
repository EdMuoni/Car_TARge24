namespace Car_TARge24.Models.Cars
{
    public class CarDetailsViewModel
    {
        public Guid? Id { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string? Color { get; set; }
        public int? EnginePower { get; set; }
        public int? Year { get; set; }
        public int? FuelConsumption { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.MinValue;
        public DateTime? UpdatedAt { get; set; } = DateTime.MinValue;
    }
}
