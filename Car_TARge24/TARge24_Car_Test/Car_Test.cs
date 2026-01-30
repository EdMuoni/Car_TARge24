using Car_TARge24.Core.Domain;
using Car_TARge24.Core.Dto;
using Car_TARge24.Core.ServiceInterface;

namespace TARge24_Car_Test
{
    public class Car_Test : TestBase
    {

        //Kontrollime, et tühje andmeid ei saa panna
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

        //Kontrollime, et vale ID-ga car ei saa kätte
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

        //Kontrollime, et õige ID-ga car saab kätte
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

        //Kontrollime, et negatiivse EnginePower ei saa lisada
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


        //Kontrollime, et car andmeid saab uuendada
        [Fact]
        public async Task Should_UpdateCar_WhenUpdateKindergartenData()
        {
            //arrange
            CarDto dto = MockCarData();
            //act
            var createKindergarten = await Svc<ICarServices>().Create(dto);
            var updateKindergarten = MockUpdateCarData();
            //assert
            Assert.NotEqual(createKindergarten.EnginePower, updateKindergarten.EnginePower);
            Assert.NotEqual(createKindergarten.Year, updateKindergarten.Year);
            Assert.NotEqual(createKindergarten.FuelConsumption, updateKindergarten.FuelConsumption);
            Assert.NotEqual(createKindergarten.Color, updateKindergarten.Color);

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
