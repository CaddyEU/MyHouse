using House.Core.Domain;
using House.Core.Dto;
using House.Core.ServiceInterface;
using House.Data;
using Microsoft.EntityFrameworkCore;
using Nancy.Routing;

namespace House.ApplicationServices.Services
{
    public class HouseServices : IHouseServices
    {
        private readonly HouseDbContext _context;

        public HouseServices
            (
                HouseDbContext context
            )
        {
            _context = context;
        }

        public async Task<HouseDomain> Add(HouseDto dto)
        {
            HouseDomain house = new HouseDomain();

            house.Id = dto.Id;
            house.OwnerName = dto.OwnerName;
            house.Address = dto.Address;
            house.SquareMeters = dto.SquareMeters;
            house.YearOfBuild = dto.YearOfBuild;
            house.NumberOfRooms = dto.NumberOfRooms;
            house.NumberOfFloors = dto.NumberOfFloors;
            house.Price = dto.Price;
            house.CreatedAt = dto.CreatedAt;
            house.ModifiedAt = dto.ModifiedAt;

            await _context.House.AddAsync(house);
            await _context.SaveChangesAsync();

            return house;
        }

        public async Task<HouseDomain> GetAsync(Guid id)
        {
            var result = await _context.House
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<HouseDomain> Update(HouseDto dto)
        {

            var house = new HouseDomain()
            {
                Id = dto.Id,
                OwnerName = dto.OwnerName,
                Address = dto.Address,
                SquareMeters = dto.SquareMeters,
                YearOfBuild = dto.YearOfBuild,
                NumberOfRooms = dto.NumberOfRooms,
                NumberOfFloors = dto.NumberOfFloors,
                Price = dto.Price,
                CreatedAt = dto.CreatedAt,
                ModifiedAt = dto.ModifiedAt
            };

            _context.House.Update(house);
            await _context.SaveChangesAsync();
            return house;
        }

        public async Task<HouseDomain> Delete(Guid id)
        {
            var house = await _context.House
              .FirstOrDefaultAsync(x => x.Id == id);

            _context.House.Remove(house);
            await _context.SaveChangesAsync();

            return house;
        }
    }
}
