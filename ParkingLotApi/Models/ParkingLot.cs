using Microsoft.AspNetCore.Mvc;

namespace ParkingLotApi.Models
{
    public class ParkingLot
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string Location { get; set; }

        public ParkingLot(string name, int capacity, string location)
        {
            Name = name;
            Capacity = capacity;
            Location = location;
        }
    }
}
