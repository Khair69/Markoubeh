using Markoubeh.Models;

namespace Markoubeh.Services
{
    public interface ICarsService
    {
        Task<Car[]> GetAvailableCarsAsync();

        Task<bool> AddCarAsync(Car newCar);

        Task<Car> GetCarByIdAsync(Guid carId);

        Task<bool> RentCarAsync(Guid carId, int numOfDays);
    }
}
