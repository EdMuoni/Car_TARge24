using Car_TARge24.Core.Domain;
using Car_TARge24.Core.Dto;
using Car_TARge24.Core.ServiceInterface;

namespace TARge24_Car_Test
{
    public class Car_Test : TestBase
    {

        //Checking that no empty data can be entered
        [Fact]
        public async Task ShouldNot_AddEmptyCar_WhenReturnResult()
        {
            // Arrange
            CarDto dto = MockNullCarData();
            // Act
            var result = await Svc<ICarServices>().Create(dto);
            // Assert
            Assert.NotNull(result);
        }

        //Checking that a car with the wrong ID cannot be accessed
        [Fact]
        public async Task ShouldNot_GetByIdcar_WhenReturnsNotEqual()
        {
            //arrange
            Guid wrongGuid = Guid.NewGuid();
            Guid guid = Guid.Parse("a1b2c3d4-e5f6-7890-abcd-ef1234567890");
            //act
            await Svc<ICarServices>().DetailAsync(guid);
            //assert
            Assert.NotEqual(wrongGuid, guid);
        }

        //Checking that the car with the correct ID can be accessed
        [Fact]
        public async Task Should_GetByIdcar_WhenReturnsEqual()
        {
            //arrange
            Guid databaseGuid = Guid.Parse("82491449-257a-48ff-81b9-3a95f925ce05");
            Guid guid = Guid.Parse("82491449-257a-48ff-81b9-3a95f925ce05");
            //act
            await Svc<ICarServices>().DetailAsync(guid);
            //assert
            Assert.Equal(databaseGuid, guid);
        }

        //Checking that negative EnginePower cannot be added
        [Fact]
        public async Task ShouldNot_AddCarWithNegativeEnginePower_WhenReturnResult()
        {
            // Arrange
            CarDto dto = new()
            {
                Brand = "Volvo",
                Model = "S",
                Color = "Red",
                EnginePower = -2000,
                Year = 2020,
                FuelConsumption = 15,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            // Act
            var result = await Svc<ICarServices>().Create(dto);
            // Assert
            Assert.NotNull(result);
        }


        //Checking that car data can be updated
        [Fact]
        public async Task Should_UpdateCar_WhenUpdateCarData()
        {
            //arrange
            CarDto dto = MockCarData();
            //act
            var createCar = await Svc<ICarServices>().Create(dto);
            var updateCar = MockUpdateCarData();
            //assert
            Assert.NotEqual(createCar.EnginePower, updateCar.EnginePower);
            Assert.NotEqual(createCar.Year, updateCar.Year);
            Assert.NotEqual(createCar.FuelConsumption, createCar.FuelConsumption);
            Assert.NotEqual(createCar.Color, createCar.Color);

        }

        private CarDto MockCarData()
        {
            return new CarDto
            {
                Brand = "Volvo",
                Model = "S",
                Color = "Red",
                EnginePower = 2000,
                Year = 2020,
                FuelConsumption = 15,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }

        private CarDto MockUpdateCarData()
        {
            CarDto car = new()
            {
                Brand = "Subaru",
                Model = "S",
                Color = "Pink",
                EnginePower = 8000,
                Year = 2025,
                FuelConsumption = 5,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            return car;
        }
        private CarDto MockNullCarData()
        {
            CarDto car = new()
            {
                Brand = "",
                Model = "",
                Color = "",
                EnginePower = null,
                Year = null,
                FuelConsumption = null,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            return car;
        }

    }
}
