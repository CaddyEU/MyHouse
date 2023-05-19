namespace House.Models
{
    public class HouseListViewModel
    {
        public Guid? Id { get; set; }
        public string OwnerName { get; set; }
        public string Address { get; set; }
        public int SquareMeters { get; set; }
        public int YearOfBuild { get; set; }
        public int NumberOfRooms { get; set; }
        public int NumberOfFloors { get; set; }
        public int Price { get; set; }
    }
}
