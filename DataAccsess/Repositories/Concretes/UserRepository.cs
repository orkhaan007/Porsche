using DataAccess.Contexts;
using DataAccess.Repositories.Concretes;
using Domain.Entities.Concretes;
using DataAccsess.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;
#nullable disable

namespace DataAccess.Repositories.Concretes;

public class UserRepository<T> : BaseRepository<User>, IUserRepository
{
    public ICollection<User> GetUsersByFirstName(string firstName)
    {
        return _context.Set<User>()
            .Where(u => u.FirstName == firstName)
            .ToList();
    }
    public ICollection<User> GetUsersByEmail(string email)
    {
        return _context.Set<User>()
            .Where(u => u.Email == email)
            .ToList();
    }
}
