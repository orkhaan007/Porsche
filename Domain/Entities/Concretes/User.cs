using Domain.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace Domain.Entities.Concretes;

public class User : BaseEntity
{
    public string Salutation { get; set; }
    public string Title { get; set; }
    public string FirstName { get; set; }
    public string MiddleInitial { get; set; }
    public string LastName { get; set; }
    public string Suffix { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool IsLoggedIn { get; set; } = false;

    public virtual ICollection<Car> Cars { get; set; }

    public User()
    {
        Cars = new List<Car>();
    }
}