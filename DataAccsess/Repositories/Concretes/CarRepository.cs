using DataAccess.Contexts;
using DataAccess.Repositories.Concretes;
using Domain.Entities.Concretes;
using DataAccsess.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;
#nullable disable

namespace DataAccess.Repositories.Concretes;

public class CarRepository<T> : BaseRepository<Car>, ICarRepository
{
    public ICollection<Car> GetCarsByColor(string color)
    {
        return _context.Set<Car>()
            .Where(c => c.Color == color)
            .ToList();
    }

    public ICollection<Car> GetCarsWithPriceLessThan(int price)
    {
        return _context.Set<Car>()
            .Where(c => c.TotalPrice < price)
            .ToList();
    }
}
