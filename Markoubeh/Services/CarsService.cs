using Markoubeh.Data;
using Markoubeh.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System.Collections;
using System.Linq;

namespace Markoubeh.Services
{
    public class CarsService : ICarsService
    {
        private readonly ApplicationDbContext _context;

        public CarsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Car[]> GetAvailableCarsAsync()
        {
            var Res = await _context.Cars.Where(x => x.available == true).ToArrayAsync();
            foreach (var r in Res) 
            {
                Console.WriteLine(r);
                if (!await IsCarAvail(r)) { Res = Res.Where(val => val != r).ToArray(); }
            }
            return Res;
        }

        public async Task<bool> AddCarAsync(Car newCar)
        {
            newCar.carId = Guid.NewGuid();
            
            _context.Cars.Add(newCar);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        public async Task<Car> GetCarByIdAsync(Guid carId)
        {
            return await _context.Cars.Where(x => x.carId == carId).FirstAsync();
        }

        public async Task<bool> RentCarAsync(Guid carId, int numOfDays)
        {
            Reservation newRes = new Reservation();

            newRes.ReservationId = Guid.NewGuid();
            newRes.carId = carId;
            newRes.startDate = DateTime.Now;
            newRes.endDate = DateTime.Now.AddDays(numOfDays);

            _context.Reservations.Add(newRes);

            var saveResault = await _context.SaveChangesAsync();
            return saveResault == 1;
        }

        public async Task<bool> IsCarAvail(Car carr)
        {
            var res = await _context.Reservations.Where(x => x.carId == carr.carId).ToArrayAsync();
            foreach (var r in res)
            {
                if(r.startDate <= DateTime.Now && r.endDate >= DateTime.Now) return false; 
            }
            return true;
        }
    }
}
