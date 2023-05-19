using House.Core.Dto;
using House.Core.ServiceInterface;
using House.Data;
using House.Models;
using Microsoft.AspNetCore.Mvc;

namespace House.Controllers
{
    public class HouseController : Controller
    {
        private readonly HouseDbContext _context;
        private readonly IHouseServices _houseServices;

        public HouseController
            (
                HouseDbContext context,
                IHouseServices houseServices
            )
        {
            _context = context;
            _houseServices = houseServices;
        }
        public IActionResult Index()
        {
            var result = _context.House
                .OrderByDescending(y => y.CreatedAt)
                .Select(x => new HouseListViewModel
                {
                    Id = x.Id,
                    OwnerName = x.OwnerName,
                    Address = x.Address,
                    SquareMeters = x.SquareMeters,
                    YearOfBuild = x.YearOfBuild,
                    NumberOfRooms = x.NumberOfRooms,
                    NumberOfFloors = x.NumberOfFloors,
                    Price = x.Price
                });

            return View(result);
        }
        [HttpGet]
        public IActionResult Add()
        {
            HouseEditViewModel house = new HouseEditViewModel();

            return View("Edit", house);
        }

        [HttpPost]
        public async Task<IActionResult> Add(HouseViewModel vm)
        {
            var dto = new HouseDto()
            {
                Id = vm.Id,
                OwnerName = vm.OwnerName,
                Address = vm.Address,
                SquareMeters = vm.SquareMeters,
                YearOfBuild = vm.YearOfBuild,
                NumberOfRooms = vm.NumberOfRooms,
                NumberOfFloors = vm.NumberOfFloors,
                Price = vm.Price,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,

            };

            var result = await _houseServices.Add(dto);
            if (result is null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]

        public async Task<IActionResult> Edit(Guid id)
        {
            var house = await _houseServices.GetAsync(id);

            if (house == null)
            {
                return NotFound();
            }

            var vm = new HouseEditViewModel()
            {
                Id = house.Id,
                OwnerName = house.OwnerName,
                Address = house.Address,
                SquareMeters = house.SquareMeters,
                YearOfBuild = house.YearOfBuild,
                NumberOfRooms = house.NumberOfRooms,
                NumberOfFloors = house.NumberOfFloors,
                Price = house.Price,
                CreatedAt = house.CreatedAt,
                ModifiedAt = house.ModifiedAt,
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(HouseEditViewModel vm)
        {
            var dto = new HouseDto()
            {
                Id = vm.Id,
                OwnerName = vm.OwnerName,
                Address = vm.Address,
                SquareMeters = vm.SquareMeters,
                YearOfBuild = vm.YearOfBuild,
                NumberOfRooms = vm.NumberOfRooms,
                NumberOfFloors = vm.NumberOfFloors,
                Price = vm.Price,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,
            };

            var result = await _houseServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var house = await _houseServices.GetAsync(id);

            if (house == null)
            {
                return NotFound();
            }

            var vm = new HouseViewModel()
            {
                Id = house.Id,
                OwnerName = house.OwnerName,
                Address = house.Address,
                SquareMeters = house.SquareMeters,
                YearOfBuild = house.YearOfBuild,
                NumberOfRooms = house.NumberOfRooms,
                NumberOfFloors = house.NumberOfFloors,
                Price = house.Price,
                CreatedAt = house.CreatedAt,
                ModifiedAt = house.ModifiedAt,
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var product = await _houseServices.Delete(id);

            if (product == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
