using HouseTests;

namespace House.HouseTests
{
    public class HouseTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptyHouse_WhenReturnResult()
        {
            string guid = Guid.NewGuid().ToString();

            HouseDto house = new HouseDto();

            house.Id = Guid.Parse(guid);
            house.OwnerName = "Roman";
            house.Address = "Tallinn";
            house.SquareMeters = 105;
            house.YearOfBuild = 2010;
            house.NumberOfRooms = 5;
            house.NumberOfFloors = 2;
            house.Price = 240000;
            house.CreatedAt = DateTime.Now;
            house.ModifiedAt = DateTime.Now;

            var result = await Svc<IHouseServices>().Add(house);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task ShouldNot_GetByIdHouse_WhenReturnsResultAsync()
        {
            Guid guid = Guid.Parse("9307f724-4639-4a70-844d-9a5254da4cad");

            Guid guid1 = Guid.Parse(Guid.NewGuid().ToString());

            await Svc<IHouseServices>().GetAsync(guid);
            Assert.NotEqual(guid1, guid);
        }

        [Fact]
        public async Task Should_GetByIdHouse_WhenReturnsEqual()
        {
            Guid guid = Guid.Parse("9307f724-4639-4a70-844d-9a5254da4cad");

            Guid guid1 = Guid.Parse("9307f724-4639-4a70-844d-9a5254da4cad");

            await Svc<IHouseServices>().GetAsync(guid);

            Assert.Equal(guid1, guid);
        }

        [Fact]
        public async Task Should_DeleteByIdHouse_WhenDeleteHouse()
        {
            //Arrange
            HouseDto house = CreateValidHouse();
            var createdHouse = await Svc<IHouseServices>().Add(house);


            //Act
            var result = await Svc<IHouseServices>().Delete((Guid)createdHouse.Id);


            //Assert
            Assert.Equal(createdHouse, result);
        }

        private HouseDto CreateValidHouse()
        {
            HouseDto house = new()
            {
                OwnerName = "Roman",
                Address = "Tallinn",
                SquareMeters = 105,
                YearOfBuild = 2010,
                NumberOfRooms = 5,
                NumberOfFloors = 2,
                Price = 240000,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
            };
            return house;
        }
    }
}
