using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House.Core.Dto
{
    public class HouseDto
    {
        public Guid? Id { get; set; }
        public string OwnerName { get; set; }
        public string Address { get; set; }
        public int SquareMeters { get; set; }
        public int YearOfBuild { get; set; }
        public int NumberOfRooms { get; set; }
        public int NumberOfFloors { get; set; }
        public int Price { get; set; }


        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
