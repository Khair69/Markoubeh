using Markoubeh.Data;
using Markoubeh.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
            return await _context.Cars.Where(x => x.available == true).ToArrayAsync();
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
    }
}
