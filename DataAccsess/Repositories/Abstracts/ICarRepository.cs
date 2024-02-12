using DataAccess.Repositories.Abstracts;
using Domain.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess.Repositories.Abstracts;

public interface ICarRepository : IBaseRepository<Car>
{
    ICollection<Car> GetCarsByColor(string color);
    ICollection<Car> GetCarsWithPriceLessThan(int price);
}
