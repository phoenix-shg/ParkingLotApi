using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Models;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ParkingLotApi.Controllers
{
    [ApiController]
    [Route("ParkingLot")]
    public class ParkingLotController
    {
        private List<ParkingLot> parkinglots;

        [HttpPost]
        public ActionResult<ParkingLot> AddParkingLot(ParkingLot parkinglot)
        {
            parkinglots.Add(parkinglot);
            return new CreatedResult($"", parkinglot);
        }

        [HttpDelete("/{name}")]
        public List<ParkingLot> DeleteTheParkingLot([FromRoute] string name)
        {
            var parkinglot = parkinglots.Find(x => x.Name == name);
            parkinglots.Remove(parkinglot);
            return parkinglots;
        }

        [HttpGet("/{name}")]
        public ParkingLot SeeSpecificParkingLotDetails([FromQuery] string name)
        {
            var parkinglot = parkinglots.Find(x => x.Name == name);
            return parkinglot;
        }

    }
}
