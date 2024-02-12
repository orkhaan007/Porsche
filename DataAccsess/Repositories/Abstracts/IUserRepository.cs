using DataAccess.Repositories.Abstracts;
using Domain.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess.Repositories.Abstracts;

public interface IUserRepository : IBaseRepository<User>
{
    ICollection<User> GetUsersByFirstName(string firstName);
    ICollection<User> GetUsersByEmail(string email);
}
